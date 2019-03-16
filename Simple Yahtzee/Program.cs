using System;

namespace Simple_Yahtzee
{
    class Program
    {
        public static void Main(string[] args)
        {

            int keptDice = 0;            
            Console.WriteLine("Welcome to a basic game of Yahtzee dice.");
            Console.WriteLine("The object of this game is to get a 2, 3, 4 or 5 of a kind. " +
                "Everytime you roll the dice you will be able to select which dice you would like to keep." +
                "You will get a total of 3 rolls.");
            Console.WriteLine("Please push enter to begin.");
            Console.ReadLine();

            Console.WriteLine(RollTheDice(keptDice));
            Console.WriteLine("Please select the dice you would like to keep." +
                "If there is more than one die then seperate with each one number with a ,"
                + " ie. 4,6,2");
            Console.ReadLine();

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
                return randomRoll[];                                                                     
         }
    }
}
