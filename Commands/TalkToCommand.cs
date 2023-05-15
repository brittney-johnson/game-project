namespace StarterGame;
/*
 * TalkToCommand is used to talk to Npc characters in the game
 */
public class TalkToCommand : Command
{
    public TalkToCommand() : base()
    {
        this.Name = "talkto";
    }

    override
        public bool Execute(Player player)
    {
        if (this.HasSecondWord())
        {
            player.TalkTo(this.SecondWord);
        }
        else
        {
            player.OutputMessage("\nTalk to who?");
        }

        return false;
    }
}