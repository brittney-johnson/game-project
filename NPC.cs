using System.Security.Cryptography;

namespace StarterGame;
/*
 * Npc allows creation of Npc characters in GameWorld
 */
public class Npc : INpc
{
        
    private string _name;
    private Room _location;
    private string _dialog;
        
    public string Name { set { _name = value; } get { return _name; } }
    public Room Location { set { _location = value; } get { return _location; } }
    public string Dialog { set { _dialog = value; } get { return _dialog; } }

    public Npc(Room location, string name)
    {
        _location = location;
        _name = name;
    }

    public Npc(Room location, string name, string dialog)
    {
        _location = location;
        _name = name;
        _dialog = dialog;
    }

    public static Npc CreateNpc(Room location, string name)
    {
        Npc npc = new Npc(location, name);
        location.SetNpc(name, npc);
        return npc;
    }

    public static Npc CreateNpc(Room location, string name, string dialog)
    {
        Npc npc = new Npc(location, name, dialog);
        location.SetNpc(name, npc);
        return npc;
    }

    public void GetRandomNeighbor()
    {
        if (_location != null)
        {
            int index = RandomNumberGenerator.GetInt32(_location.Neighbors.Count);
            Room neighbor = _location.Neighbors[index.ToString()];
            _location.RemoveNpc(_name);
            neighbor.SetNpc(_name, this);
            _location = neighbor;
        }
    }
    
    
    
    public string Description {
        get { return Name + " said: " + Dialog + "\n"; }
    }
}