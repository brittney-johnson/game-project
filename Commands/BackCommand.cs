namespace StarterGame;
/*
 * BackCommand is used to take you back to the last room you've been in.
 * The method used is implemented in the player class
 */
public class BackCommand : Command
{

    public BackCommand() : base()
    {
        this.Name = "back";
    }

    override
        public bool Execute(Player player)
    {
        if (this.HasSecondWord())
        {
            player.OutputMessage("\nI cannot back" + this.SecondWord + "");
        }
        else
        {
            player.Back();
        }
        return false;
    }
}
