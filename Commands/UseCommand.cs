namespace StarterGame
{
    /*
     * UseCommand allows player to use an item which is then removed from inventory
     * It is implemented in the Player class
     */
    public class UseCommand : Command
    {
        public UseCommand() : base()
        {
            this.Name = "use";
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
                }
                player.Use(item);
            }
            else
            {
                player.OutputMessage("\nUse what?");
            }
            {
                if (this.HasFourthWord() && this.FourthWord != "engine")
                {
                    player.OutputMessage("\nUse " + this.SecondWord +" "+ this.ThirdWord  + " on what?");
                }
                else
                {
                    player.Use(this.SecondWord + this.ThirdWord);
                    if (this.HasFourthWord() && this.FourthWord == "engine")
                    {
                        player.OutputMessage($"\nUsed {this.SecondWord +" "+ this.ThirdWord} on engine.");
                    }
                }
            }
            

            return false;
        }
    }
}