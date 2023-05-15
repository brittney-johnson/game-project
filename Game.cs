using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Game
    {
        Player player;
        Parser parser;
        bool playing;

        
        public Game()
        {
            playing = false;
            parser = new Parser(new CommandWords());
            player = new Player(GameWorld.Instance.Entrance);
        }
        

     
        public void Play()
        {
            bool finished = false;
            player.State = Player.PlayerState.Playing;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = parser.ParseCommand(Console.ReadLine());
                if (command != null)
                {
                    finished = command.Execute(player);
                    switch (player.State)
                    {
                        case Player.PlayerState.Playing:
                            break;
                        case Player.PlayerState.Lost:
                            player.OutputMessage("You lost you could not win");
                            End();
                            break;
                        case Player.PlayerState.Won:
                            player.OutputMessage("You repaired the ship before the aliens destroyed your only way back home!\n ***YOU WIN***");
                            End();
                            break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("What?");
                }
            }
        }


        
        public void Start()
        {
            playing = true;
            player.OutputMessage(Welcome());
        }

        
        public void End()
        {
            playing = false;
            player.OutputMessage(Goodbye());
        }

        
        public string Welcome()
        {
            return "Welcome to Beyond the Stars, a science fiction adventure where you are the hero. \nIn this game, you have been chosen to complete a crucial mission. \nYour spaceship crash landed on strange planet. \nYou must find a way to repair the ship and survive the alien environment before they destroy it. \nUse your wits, skills, and equipment to overcome dangerous obstacles and achieve your mission objectives. \nGoodluck.\nType 'help' if you need help. \n\n" + player.CurrentRoom.Description();
        }

        
        public string Goodbye()
        {
            return "\nThank you for playing Beyond the Stars, Goodbye. \n";
        }

    }
}
