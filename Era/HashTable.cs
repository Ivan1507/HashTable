using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Era
{
    class HashTable
    {
        private Dictionary<int, List<Item>> _items = null;
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();
        public HashTable()
        {
            _items = new Dictionary<int, List<Item>>();
        }
        public void Insert(string key,string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            var item = new Item(key, value);
            var hash = GetHash(item.Key);
            List<Item> hashtableitem = null;
            if (_items.ContainsKey(hash))
            {
                hashtableitem = _items[hash];

                var oldElemnt = hashtableitem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElemnt != null)
                {
                    throw new ArgumentException($"Уже содержится элемент с ключом {key}");

                }
                _items[hash].Add(item);
            }
            else
            {
                hashtableitem = new List<Item> { item };
                _items.Add(hash, hashtableitem);
            }
        }
        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return;
            }
            var hashtableItem = _items[hash];
            var item = hashtableItem.SingleOrDefault(i => i.Key == key);
            if (item != null)
            {
                hashtableItem.Remove(item);
            }

        }
        public string Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash))
            {
                return null;
            }
            var hashtableitem = _items[hash];
            if (hashtableitem != null)
            {
                var item = hashtableitem.SingleOrDefault(i=>i.Key==key);
                if (item != null)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public int GetHash(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            var hash = value.Length;
            return hash;
        }
    }
}
