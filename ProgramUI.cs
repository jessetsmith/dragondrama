using System;
using System.Collections.Generic;

namespace DragonDrama
{
    class ProgramUI
    {

        Attack attack = new Attack();

        public enum Item { sword, shield, healingPotion, key, enchantmentCure };
        public List<Item> inventory = new List<Item>();

        Dictionary<string, Locations> LocationNames = new Dictionary<string, Locations>
        {
            {"rope bridge", ropeBridge },
            {"maze", maze },
            {"maze straight", mazeStraight },
            {"maze right", mazeRight },
            {"courtyard", courtyard },
            {"dragon's lair", dragonsLair },
            {"tower", tower },
            {"escape lair", escapeLair },
            {"dungeon trap", dungeonTrap },
            {"dungeon stairs", dungeonStairs },
            {"skeleton trap", skeletonTrap },
            {"stairway", stairway },
            {"princess' room", princessRoom }

        };

        public static Locations bridgeStart = new Locations(
            "\n\n\n\n\nYou are at the start of a harrowing rope bridge\n" +
            "The wooden boards are breaking, and many are missing, forming gaping gaps\n" +
            "Below you is a ravine filled with flowing molten lava\n" +
            "\n" +
            "Tread carefully\n" +
            "\n",
            new List<string> { "rope bridge" });

        public static Locations ropeBridge = new Locations(
            "\n\n\n\n\nYou have started to cross the bridge\n" +
            "You may step forward one or two boards\n" +
            "\n" +
            "Choose wisely\n" +
            "\n",
            new List<string> { "step one", "step two" });

        public static Locations maze = new Locations(
           "\n\n\n\n\nYou have made it safely across the bridge, but now before you lies a large maze\n" +
           "There are three paths you may take\n" +
           "One left, one straight, and one to your right\n" +
           "Choose wisely\n" +
            "\n",
           new List<string> { "courtyard", "maze straight", "maze right" });

        public static Locations mazeStraight = new Locations(
          "\n\n\n\n\nYou move straight ahead of you\n" +
          "The path winds, and you come to a dead end\n" +
          "You must turn around and return to the entrance\n" +
          "\n",
          new List<string> {"maze"});

        public static Locations mazeRight = new Locations(
          "\n\n\n\n\nYou move to the right path of the maze\n" +
          "The path winds, and you come to a dead end, but find a treasure chest\n" +
          "You open the chest and find a key\n" +
          "You take the key, but now you must turn around and return to the entrance\n" +
            "\n",
          new List<string> {"maze" });

        public static Locations courtyard = new Locations(
            "\n\n\n\n\nYou have exited the maze and entered a courtyard\n" +
            "Before you are three paths \n" +
            "One to youre left, one straight ahead, and one to your right \n" +
            "\n" +
            "Choose wisely\n" +
            "\n",
            new List<string> { "dragon's lair", "lava trap", "tower" });

        public static Locations dragonsLair = new Locations(
            "\n\n\n\n\nOh no, you have entered into the dragon's lair\n" +
            "There are mounds and mounds of treasure, and a giant, sleeping dragon guarding it\n" +
            "You move to escape, or try and pick up some treasure before you leave\n" +
            "\n" +
            "What do you choose?\n" +
            "\n",
            new List<string> { "escape lair", "lair trap" });

        public static Locations escapeLair = new Locations(
            "\n\n\n\n\nYou have safely escaped the dragon's lair\n" +
            "You have two pathways before you\n" +
            "One to your left, and one straight ahead\n" +
            "\n" +
            "Choose wisely\n" +
            "\n",
            new List<string> { "lava trap", "tower" });

        public static Locations tower = new Locations(
            "\n\n\n\n\nYou have entered into a looming tower\n" +
            "Before you are three paths \n" +
            "One to youre left, one straight ahead, and one to your right \n" +
            "\n" +
            "Choose wisely\n" +
            "\n",
            new List<string> { "dungeon trap", "skeleton trap", "stairway" });

        public static Locations dungeonTrap = new Locations(
           "\n\n\n\n\nYou have fallen through a trap door into a dark dungeon\n" +
           "If you have obtained the key, you may escape \n" +
           "If you have not obtained the key, you will be stuck here forever \n" +
           "\n",
           new List<string> { "dungeon exit" });

