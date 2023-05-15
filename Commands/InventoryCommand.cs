namespace StarterGame;
/*
 * InventoryCommand allows player to view their inventory
 * It is implemented in the Player class
 */
public class InventoryCommand : Command {
    public InventoryCommand() : base() {
        this.Name = "inventory";
    }
    
        public override bool Execute(Player player) {
        player.Inventory();
        return false;
    }
}