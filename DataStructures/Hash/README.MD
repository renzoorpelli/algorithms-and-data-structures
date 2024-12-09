

## Hash tables
Data structure used to insert, look up, and remove key-value pairs quickly.

- Each `key` is translated by a hash function into a distinct index in an array
- The `index` functions as a storage location for the matching value

### Concepts
- `Hash function`
A function that translates keys to `array indices` is known as hash function.
- `Load factor`;
Is determined by how many elements are kept there relation to how big table is.
- `Collisions`;
Two distinct inputs (keys) generate the same hash value (mapped to the same location, bucket).
This can cause issues because each location in a hash table is typically intended to store one unique piece of data.
Hash tables use different `Collision resolution techniques`:
    1) `Chaining`; Each bucket in hash table points to a list or linked list of entries that share the same hash.
        If multiple entries have the same hash, they are added to this list, and the system can still access each one by traversing the list.
    2) `Open Addressing`; Instead of using a list to store multiple items in the same bucket, open addressing places entries in different bucket if 
        the initially calculated bucket is already occupied.
       1) `Linear probing`; Looking fo the next available slot in a sequential manner
       2) `Quadratic probign`; Searching for an em,pty slot by skipping a specif number of slots, using a quadratic formula
       3) `Double Hashing`; Using a second hash function to calculate a different location when a collision occurs.
    3) `Robin Hood Hashing`; Attempts to balance the distribution by moving existing entries within the table 
       if it helps new entries find a close open position
