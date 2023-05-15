using System.Text;

namespace StarterGame;
/*
 * The class represents the player's current state, current location, inventory,
 * and actions they can take such as walking to a new location, inspecting items
 * and NPCs, talking to NPCs, picking up and dropping items, using items, and opening doors.
 * The purpose of the class is to provide functionality for player to interact with
 * the game world
 */
public class Player
{

    public bool usedRepairKit;

    public enum PlayerState
    {
        Playing, Won, Lost
    };

    private PlayerState _state;

    public PlayerState State
    {
        get { return _state; }
        set { _state = value; }
    }
    
    
    
    private Room _currentRoom = null;
    List<Room> forBack = new List<Room>();

    public Room CurrentRoom
    {
        get { return _currentRoom; }
        set { _currentRoom = value; }
    }

    private IItemContainer _inventory;

    public Player(Room room)
    {
        _currentRoom = room;
        _inventory = new ItemContainer("");
    }
    

    public void WaltTo(string direction)
    {
        forBack.Add(CurrentRoom);
        Door nextDoor = this.CurrentRoom.GetExit(direction);
        if (nextDoor != null)
        {
            if (nextDoor.IsOpen)
            {
                Room nextRoom = nextDoor.RoomOnTheOtherSideOf(CurrentRoom);
                this.CurrentRoom = nextRoom;
                this.OutputMessage("\n" + this.CurrentRoom.Description());
                NotificationCenter.Instance.postNotification(new Notification("PlayerDidEnterRoom", this));
            }
            else
            {
                this.OutputMessage("\nThe door on " + direction + " is closed.");
            }
        }
        else
        {
            this.OutputMessage("\nThere is no door on " + direction);
        }
    }

    public void Give(IItem item)
    {
        _inventory.Insert(item);
    }

    public IItem Take(string itemName)
    {
        return _inventory.Remove(itemName);
    }

    public void Inspect(string itemName)
    {
        IItem item = CurrentRoom.PickUp(itemName);
        if (item != null)
        {
            OutputMessage("\n" + item.Description);
            CurrentRoom.Drop(item);
        }
        else
        {
            OutputMessage("\nThere is no item named " + itemName + ".");
        }

    }

    public void TalkTo(string npcName)
    {
        INpc npc = CurrentRoom.GetNpc(npcName);
        if (npc != null)
        {
            OutputMessage("\n" + npc.Description);
        }
        else
        {
            OutputMessage("\nThere is no NPC named " + npcName + ".");
        }

    }

    public void Inventory()
    {
        OutputMessage("Current Inventory: \n" + _inventory.LongName + "Total weight: " + _inventory.Weight +
                      "Total volume: " + _inventory.Volume);
    }

    public void PickUp(string itemName)
    {
        IItem item = CurrentRoom.PickUp(itemName);
        if (item != null)
        {
            if (_inventory.Weight + item.Weight < 35 && _inventory.Volume + item.Volume < 20)
            {
                Give(item);
                OutputMessage("you picked up the " + item.Name);
            }
            else
            {
                OutputMessage("Sorry, you cannot pick up " + itemName);
            }

        }
        else
        {
            OutputMessage("There is no item named " + itemName + " in the room.");
        }

    }


    public void Drop(string itemName)
    {
        IItem item = Take(itemName);
        if (item != null)
        {
            CurrentRoom.Drop(item);
            OutputMessage("You dropped the " + itemName);
        }
        else
        {
            OutputMessage("You don't have a " + itemName);
        }
    }

    public void Use(string itemName)
    {
        usedRepairKit = false;
        IItem item = Take(itemName);
        if (item != null)
        {
            OutputMessage("You used the " + itemName);

            if (CurrentRoom.Description().Contains("Engine Room") && CurrentRoom.Description().Contains("engine part1") && CurrentRoom.Description().Contains("engine part2")){
                if (itemName == "repair kit")
                {
                    usedRepairKit = true;
                    OutputMessage("You used the repair kit. The engine is back to working!");
                    State = PlayerState.Won;
                }

            }
            else
            {
                OutputMessage("You don't have the correct item to repair the engine...");
            }
        }
        else
        {
            OutputMessage("You cannot use the " + itemName);
        }
    }

    public void Back()
    {
        if (forBack.Count > 0)
        {
            CurrentRoom = forBack[forBack.Count - 1];
            forBack.Remove(forBack[forBack.Count - 1]);
            this.OutputMessage("\n" + this.CurrentRoom.Description());
        }
        else
        {
            OutputMessage("\n\nThere is no where to return to");
        }
    }
    
    public void Open(string doorName) {
        Door door = CurrentRoom.GetExit(doorName);
        if (door != null) {
            if (door.IsOpen) {
                OutputMessage("\nThe door on " + doorName + " is already open.");
            }else if(door.TheLock.IsLocked){
                if(_inventory.LongName.Contains("engine room key"))
                {
                    door.TheLock.Unlock();
                    door.Open();
                    OutputMessage("You unlocked the engine room...");
                } else { OutputMessage(("The engine room in locked, find the key...")); }
            } else {
                if (door.Open()) {
                    OutputMessage("\nThe door on " + doorName + " is now open.");
                } else {
                    OutputMessage("\nThe door on " + doorName + " cannot be opened.");
                }
                
            }
        } else {
            this.OutputMessage("\nThere is no door on " + doorName);
        }
    }
    
    public void OutputMessage(string message)
    {
        Console.WriteLine(message);
    }
}