using System;


namespace Simple_Yahtzee
{
    class Program
    {
        public static void Main(string[] args)
        { //myarray.cacant.newarray.toarray
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("1) Play Yahtzee");
            Console.WriteLine("2) Instructions");
            Console.WriteLine("3) Quit");
            string userSelection = Console.ReadLine();
            if (userSelection == "1" )
            {
                Yahtzee();
                return true;
            }
            else if (userSelection == "2")
            {
                Instructions();
                return true;
            }
            else if (userSelection == "3")
                return false;
            return true;

        }

        /// <summary>
        /// Instructions for playing the game.
        /// </summary>
        public static void Instructions()
        {   

            Console.WriteLine("The object of this game is to get a 2, 3, 4 or 5 of a kind." +
                "/EEverytime you roll the dice you will be able to select which dice you would like to keep." +
                "/YYou will get a total of 3 rolls.");
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("1) Play Yahtzee");
            Console.WriteLine("2) Main Menu");
            Console.WriteLine("3) Quit");
            int userSelection = Console.Read();
            if (userSelection == 1)
                Yahtzee();
            else if (userSelection == 2)
                MainMenu();            
            else if (userSelection == 3)
                return;
        }
       
        public static void Yahtzee()
        {
            Console.Clear();
            int keptDice = 0;
            int userSelection = 0;
            Console.WriteLine("Welcome to a basic game of Yahtzee dice.");
            Console.WriteLine("Player One, please enter your name");
            string playerOne = Console.ReadLine();
            Console.WriteLine($"{playerOne} press enter to roll the dice.");
            Console.WriteLine();
            Console.ReadLine();
            int[] rolledDice = RollTheDice(keptDice);
            foreach (int roll in rolledDice)
            {
                Console.Write(roll);
                Console.Write(", ");
            }            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please select the die you would like to keep. " +
                "If there is more than one die then seperate each number with a \",\""
                + " ie. if the dice came up 4, 6, 2, 1, 2. You can enter 2,2 for what you would like to keep ");
            string userInput = Console.ReadLine();       
                
            // Look up how to use split and join. If statements will allow you to see if their numbers are correct or not. 
            //get the kept number of dice by calculating the length of the array the user made.
            //

        }

        public static int[] RollTheDice(int keptDice)
        {
            int numberOfDice = 5 - keptDice;
            int[] randomRoll = new int[numberOfDice];
            for (int i = 0; i < randomRoll.Length; i++)
            {
                int die = new Random().Next(1, 7);
                randomRoll[i] = die;
            }
            return randomRoll;
        }

        public static int ChoosenDie(userInput)
        {



        }




    }





}
