namespace Algorithms.BloomFilter;

public class BloomFilter
{
    private int _size;
    private Storage _storage;
    public BloomFilter(int size = 100)
    {
        this._size = size;
        this._storage = this.CreateStore(size);
    }
    public class Storage(List<bool> storage)
    {
        public bool GetValue(int index) => storage[index];

        public bool SetValue(int index) => storage[index] = true;
    }
    
    
    /// <summary>
    /// insert the item in the storage
    /// </summary>
    /// <param name="item"></param>
    public void Insert(string item)
    {
        int[] hashValues = this.GetHashValues(item);

        foreach (var hash in hashValues)
        {
            this._storage.SetValue(hash);
        }
    }

    public bool MayContain(string item)
    {
        int[] hashValues = this.GetHashValues(item);

        for (int hashIndex = 0; hashIndex < hashValues.Length; hashIndex++)
        {
            if (this._storage.GetValue(hashValues[hashIndex]))
            {
                // whe know that the item was definitely not inserted
                return false;
            }
        }
        // The item may or may not have been inserted
        return true;
    }
    
    
    /// <summary>
    /// Create the data storfe for our filter.
    /// we use this methiod to generate the store in order to
    /// encapsulate the data itself and only provide access to the necessary methods
    /// </summary>
    /// <param name="storeSize"></param>
    /// <returns></returns>
    public Storage CreateStore(int storeSize)
    {
        List<bool> storage = [];

        for (int storageCellIdex = 0; storageCellIdex < storeSize; storageCellIdex++)
        {
            storage.Add(false);
        }
        
        return new Storage(storage);
    }
    private int HashOne(string item)
    {
        var hash = 0;
        for (var charIndex = 0; charIndex < item.Length; charIndex++)
        {
            var charCode = item[charIndex];
            hash = (hash << 5) + charCode;
            hash &= hash;
            hash = Math.Abs(hash);
        }

        return hash % _size;
    }

    private int HashTwo(string item)
    {
        var hash = 5381;
        for (int charIndex = 0; charIndex < item.Length; charIndex++)
        {
            var charCode = item[charIndex];
            hash = (hash << 5) + hash + charCode;
        }

        return Math.Abs(hash % _size);
    }

    private int HashThree(string item)
    {
        var hash = 0;

        for (int charIndex = 0; charIndex < item.Length; charIndex++)
        {
            var charCode = item[charIndex];
            hash = (hash << 5) - hash;
            hash += charCode;
            hash &= hash;
        }

        return Math.Abs(hash % _size);
    }


    /// <summary>
    /// Return all 3 hash functions on the input and return an array of result
    /// </summary>
    /// <returns></returns>
    public int[] GetHashValues(string item)
        =>
        [
            this.HashOne(item),
            this.HashTwo(item),
            this.HashThree(item)
        ];
}