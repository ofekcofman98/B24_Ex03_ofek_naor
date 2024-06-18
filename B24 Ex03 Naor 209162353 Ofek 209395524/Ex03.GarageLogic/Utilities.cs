using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public static class Utilities
    {
        public static void PrintList<T>(List<T> i_List, bool i_IsListNumbered = false) // from InterFace 
        {
            int i = 1;
            foreach (T item in i_List)
            {
                if (i_IsListNumbered)
                {
                    Console.WriteLine($"{i}. {item}");
                    i++;
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
            int choice;
            string choiceString = Console.ReadLine();
            if(!int.TryParse(choiceString, out choice))
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

            while(userChoice != "y" && userChoice != "n")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                userChoice = Console.ReadLine().ToLower();
            }

            return userChoice == "y";
        }
    }
}

