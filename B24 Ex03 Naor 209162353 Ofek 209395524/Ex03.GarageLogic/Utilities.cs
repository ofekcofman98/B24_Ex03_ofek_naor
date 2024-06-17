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

        public static List<string> GetEnumKeys(Type enumType) // from Vehicle
        {
            string[] keys = Enum.GetNames(enumType);

            return new List<string>(keys);
        }

        public static int EnumChoosing(string i_EnumTitle, List<string> i_EnumList)
        {
            Console.WriteLine($"Please enter {i_EnumList}: ");
            PrintList(i_EnumList, i_IsListNumbered: true);
            int i_Choice;
            while (true)
            {
                string choiceString = Console.ReadLine();
                int.TryParse(choiceString, out i_Choice);

                if (!(i_Choice >= 1 && i_Choice <= i_EnumList.Count))
                {
                    Console.WriteLine($"Invalid input. Please input a number between 1 and {i_EnumList.Count}");
                }
                else
                {
                    break;
                }
            }

            return i_Choice;
        }

        /*
         *            Console.WriteLine($"Please enter {k_DoesCarryHazardousMaterials} (y/n)");
           string userChoice = Console.ReadLine().ToLower();
           while (userChoice != "y" && userChoice != "n")
           {
               Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
               userChoice = Console.ReadLine().ToLower();
           }

           if (userChoice == "n")
           {
               List<int> licensePlates = m_Garage.GetLicensePlatesList();
               PrintList(licensePlates);
           }
           else
           {
               displayFilteredLicensePlatesinGarage();
           }

         *
         */


    }
}