        public static Locations dungeonStairs = new Locations(
          "\n\n\n\n\nBecause you had the key, you have escaped the dungeon\n" +
          "The stairway leading out is a long, tiring journey\n" +
          "On your path you find a vial of a potion. You pick it up just to be safe\n" +
          "But at the end you reach a doorway, where you can see the princess asleep in her bed \n" +
          "Move to step inside" +
          "\n",
          new List<string> { "princess' room" });

        public static Locations skeletonTrap = new Locations(
          "\n\n\n\n\nYou have come upon a room of skeletons\n" +
          "Upon entrance the skeletons reveal they are enchanted, and rise up towards you \n" +
          "You can choose to fight or run \n" +
          "\n" +
          "Choose wisely\n" +
            "\n",
          new List<string> { "skeleton escape", "skeleton fight" });

        public static Locations stairway = new Locations(
            "\n\n\n\n\nYou have taken a path that leads you to a large staircase\n" +
            "As you make your way up, you come to a split\n" +
            "Which way do you go: left or right?\n" +
            "\n",
            new List<string> { "princess' room", "stairway trap" });

        public static Locations princessRoom = new Locations(
            "\n\n\n\n\nYou have found the princess lying asleep in her bed\n" +
            "But she does not wake at your beckon, so you determine she is under a curse\n" +
            "If you have obtained the potion, you will be able to rescue her\n" +
            "If you have not obtained the potion, your journey as been all for naught\n" +
            "\n",
            new List<string> { });

