using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Item<TKye, TValue>
    {
        
        public TKye Key { get; set; }

        public TValue Value { get; set; }
        public Item() { }

        public Item(TKye key, TValue value)
        {
            
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }

    }

    public class Map<TKey, TValue>
    {
     
        private List<Item<TKey, TValue>> _items = new List<Item<TKey, TValue>>();

        public int Count => _items.Count;

        public IReadOnlyList<TKey> Keys => (IReadOnlyList<TKey>)_items.Select(i => i.Key).ToList();

        public void Add(Item<TKey, TValue> item)
        {

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_items.Any(i => i.Key.Equals(item.Key)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {item.Key}.", nameof(item));
            }

            _items.Add(item);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_items.Any(i => i.Key.Equals(key)))
            {
                Console.WriteLine($"Словарь уже содержит значение с ключом {key}.", nameof(key));
                
            }

            var item = new Item<TKey, TValue>()
            {
                Key = key,
                Value = value
            };

            _items.Add(item);
        }

        public void Remove(TKey key)
        {
         
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

        
            var item = _items.SingleOrDefault(i => i.Key.Equals(key));

  
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public bool Contain(TKey key)
        {
            if (_items.Any(i => i.Key.Equals(key)))
            {
                return true;
            }
            return false;
        }

        public bool ContainType(String value)
        {
            
            if (_items.Any(i => i.Key.ToString().Equals(value)))
            {
                return true;
            }
            return false;
        }


        public void Update(TKey key, TValue newValue)
        {
         
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (newValue == null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            if (!_items.Any(i => i.Key.Equals(key)))
            {
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));
            }
    
            var item = _items.SingleOrDefault(i => i.Key.Equals(key));

      
            if (item != null)
            {
                item.Value = newValue;
            }
        }

        public void UpdateSelected(String key, TValue newValue)
        {

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (newValue == null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            if (!_items.Any(i => i.Key.ToString().Equals(key)))
            {
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));
            }

            var item = _items.SingleOrDefault(i => i.Key.ToString().Equals(key));


            if (item != null)
            {
                item.Value = newValue;
            }
        }

        public TValue Get(TKey key)
        {
           
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

           
            var item = _items.SingleOrDefault(i => i.Key.Equals(key)) ??
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));

            return item.Value;
        }
    }
}
