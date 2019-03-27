using System;



namespace Simple_Yahtzee
{
    class Program
    {
        public static object PlayersScore { get; private set; }

        public static void Main(string[] args)
        { //myarray.concat.newarray.toarray
            GameLoop();
        }

        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("1) Play Yahtzee");
            Console.WriteLine("2) Instructions");
            Console.WriteLine("3) Quit");
            string userSelection = Console.ReadLine();
            if (userSelection == "1")
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

        public static void GameLoop()
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        public static void Instructions()
        {
            Console.Clear();
            Console.WriteLine("" +
                            "\nObjective - The object of Simple Yahtzee is to obtain a score from throwing 5 dice" +
                            "\nThe game consists of 1 round, which contains a maximum of three rolls. To start" +
                            "\nwith, roll all the dice. After rolling you can either score the current roll " +
                            "\n(see below), or re-roll any or all of the dice. You may only roll the dice a total" +
                            "\nof 3 times. After rolling 3 times your score will be calculated. If you choose" +
                            "\nto keep all dice before the 3rd roll, your score wil be calculated then." +
                            "\ni.e. it doesn't have to be after the 3rd roll." +
                            "\n" +
                            "\nScoring - To gain points you must obtain one of the following:" +
                            "\n3 of a kind - 3 of a kind you must have at least 3 of the same die faces." +
                            "\n4 of a kind - 4 of a kind you must have at least 4 of the same die faces." +
                            "\nFull House - Full House you must have a 3 of a kind and 2 of a kind." +
                            "\nYahtzee - Yahtzee you must have at least 5 of the same die faces." +
                            "\n" +
                            "\nPoints are calculated as follows:" +
                            "\n2 of a kind  = 2 points total" +
                            "\n3 of a kind  = 3 points total" +
                            "\n4 of a kind  = 4 points total" +
                            "\nFull House   = 25 Points total" +
                            "\nYahtzee      = 50 points total");

            Console.WriteLine("Choose an Option:" +
                              "\n1) Play Yahtzee" +
                              "\n2) Main Menu");
            string userSelection = Console.ReadLine();
            if (userSelection == "1")
                Yahtzee();
            else if (userSelection == "2")
                MainMenu();
            return;
        }

        public static void Yahtzee()
        {
            Console.Clear();


            Console.WriteLine("Welcome to a basic game of Yahtzee dice." +
                "\n" +
                "\nPlayer One, please enter your name");
            string playerName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"{playerName} press enter to roll the dice.");
            Console.ReadLine();

            int keptDice = 0;
            string[] firstRoll = UserSelectsDice(RollTheDice(keptDice));
            keptDice = firstRoll.Length;

            Console.WriteLine();
            string[] secondRoll = RollTheDice(keptDice);
            secondRoll = UserSelectsDice(secondRoll);
            keptDice = firstRoll.Length + secondRoll.Length;

            Console.WriteLine();
            string[] thirdRoll = RollTheDice(keptDice);

            string[] seperators = { ",", " " };
            string firstStringRoll = string.Join(", ", firstRoll);
            string secondStringRoll = string.Join(", ", secondRoll);
            string thirdStringRoll = string.Join(", ", thirdRoll);
            string finalStringRoll = firstStringRoll + " " + secondStringRoll + " " + thirdStringRoll;
            string[] playersDice = finalStringRoll.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(playersDice);
            Console.WriteLine();
            Console.WriteLine($"Your final dice are: " + string.Join(", ", playersDice));
            Console.ReadLine();

            Console.WriteLine("Computer's turn, press Enter to continue");
            Console.ReadLine();

            string[] computersFirstRoll = RollTheDice(0);
            Array.Sort(computersFirstRoll);
            string[] computersSecondRoll = RollTheDice(0);
            Array.Sort(computersSecondRoll);
            string[] computersThirdRoll = RollTheDice(0);
            Array.Sort(computersThirdRoll);
            Console.WriteLine("The Computer's first roll: \n" +
                             string.Join(", ", computersFirstRoll) +
                             "\n" +
                             "\n" +
                             "\n The Computer's second roll: \n" +
                             string.Join(", ", computersSecondRoll) +
                             "\n" +
                             "\n" +
                             "\n The Computer's final roll: \n" +
                             string.Join(", ", computersThirdRoll));
            Console.ReadLine();
            int playersTalliedScore = Tallies(playersDice);
            int compsFirstTallied = Tallies(computersFirstRoll);
            int compsSecondTallied = Tallies(computersSecondRoll);
            int compsThirdTallied = Tallies(computersThirdRoll);
            int compsTalliedScore = Math.Max(Math.Max(compsFirstTallied, compsSecondTallied), compsThirdTallied);
            string winner = "";
            if (playersTalliedScore >= compsTalliedScore)
                winner = playerName;
            else
                winner = "the Computer";

            Console.WriteLine($"Your Final Score is ....  { playersTalliedScore}");
            Console.WriteLine($"The Computer's Final Score is .... {compsTalliedScore}");
            Console.WriteLine($"The winner is {winner}!");
            Console.ReadLine();
        }

        public static string[] RollTheDice(int keptDice)
        {
            int numberOfDice = 5 - keptDice;
            string[] randomRoll = new string[numberOfDice];
            for (int i = 0; i < randomRoll.Length; i++)
            {
                int die = new Random().Next(1, 7);
                randomRoll[i] = die.ToString();
            }
            Array.Sort(randomRoll);
            return randomRoll;
        }

        public static string[] UserSelectsDice(string[] rollDice)
        {
            int diceId = 0;
            int diceIndex = 0;
            Console.WriteLine("You rolled: \n" +
                string.Join(", ", rollDice) +
                "\n\nPress enter to continue.");
            Console.ReadLine();
            foreach (string roll in rollDice)
            {
                diceId++;
                Console.WriteLine();
                Console.WriteLine($"{diceId}) {roll}");
                Console.WriteLine("If you would like to keep this die, type the letter \"y\" and then enter." +
                                  "\nOtherwise, press enter to continue");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    rollDice[diceIndex] = string.Empty;
                }
                diceIndex++;
            }
            string[] separators = { " ", "," };
            string rollDiceString = string.Join(", ", rollDice);
            string[] heldDice = rollDiceString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return heldDice;
        }

        private static int KeptDiceReturn(string[] userDiceSelection)
        {
            int keptDice = 0;
            foreach (string roll in userDiceSelection)
                keptDice++;

            return keptDice;
        }

        private static int Tallies(string[] diceInput)
        {
            int tally = 1;
            string[] i = diceInput;


            if (i[0] == i[1] && i[1] == i[2] && i[2] == i[3] && i[3] == i[4])
                tally = 100;
            else if (i[0] == i[1] && i[1] == i[2] && i[3] == i[4] || i[0] == i[1] && i[1] == i[2] && i[2] == i[3] & i[3] == i[4])
                tally = 25;
            else if (i[0] == i[1] && i[1] == i[2] && i[2] == i[3] || i[1] == i[2] && i[2] == i[3] & i[3] == i[4])
                tally = 1 + 3;
            else if (i[0] == i[1] && i[1] == i[2] || i[1] == i[2]
                && i[2] == i[3] || i[2] == i[3] && i[3] == i[4])
                tally = 1 + 2;
            else if (i[0] == i[1] || i[1] == i[2] || i[2] == i[3]
                || i[3] == i[4])
                tally++;
            return tally;
        }


    }




}






