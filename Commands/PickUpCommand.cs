namespace StarterGame
{
    /*
     * PickUpCommand allows player to pick up items and store in inventory
     * It is implemented in the Player class
     */
    public class PickUpCommand : Command
    {
        public PickUpCommand() : base()
        {
            this.Name = "pickup";
        }

        override
            public bool Execute(Player player)
        {
            if (this.HasSecondWord())
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
                player.PickUp(item);
            }
            else
            {
                player.OutputMessage("\nPick up what?");
            }
            return false;
        }
    }
}