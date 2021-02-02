using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresStudy
{
    public class DynamicArray<T> : IEnumerable where T : class
    {
        private long _capacity;
        private readonly long _initialCapacity;
        private long _actualLength = 0;
        private T[] _underlyingStaticArray;

        static readonly int _defaultInitialCapacity = 16;

        public long Size { get => _actualLength; }
        public long Capacity { get => _capacity; }

        // Indexer declaration.
        public T this[long index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                Set(index, value);
            }
        }

        private T Get(long index)
        {
            if (index < 0 || index > _actualLength - 1)
            {
                throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
            }
            return _underlyingStaticArray[index];
        }

        private void Set(long index, T value)
        {
            if (index < 0 || index >= _actualLength + 1 || index == _capacity)
            {
                throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
            }
            _underlyingStaticArray[index] = value;
            _actualLength++;
        }

        /// <summary>
        /// Initialize a new Dynamic Array with a Default Initial Capacity
        /// </summary>
        public DynamicArray()
        {
            _capacity = _defaultInitialCapacity;
            _initialCapacity = _defaultInitialCapacity;
            _underlyingStaticArray = new T[_defaultInitialCapacity];
        }

        /// <summary>
        /// Initialize a new Dynamic Array with an specific Initial Capacity
        /// </summary>
        /// <param name="initialCapacity"></param>
        public DynamicArray(long initialCapacity)
        {
            if (initialCapacity <= 0) throw new ArgumentException("The argument should be higher than 0", nameof(initialCapacity));
            _capacity = initialCapacity;
            _initialCapacity = initialCapacity;
            _underlyingStaticArray = new T[initialCapacity];
        }

        /// <summary>
        /// Reset the Dynamic Array to the initial capacity and clear all values
        /// </summary>
        public void Reset()
        {
            _capacity = _initialCapacity;
            _actualLength = 0;

            var newArray = new T[_capacity];
            _underlyingStaticArray = newArray;
        }

        /// <summary>
        /// Removes all elements from the Dynamic Array, keeping the actual capacity
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _actualLength; i++)
            {
                _underlyingStaticArray[i] = null;
            }
            _actualLength = 0;
        }

        /// <summary>
        /// Adds a new item to the Dynamic Array
        /// </summary>
        /// <param name="item">The new item to add</param>
        public void Add(T item)
        {
            if (_actualLength + 1 > _capacity)
            {
                var newCapacity = _capacity * 2;

                var newArray = new T[newCapacity];
                for (int i = 0; i < _actualLength; i++)
                {
                    newArray[i] = _underlyingStaticArray[i];
                }
                _underlyingStaticArray = newArray;
                _capacity = newCapacity;
            }

            _underlyingStaticArray[_actualLength] = item;
            _actualLength++;
        }

        /// <summary>
        /// Adds a range of new items to the Dynamic Array
        /// </summary>
        /// <param name="items">The IList of items to add</param>
        public void AddRange(IList<T> items)
        {
            if (_actualLength + items.Count > _capacity)
            {
                long newCapacity = (_capacity + items.Count) * 2;

                var newArray = new T[newCapacity];
                for (int i = 0; i < _actualLength; i++)
                {
                    newArray[i] = _underlyingStaticArray[i];
                }

                _underlyingStaticArray = newArray;
                _capacity = newCapacity;
            }

            for (int i = 0; i < items.Count; i++)
            {
                _underlyingStaticArray[_actualLength] = items[i];
                _actualLength++;
            }
        }

        /// <summary>
        /// Removes an item from the Dynamic Array based on a index
        /// </summary>
        /// <param name="index">The index to remove an item</param>
        public void RemoveAt(long index)
        {
            if (index < 0 || index > _actualLength - 1)
            {
                throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
            }

            long newCapacity = _capacity - 1;

            var newArray = new T[newCapacity];

            for (int i = 0; i < _actualLength - 1; i++)
            {
                long newIndex;
                if (i < index)
                {
                    newIndex = i;
                }
                else
                {
                    newIndex = i + 1;
                }

                newArray[i] = _underlyingStaticArray[newIndex];
            }

            _underlyingStaticArray = newArray;
            _capacity = newCapacity;
            _actualLength--;
        }

        /// <summary>
        /// Removes the first occurrence of an item, based on the Equals method implementation of the item type
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            for (int i = 0; i < _actualLength; i++)
            {
                if (_underlyingStaticArray[i].Equals(item))
                {
                    RemoveAt(i);
                    break;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (_actualLength == 0)
            {
                yield break;
            }

            for (int index = 0; index < _capacity; index++)
            {
                if (_underlyingStaticArray[index] != null)
                {
                    yield return _underlyingStaticArray[index];
                }
            }
        }
    }
}