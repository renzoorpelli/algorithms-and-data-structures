namespace DataStructures.Cache;

public class LRUCache<TKey, TValue>
{
    private readonly int _capacity;
    private LinkedList<CachedItem> cache;
    private Dictionary<TKey, LinkedListNode<CachedItem>> cacheMap;

    public LRUCache(int capacity)
    {
        if (capacity < 1) throw new InvalidOperationException();

        this._capacity = capacity;
        this.cache = new LinkedList<CachedItem>();
        this.cacheMap = new Dictionary<TKey, LinkedListNode<CachedItem>>();
    }

    public TValue Get(TKey key)
    {
        if (!cacheMap.TryGetValue(key, out var node)) return default!;
        
        cache.Remove(node);
        cache.AddFirst(node);
        cacheMap[key] = node;
        return node.Value.Value;
    }

    public void Put(TKey key, TValue value)
    {
        if (cacheMap.TryGetValue(key, out var node))
        {
            cache.Remove(node);
        }
        else if (cache.Count >= _capacity)
        {
            RemoveLeastNode();
        }

        var item = new CachedItem(key, value);
        cacheMap[key] = new LinkedListNode<CachedItem>(item);
        cache.AddFirst(item);
    }

    private void RemoveLeastNode()
    {
        var tail = cache.Last;
        cacheMap.Remove(tail.Value.Key);
        cache.Remove(tail);
    }
    
    private record CachedItem(TKey Key, TValue Value)
    {
        public TKey Key { get; set; } = Key;
        public TValue Value { get; set; } = Value;
    }
}

