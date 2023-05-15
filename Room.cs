namespace StarterGame;

public class Room

{
    private Dictionary<string, Door> _exits;
    private Dictionary<string, Room> _neighbors;
    private string _tag;
    private IItemContainer _items;
    //private Dictionary<string, Npc> _npcs;
    public string Tag
    {
        get
        {
            return _tag;
        }
        set
        {
            _tag = value;
        }
    }

    public Room() : this("No Tag"){}

    // Designated Constructor
    public Room(string tag)
    {
        _exits = new Dictionary<string, Door>();
        this.Tag = tag;
        _items = new ItemContainer("");
        _npcs = new Dictionary<string, Npc>();
        _neighbors = new Dictionary<string, Room>();

    }
    public void SetExit(string exitName, Door door)
    {
        _exits[exitName] = door;
    }
    
    public Door GetExit(string exitName)
    {
        Door door = null;
        _exits.TryGetValue(exitName, out door);
        return door;
    }
    public string GetExits()
    {
        string exitNames = "Exits: ";
        Dictionary<string, Door>.KeyCollection keys = _exits.Keys;
        foreach (string exitName in keys)
        {
            exitNames += " " + exitName;
        }

        return exitNames;
    }
    
    public void Drop(IItem item)
    {
        _items.Insert(item);
    }


    public IItem PickUp(string itemName)
    {
        IItem itemReturn = _items.Remove(itemName);
        return itemReturn;
    }
    private Dictionary<string, Npc> _npcs;
    public void SetNpc(string name, Npc npc)
    {
        if (npc != null)
        {
            _npcs[name] = npc;
        }
        else
        {
            _npcs.Remove(name);
        }
    }

    public Npc GetNpc(string name)
    {
        Npc npc = null;
        _npcs.TryGetValue(name, out npc);
        return npc;
    }
    
    public string GetNPCs()
    {
        string names = "";
        Dictionary<string, Npc>.KeyCollection keys = _npcs.Keys;
        foreach (string name in keys)
        {
            names += " " + name;
        }

        return names;
    }

    public void AddNeighbor(string direction, Room neighbor)
    {
        _neighbors[direction] = neighbor;
    }

    public Room GetNeighbor(string direction)
    {
        if (_neighbors.ContainsKey(direction))
        {
            return _neighbors[direction];
        }
        else
        {
            return null;
        }
    }
    
    public Dictionary<string, Room> Neighbors
    {
        get { return _neighbors; }
    }
    
    public void RemoveNpc(string name)
    {
        if (_npcs.ContainsKey(name))
        {
            _npcs.Remove(name);
        }
    }
    

    public string Description()
    {
        return "You are " + this.Tag + ".\n *** " + this.GetExits() +"\n >>> Items: " + _items.LongName + "### NPCs: " + this.GetNPCs();
    }
}