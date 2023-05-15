using System;
using System.Collections.Generic;
using System.Text;
/*The Item class represents an item that has a name, weight, volume, and value.
 The ItemContainer class represents a container that can hold multiple items
 */
namespace StarterGame {
    public class Item : IItem {

        private float _weight;
        private float _volume;
        private string _name;
        private float _value;
        private IItem _decorator;
        private bool _isDecorator;
        

        public Item(string name) : this(name, 0f, 0f) {
        }

        public Item(string name, float weight, float volume) : this(name, weight, volume, 0f) {
        }

        public Item(string name, float weight, float volume, float value) : this(name, weight, volume, value, false) {
        }

        public Item(string name, float weight, float volume, float value, bool isDecorator) {
            _name = name;
            _weight = weight;
            _volume = _volume;
            _value = value;
            _decorator = null;
            _isDecorator = isDecorator;
        }

        public float Weight {
            get { return _weight + (_decorator!=null?_decorator.Weight:0); }
        }
        
        public float Volume {
            get { return _volume + (_decorator!=null?_decorator.Volume:0); }
        }

        public string Name {
            get { return _name; }
        }

        public string LongName {
            get {
                return Name + (_decorator != null ?", " + _decorator.LongName : "");
            }
        }

        public bool IsDecorator {
            get { return _isDecorator; }
        }

        public string Description {
            get { return LongName + ": " + "Weight- " + Weight + " Volume- " + Volume + " Value- " + Value; }
        }

        public float Value {
            get { return _value + (_decorator != null ? _decorator.Value : 0); }
        }

        public void AddDecorator(IItem decorator) {
            if (decorator.IsDecorator) {
            if (_decorator == null) {
                _decorator = decorator;
            } else {
                _decorator.AddDecorator(decorator);
            }
            }
            
            
        }

        
    }public class ItemContainer : IItemContainer {
            private float _weight;
            private float _volume;
            private string _name;
            private float _value;
            private IItem _decorator;
            private Dictionary<string, IItem> _items;

            public ItemContainer() : this("NoName") {

            }

            public ItemContainer(string name) : this(name, 0f, 0f, 1) {
            }

            public ItemContainer(string name, float weight, float volume) : this(name, weight, volume, 0f) {
            }

            //Designated Constructor
            public ItemContainer(string name, float weight, float value, float volume) {
                _name = name;
                _weight = weight;
                _volume = volume;
                _value = value;
                _decorator = null;
                _items = new Dictionary<string, IItem>();
            }


            public string Name {
                get {
                    return _name;
                }
            }

            public string LongName {
                get {
                string longName = Name + "\n";
                foreach (IItem item in _items.Values) {
                    longName += item.Description + "\n";
                }
                    return longName;
                }
            }

            public float Weight {
                get {
                float itemsWeight = 0;
                foreach (IItem item in _items.Values) {
                    itemsWeight += item.Weight;
                }
                    return _weight + itemsWeight;
                }
            }
            
            public float Volume {
                get {
                    float itemsVolume = 0;
                    foreach (IItem item in _items.Values) {
                        itemsVolume += item.Volume;
                    }
                    return _volume + itemsVolume;
                }
            }

            public float Value {
            get {
                float itemsValue = 0;
                foreach (IItem item in _items.Values) {
                    itemsValue += item.Value;
                }
                return _value + itemsValue;
            }
        }

            public string Description {
                get { return Name + ": " + "Weight- " + Weight + " Volume- "+ Volume +" Value: " + Value + "\n"; }
            }

            public bool IsDecorator {
                get {
                    return false;
                }
            }

            public void AddDecorator(IItem decorator) {
                
            }


            public void Insert(IItem item) {
                _items[item.Name] = item;
            }

            public IItem Remove(string itemName) {
                IItem itemToReturn = null;
                _items.Remove(itemName, out itemToReturn);
                return itemToReturn;
            }
        
        }
}
