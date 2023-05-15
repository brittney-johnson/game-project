namespace StarterGame;
/*
 * DropCommand allows player to drop items and remove them from their inventory.
 * It is implemented in the player class.
 */
public class DropCommand : Command {

    public DropCommand() : base() {
        this.Name = "drop";
    }

    override
        public bool Execute(Player player) {
        if (this.HasSecondWord()) {
            {
                string item = this.SecondWord;
                if (this.HasThirdWord())
                {
                    item += " " + this.ThirdWord;
                    if (this.HasFourthWord())
                    {
                        item += " " + this.FourthWord;
                    }
                }
                player.Drop(item);
            }
        } else {
            player.OutputMessage("\nDrop what?");
        }
        return false;
    }
}