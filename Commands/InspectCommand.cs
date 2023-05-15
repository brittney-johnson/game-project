namespace StarterGame;
/*
 * InspectCommand allows player to view item description before picking an item up.
 * It is implemented in the Player class
 */
public class InspectCommand : Command {
    public InspectCommand() : base() {
        this.Name = "inspect";
    }

    override
        public bool Execute(Player player) {
        if (this.HasSecondWord()) {
            player.Inspect(this.SecondWord);
        } else {
            player.OutputMessage("\nInspect What?");
        }
        return false;
    }
}