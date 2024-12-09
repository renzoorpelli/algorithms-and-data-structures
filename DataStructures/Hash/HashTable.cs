using System.Runtime.Intrinsics.X86;

namespace DataStructures.Hash;

public class HashTable
{
    // number of buckets
    private readonly int _bucket;
   
    // values
    private LinkedList<KeyValuePair<int, int>>[] Table { get; set; }
    private int[] Keys { get; set; }

    public HashTable(int bucket)
    {
        _bucket = bucket;
        Table = new LinkedList<KeyValuePair<int, int>>[bucket];
        Keys = new int[bucket];
    
        // initialize each bucket
        for (int i = 0; i < bucket; i++)
        {
            Table[i] = new();
        }
    }
    
    /// <summary>
    /// Hash function to "compute" the index
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int Hash(int key)
        => key % _bucket;
    
    public void Insert(int value)
    {
        var keyHash = Hash(value);
        
        this.Keys[keyHash] = keyHash;
        var bucketLinkedList = Table[keyHash];
        
        var node = bucketLinkedList.FirstOrDefault(x => x.Key == keyHash);
        
        if(node.Equals(default(KeyValuePair<int,int>)))
        {
            bucketLinkedList.Remove(node);
        }
        
        bucketLinkedList.AddLast(new KeyValuePair<int, int>(keyHash, value));
    }

    public void Delete(int key)
    {
        var keyHash = Hash(key);
        this.Keys[keyHash] = 0;
        var bucketLinkedList = Table[keyHash];
        var node = bucketLinkedList.FirstOrDefault(x => x.Key == key);
        if(!node.Equals(default(KeyValuePair<int,int>)))
        {
            bucketLinkedList.Remove(node);
        }
    }

    public void Display()
    {
        for (int i = 0; i < Table.Length; i++)
        {
            var bucketLinkedList = Table[i];

            if (bucketLinkedList.Count > 0)
            {
                Console.WriteLine($"Bucket {i}:");

                foreach (var node in bucketLinkedList)
                {
                    Console.WriteLine($"  Key: {node.Key}, Value: {node.Value}");
                }
            }
        }
    }
}