namespace StarterGame;
/*
 * ShowMapCommand allows player to view a map of the game and
 * also gives player their current location in the game
 */
public class ShowMapCommand: Command
{
    public ShowMapCommand() : base() {
        this.Name = "showmap";
    }

    public string map()
    {
        string str = "";
        str +=
            "    |                                               Map                                                     |\n";
        str +=
            "    |                                       Observation Deck                                                |\n";
        str +=
            "    |                                                |                                                      |\n";
        str +=
            "    |                                                |                                                      |\n";
        str +=                                                                   
            "    |                        Cargo Hold          Engine Room           Teleport Room                        |\n";
        str +=
            "    |                             |                  |                      |                               |\n";
        str +=
            "    |                             |                  |                      |                               |\n";
        str +=                                  
            "    |                          Armory  <_______ Mess Hall   _________>   Science Lab                        |\n";
        str +=
            "    |                                               |                                                       |\n";
        str +=
            "    |                                               |                              ⇡                        |\n";
        str +=
            "    |                                            Medbay                            N                        |\n";
        str +=
            "    |                                               |                   ⇠      W   *    E    ⇢              |\n";
        str +=
            "    |                                               |                              S                        |\n";
        str +=
            "    |                                        Escape Pod Bay                        ⇣                        |\n";
        str +=
            "    ________________________________________________________________________________________________________";
        return str;
    }

    override
        public bool Execute(Player player)
    {
        player.OutputMessage(map() + "\n" + player.CurrentRoom.Description());
        return false;
    }
}