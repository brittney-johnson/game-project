using System.Runtime.CompilerServices;
/*
 *  creates a game world by creating rooms and setting their attributes,
 * as well as creating items and NPCs, and handling notifications when the player
 * enters a room. It uses a Singleton design pattern to make sure only one instance
 * of the class can exists
 */
namespace StarterGame;

public class GameWorld
{
    private static GameWorld _instance = null;
    public static GameWorld Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameWorld();
            }

            return _instance;
        }
    }

    private Room _entrance;

    public Room Entrance
    {
        get { return _entrance; }
    }

    private Room _exit;

    public Room Exit
    {
        get { return _exit; }
        set { _exit = value; }
    }

    private GameWorld()
    {
        CreateWorld();
        NotificationCenter.Instance.addObserver("PlayerDidEnterRoom",PlayerDidEnterRoom);
    }

    public void PlayerDidEnterRoom(Notification notification)
    {
        Player player = (Player)notification.Object;
        if (player != null)
        {
            if (player.CurrentRoom == Exit)
            {
                player.OutputMessage("\n >>> The player has entered the escape pod!");
            }
        }
    }
    
//creation of world and rooms
    public Room CreateWorld()
    {
        Room escapePodBay = new Room("in the Escape Pod Bay \nThis is the emergency evacuation area on the ship.");
        Room messHall = new Room("in the Mess Hall \nThis is the dining area of the ship");
        Room armory = new Room("in the Armory \nThis is the storage room where you can upgrade your weapons");
        Room engineRoom = new Room("in the Engine Room \nThis is the room where the ship's engine is housed");
        Room scienceLab = new Room("in the Science Lab \nThis is the research facility on the ship");
        Room medBay = new Room("in the Med Bay \nThis is the medical facility on the ship where you can heal");
        Room cargoHold = new Room("in the Cargo Hold \nThis is the ship's storage space");
        Room observationDeck = new Room("at the Observation Deck \nThis room has a view of space. Relax and appreciate the beauty of the Cosmos");
        Room teleportRoom = new Room("in the Teleport Room \nThis room is used to teleport to other rooms");
        _entrance = scienceLab;
        _exit = escapePodBay;
     
        Door door = Door.CreateDoor(medBay, escapePodBay, "south", "north");

        door = Door.CreateDoor(messHall, medBay, "south", "north");

  
        door = Door.CreateDoor(messHall, armory, "west", "east");
        

        door = Door.CreateDoor(cargoHold, armory, "south", "north");

        door = Door.CreateDoor(engineRoom, messHall, "south", "north");
        door.Close();
        ILockable regularLock2 = new RegularLock();
        door.TheLock = regularLock2;
        regularLock2.Lock();

        door = Door.CreateDoor(scienceLab, messHall, "west", "east");
        

        door = Door.CreateDoor(engineRoom, observationDeck, "north", "south");


        door = Door.CreateDoor(scienceLab, teleportRoom, "north", "south");



        //Item Creation and Dropping
        
        //medbay npc
        INpc npc2 = Npc.CreateNpc(medBay, "Zog", "Your ship is a threat to our planet. We cannot allow it to remain here.");

        //escapePodBay npc
        INpc npc1 = Npc.CreateNpc(escapePodBay, "Drogath", "Your ship's presence here is a violation of our intergalactic laws. We have no choice but to destroy it");
        
        //scienceLab items
        IItem item = new Item("broken test tube", 5f, 8f, 2);
        scienceLab.Drop(item);
        
        
        //engineRoom items
        item = new Item("fire extinguisher", 30f, 20f, 1);
        engineRoom.Drop(item);
        INpc npc3 = Npc.CreateNpc(engineRoom, "Nexxar", "Your precious engine will soon be nothing but a heap of scrap metal.\nSay goodbye to your little spaceship.");

        //cargoHold items
        item = new Item("laser gun", 20f, 15f, 1);
        cargoHold.Drop(item);
        IItem decorator = new Item("extra power", 0.5f, 10f);
        item.AddDecorator(decorator);
        item = new Item("repair kit", 10f, 5f, 1);
        cargoHold.Drop(item);
        item = new Item("engine room key", 2f, 1f, 1);
        cargoHold.Drop(item);

        //mess Hall room items
        item = new Item("engine part1", 10f, 15f, 1);
        messHall.Drop(item);

        //teleport items
        item = new Item("engine part2", 10f, 15f, 1);
        observationDeck.Drop(item);

        //armory items
        item = new Item("laser gun", 3f, 4f, 1);
        armory.Drop(item);
        item = new Item("axe", 40f, 4f, 1);
        armory.Drop(item);

        //observationDeck
        item = new Item("telescope", 50f, 20f, 1);
        observationDeck.Drop(item);
        item = new Item("wrench", 10f, 15f, 1);
        observationDeck.Drop(item);
        INpc npc4 = Npc.CreateNpc(observationDeck, "Zahr", "We are the masters of the universe. You are nothing.Muahahaha!");


        return scienceLab;
    }
}
    