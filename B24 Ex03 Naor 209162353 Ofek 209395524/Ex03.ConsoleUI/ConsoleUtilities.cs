using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public static class ConsoleUtilities
    {
        private const int k_FirstIndex = 1;
        public static void PrintList<T>(List<T> i_List, bool i_IsListNumbered = false)  
        {
            int index = k_FirstIndex;
            foreach (T item in i_List)
            {
                if (i_IsListNumbered)
                {
                    Console.WriteLine($"{index}. {item}");
                    index++;
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static List<string> GetEnumKeys(Type i_EnumType) 
        {
            string[] keys = Enum.GetNames(i_EnumType);

            return new List<string>(keys);
        }

        public static void PrintInputRequest(string i_String)
        {
            Console.WriteLine($"Please enter {i_String}: ");
        }

        public static int ChooseFromEnumList(List<string> i_EnumList)
        {
            string choiceString = Console.ReadLine();
            
            if(!int.TryParse(choiceString, out int choice))
            {
                throw new FormatException(message: "Invalid input, please enter integer");
            }

            if (!(choice >= 1 && choice <= i_EnumList.Count))
            {
                throw new ArgumentException($"Invalid input. Please input a number between 1 and {i_EnumList.Count}");
            }

            return choice;
        }

        public static bool GetYesOrNoFromUser(string i_Question)
        {
            Console.WriteLine($"{i_Question} (y/n)");
            string userChoice = Console.ReadLine().ToLower();

            if (userChoice != "y" && userChoice != "n")
            {
                throw new FormatException("Invalid input. Please enter 'y' or 'n'.");
            }

            return userChoice == "y";
        }
        
        public static string GetValidatedString(string i_Prompt)
        {
            Console.WriteLine(i_Prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be empty or whitespace");
            }

            return input;
        }

        public static string GetValidatedPhoneNumber(string i_Prompt)
        {
            Console.WriteLine(i_Prompt);
            string input = Console.ReadLine();
            if (!long.TryParse(input, out _))
            {
                throw new FormatException("Phone number must be numeric");
            }

            return input;
        }

        public static float GetValidatedFloat(string i_Prompt)
        {
            Console.WriteLine(i_Prompt);
            string input = Console.ReadLine();
            if (!float.TryParse(input, out float result))
            {
                throw new FormatException("Invalid input, please enter a float.");
            }

            return result;
        }

        public static string PrintBuffer()
        {
            return "-----------------------------------------------------------------------\n";
        }   

        public static int GetValidatedInteger(string i_Prompt)
        {
            Console.Write(i_Prompt);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int result))
            {
                throw new FormatException("Invalid input, please enter an integer.");
            }

            return result;
        }
    }
}

