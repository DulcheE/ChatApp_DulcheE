using System;
using System.Collections.Generic;
using System.Threading;

namespace Front_Console
{
    /// <summary>
    /// This Class serves to ask the user to make his choice amongs a list of proposals.
    /// </summary>
    public static class ChoiceSelection
    {

        /// <summary>
        /// Structure of a Choice : a message and several propositions
        /// </summary>
        public class Choice
        {
            public string message;
            public List<string> choices;

            public Choice(string message, List<string> choices)
            {
                this.message = message;
                this.choices = choices;
            }
        }



        
        
        private static int MIN = 0;
        private static int MAX;


        public static int GetChoice(Choice choice, string username, string topic)
        {
            // We initialize our variables
            ConsoleKeyInfo input;
            int value = 0;
            MAX = choice.choices.Count - 1;



            // While the user doesn't press Enter, the loop continues
            do
            {
                //We lock the Console until we display the menu
                Console.Clear();

                ConsoleManager.PrintTrack();
                Console.WriteLine();

                //We display the username of the client
                ConsoleManager.Write(ConsoleColor.Gray, "[" + Thread.CurrentThread.Name + "] Connected as : ");

                if (username == null)
                    ConsoleManager.WriteLine(ConsoleColor.Red, "NOT CONNECTED");
                else
                    ConsoleManager.WriteLine(ConsoleColor.Green, username);

                //We display the topic of the client
                ConsoleManager.Write(ConsoleColor.Gray, "[" + Thread.CurrentThread.Name + "] Focus on the topic : ");

                if (topic == null)
                    ConsoleManager.WriteLine(ConsoleColor.Red, "NOT CONNECTED");
                else
                    ConsoleManager.WriteLine(ConsoleColor.Green, topic);


                // We display a given message
                ConsoleManager.WriteLine(ConsoleColor.Gray, "[" + Thread.CurrentThread.Name + "] " + choice.message + "\n\n");


                // We display all our choices (and we highlight the current choice)
                int index = 0;
                ConsoleColor color = ConsoleColor.White;

                foreach (string s in choice.choices)
                {
                    if (index == value)
                        Console.Write("     --> ");
                    else
                        Console.Write("         ");

                    // We change the color to Blue if we reach the final statement (usually one saying "Go back" or "Log out")
                    if(index == MAX)
                    {
                        color = ConsoleColor.Blue;
                    }
                    
                    ConsoleManager.WriteLine(color, choice.choices[index++] + "\n");
                }


                // We read the input
                input = Console.ReadKey();


                // If it is a key (Up or Down), we modify our choice accordingly
                if (input.Key == ConsoleKey.UpArrow)
                    value--;
                if (input.Key == ConsoleKey.DownArrow)
                    value++;
                if (input.Key == ConsoleKey.LeftArrow)
                    value = 0;
                if (input.Key == ConsoleKey.RightArrow)
                    value = MAX;


                // If the value goes too low / too high, it goes to the other extreme
                if (value < MIN)
                    value = MAX;
                if (value > MAX)
                    value = MIN;
            }
            while (input.Key != ConsoleKey.Enter);


            // We return the value
            return value;
        }
    }
}