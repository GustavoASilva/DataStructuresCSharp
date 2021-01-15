using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresStudy
{
    public class DynamicArray<T> : IEnumerable where T : class
    {
        private long _capacity;
        private long _actualLength = 0;
        private T[] _underlyingStaticArray;

        static readonly int _defaultCapacity = 16;

        public long Size { get => _actualLength; }
        public long Capacity { get => _capacity; }

        // Indexer declaration.
        public T this[int index]
        {

            get
            {
                if (index < 0 || index > _actualLength - 1)
                {
                    throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
                }
                return _underlyingStaticArray[index];
            }
            set
            {
                if (index < 0 || index > _actualLength + 1)
                {
                    throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
                }
            }
        }

        private T Get(int index)
        {
            if (index < 0 || index > _actualLength - 1)
            {
                throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
            }
            return _underlyingStaticArray[index];
        }

        private void Set(int index, T value)
        {
            if (index < 0 || index > _actualLength - 1)
            {
                throw new ArgumentOutOfRangeException("index", "The specified index is out of the Dynamic Array value range");
            }
            _actualLength++;
        }

        public DynamicArray()
        {
            _capacity = _defaultCapacity;
            _underlyingStaticArray = new T[_defaultCapacity];
        }

        public DynamicArray(int initialCapacity)
        {
            if (initialCapacity <= 0) throw new ArgumentException("The argument is not valid", nameof(initialCapacity));
            _capacity = initialCapacity;
            _underlyingStaticArray = new T[initialCapacity];
        }

        public void Add(T item)
        {
            if (_actualLength + 1 > _capacity)
            {
                var newCapacity = _capacity * 2;
                _capacity = newCapacity;

                var newArray = new T[_capacity];
                for (int i = 0; i < _actualLength; i++)
                {
                    newArray[i] = _underlyingStaticArray[i];
                }
                _underlyingStaticArray = newArray;
            }

            _underlyingStaticArray[_actualLength] = item;
            _actualLength++;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IList<T> itens)
        {
            if (_actualLength + itens.Count > _capacity)
            {
                var newCapacity = (_capacity + itens.Count) * 2;
                _capacity = newCapacity;

                var newArray = new T[_capacity];
                for (int i = 0; i < _actualLength; i++)
                {
                    newArray[i] = _underlyingStaticArray[i];
                }
                _underlyingStaticArray = newArray;
            }

            for (int i = 0; i < itens.Count; i++)
            {
                _underlyingStaticArray[_actualLength] = itens[i];
                _actualLength++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < _underlyingStaticArray.Length; index++)
            {
                if (_underlyingStaticArray[index] != null)
                {
                    yield return _underlyingStaticArray[index];
                }
            }
        }
    }
}