        public void Run()
        {

            Console.WriteLine("\n" +
                "DRAGON DRAMA\n" +
                "\n" +
                "You have accepted the quest to save the princess from the dragon's lair!\n" +
                "The journey will be perilous, and you must make the right choices in order to succeed.\n" +
                "Good luck and godspeed, brave knight!\n" +
                "\n" +
                "** Movement commands: move, go, turn, step (Pair with the right keywords to progress through the game) **\n" +
                "\n" +
                "**Press any key to continue**\n" +
                "\n");

            Console.ReadKey();
            Console.Clear();

            Locations currentLocation = bridgeStart;


            bool alive = true;
            bool gameInProgress = true;

            //Game runs until alive = false; 
            while (alive && gameInProgress)
            {
                Console.Clear();

                Console.WriteLine(currentLocation.Location);

                string command = Console.ReadLine().ToLower();


                //Movement
                if (command.StartsWith("go") || command.StartsWith("move") || command.StartsWith("step") || command.StartsWith("turn"))
                {
                        if (currentLocation == bridgeStart && command.Contains("bridge") || command.Contains("rope bridge") || command.Contains("forward"))
                        {
                            currentLocation = ropeBridge;
                 
                        }
                        else if (currentLocation == ropeBridge && command.Contains("one"))
                        {
                            currentLocation = maze;
                        }
                        else if (currentLocation == ropeBridge && command.Contains("two"))
                    {
                        Console.WriteLine("A board breaks beneath you, and you fall to your death.\n" +
                              "GAME OVER\n" +
                              "\n");
                        Console.WriteLine("Do you want to play again ?\n" +
                              "Type yes or no\n" +
                              "\n");
                        string playAgain = Console.ReadLine();
                        
                        if (playAgain == "yes")
                        {
                            currentLocation = bridgeStart;
                        }else if (playAgain == "no"){
                            alive = false;
                        }
                        }
                        else if (currentLocation == maze && command.Contains("left"))
                        {
                            currentLocation = courtyard;
                        }
                        else if (currentLocation == maze && command.Contains("straight"))
                        {
                            currentLocation = mazeStraight;
                        }
                        else if (currentLocation == mazeStraight && command.Contains("around") || command.Contains("back"))
                        {
                            currentLocation = maze;
                        }
                        else if (currentLocation == maze && command.Contains("right"))
                        {
                            currentLocation = mazeRight;
                            inventory.Add(Item.key);
                        }
                        else if (currentLocation == mazeRight && command.Contains("turn around") || command.Contains("back") || command.Contains("return"))
                        {
                            currentLocation = maze;
                        }
                        else if (currentLocation == courtyard && command.Contains("left"))
                        {
                            currentLocation = dragonsLair;
                        }
                        else if (currentLocation == dragonsLair && command.Contains("escape") || command.Contains("go back") || command.Contains("run"))
                        {
                            currentLocation = escapeLair;
                        }
                        else if (currentLocation == dragonsLair && command.Contains("treasure"))
                        {
                            Console.WriteLine("You have awakened the dragon!\n" +
                                "Your last sight is a fiery inferno rushing towards you\n" +
                                "GAME OVER\n" +
                                "\n");
                        Console.WriteLine("Do you want to play again ?\n" +
                             "Type yes or no\n" +
                             "\n");
                        string playAgain = Console.ReadLine();

                        if (playAgain == "yes")
                        {
                            currentLocation = bridgeStart;
                        }
                        else if (playAgain == "no")
                        {
                            alive = false;
                        }

                        }
                        else if (currentLocation == escapeLair && command.Contains("left"))
                        {
                            Console.WriteLine("The floor beneath you crumbles, and you fail to grab ahold of anything to stop your fall.\n" +
                                "You plummet to a fiery pit of lava.\n" +
                                "GAME OVER\n" +
                                "\n");
                        Console.WriteLine("Do you want to play again ?\n" +
                                                     "Type yes or no\n" +
                                                     "\n");
                        string playAgain = Console.ReadLine();

                        if (playAgain == "yes")
                        {
                            currentLocation = bridgeStart;
                        }
                        else if (playAgain == "no")
                        {
                            alive = false;
                        }
                    }
                        else if (currentLocation == escapeLair && command.Contains("straight"))
                        {
                            currentLocation = tower;
                        }
                        else if (currentLocation == courtyard && command.Contains("straight"))
                        {
                            Console.WriteLine("The floor beneath you crumbles, and you fail to grab ahold of anything to stop your fall.\n" +
                                "You plummet to a fiery pit of lava.\n" +
                                "GAME OVER\n" +
                                "\n");
                        Console.WriteLine("Do you want to play again ?\n" +
                                                     "Type yes or no\n" +
                                                     "\n");
                        string playAgain = Console.ReadLine();

                        if (playAgain == "yes")
                        {
                            currentLocation = bridgeStart;
                        }
                        else if (playAgain == "no")
                        {
                            alive = false;
                        }
                    }
                        else if (currentLocation == courtyard && command.Contains("right"))
                        {
                            currentLocation = tower;
                        }
                        else if (currentLocation == tower && command.Contains("left"))
                        {
                            currentLocation = dungeonTrap;
                        }
                        else if (currentLocation == dungeonTrap && inventory.Contains(Item.key))
                        {
                            currentLocation = dungeonStairs;
                            inventory.Add(Item.enchantmentCure);
                        }
                        else if (currentLocation == dungeonStairs && command.Contains("move"))
                        {
                            currentLocation = princessRoom;
                        }
                        else if (currentLocation == dungeonTrap && !inventory.Contains(Item.key))
                        {
                            Console.WriteLine("You do not have the key in your inventory \n" +
                                "You will remain locked away for the remainder of your life\n" +
                                "GAME OVER\n" +
                                "\n");
                        Console.WriteLine("Do you want to play again ?\n" +
                                                     "Type yes or no\n" +
                                                     "\n");
                        string playAgain = Console.ReadLine();

                        if (playAgain == "yes")
                        {
                            currentLocation = bridgeStart;
                        }
                        else if (playAgain == "no")
                        {
                            alive = false;
                        }
                    }
                        else if (currentLocation == tower && command.Contains("straight"))
                        {
                            currentLocation = skeletonTrap;
                        }
                        else if (currentLocation == skeletonTrap && command.Contains("escape") || command.Contains("run"))
                        {
                            currentLocation = tower;
                        }
                        else if (currentLocation == skeletonTrap && command.Contains("fight") || command.Contains("attack"))
                        {
                            //attack.attackoption();

                            if (attack.attackoption() == true)
                        {
                            attack.attackdraw();
                            if (attack.attackSuccess() == true)
                            {
                                Console.WriteLine("You fight and defeat the enchanted skeletons, and they drop a vial of a potion\n" +
                                                                "You pick it up just to be safe, and return to the tower entrance.\n" +
                                                                "Type any key to continue\n" +
                                                                "\n");
                                inventory.Add(Item.enchantmentCure);
                                Console.ReadKey();
                                currentLocation = tower;
                            }
                            else if (attack.attackSuccess() == false)
                            {
                                Console.WriteLine("You fight valiantly, but you have been defeated by your enemy!\n" +
                                    "GAME OVER\n" +
                                    "\n");
                                Console.WriteLine("Do you want to play again ?\n" +
                             "Type yes or no\n" +
                             "\n");
                                string playAgain = Console.ReadLine();

                                if (playAgain == "yes")
                                {
                                    currentLocation = bridgeStart;
                                }
                                else if (playAgain == "no")
                                {
                                    alive = false;
                                }
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("You return to the tower entrance\n" +
                                "Press any key");
                            Console.ReadKey();
                            currentLocation = tower;
                        }
                    }
                        else if (currentLocation == tower && command.Contains("right"))
                        {
                            currentLocation = stairway;
                        }
                        else if (currentLocation == stairway && command.Contains("left"))
                        {
                            currentLocation = dungeonTrap;
                            
                        }
                        else if (currentLocation == stairway && command.Contains("right"))
                        {
                            currentLocation = princessRoom;

                        }
                    else if (currentLocation == tower && command.Contains("right"))
                        {
                            currentLocation = princessRoom;
                        }
                        else if (currentLocation == princessRoom && inventory.Contains(Item.enchantmentCure))
                        {
                            Console.WriteLine("The princess is cured, but the dragon has awakened and you must fight to escape!");
                        if (attack.attackoption() == true)
                        {
                            attack.attackdraw();
                            if (attack.attackSuccess() == true)
                            {
                                Console.WriteLine("You fight and defeat the mighty dragon, and the princess has been rescued!\n" +
                                                                "You have completed your quest, and returned to the king for your reward\n" +
                                                                "YOU HAVE WON");
                              
                                Console.ReadKey();
                               gameInProgress = false;
                            }
                            else if (attack.attackSuccess() == false)
                            {
                                Console.WriteLine("You fight valiantly, but you have been defeated by your enemy the dragon!\n" +
                                    "GAME OVER\n" +
                                    "\n");
                                Console.WriteLine("Do you want to play again ?\n" +
                             "Type yes or no\n" +
                             "\n");
                                string playAgain = Console.ReadLine();

                                if (playAgain == "yes")
                                {
                                    currentLocation = bridgeStart;
                                }
                                else if (playAgain == "no")
                                {
                                    alive = false;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("You have chosen not to fight.\n" +
                                "The dragon has fried you to a crisp.\n" +
                                "GAME OVER\n" +
                                "\n");
                            Console.WriteLine("Do you want to play again ?\n" +
                              "Type yes or no\n" +
                              "\n");
                            string playAgain = Console.ReadLine();

                            if (playAgain == "yes")
                            {
                                currentLocation = bridgeStart;
                            }
                            else if (playAgain == "no")
                            {
                                alive = false;
                            }
                        }
                        Console.ReadKey(); 
                            gameInProgress = false;

                    }
                    else if (currentLocation == princessRoom && !inventory.Contains(Item.enchantmentCure))
                        {
                            alive = false;
                            Console.WriteLine("You have failed to rescue the princess\n" +
                               "GAME OVER!\n" +
                               "\n");
                        Console.WriteLine("Do you want to play again ?\n" +
                         "Type yes or no\n" +
                         "\n");
                        string playAgain = Console.ReadLine();

                        if (playAgain == "yes")
                        {
                            currentLocation = bridgeStart;
                        }
                        else if (playAgain == "no")
                        {
                            alive = false;
                        }
                    }
                        else
                        {
                            Console.WriteLine("Your choices weren't understood, please try again.");
                        }
                   
                }

                //Pickup items 
               else if (command.StartsWith("get") || command.StartsWith("grab") || command.StartsWith("take"))
                {

                }

                //Actions/use items
                else if (command.StartsWith("use") || command.StartsWith("activate") || command.StartsWith("deploy") || command.StartsWith("attack"))
                {

                }



            }
        }
    }
}
