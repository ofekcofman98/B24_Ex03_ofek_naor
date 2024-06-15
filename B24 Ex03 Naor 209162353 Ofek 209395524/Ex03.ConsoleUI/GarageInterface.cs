using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageInterface
    {
        private Garage m_Garage = new Garage();

        private enum eMenuOptions
        {
            AddNewVehicle = 1,
            DisplayLicensePlates = 2, // 
            ChangeVehicleStatus = 3,
            InflationToMaximum = 4,
            RefuelVehicleTank = 5,
            ChargeVehicleBattery = 6,
            DisplayVehicleFullInfo = 7
        }

        public void GarageRun()
        {
            printWelcome();
            printGarageMenu();
            getMenuChoice();
            getVehicleType();
        }

        private void printWelcome()
        {
            Console.WriteLine("welcome to laGarage");
        }

        private void printGarageMenu()
        {
            string garageMenu = string.Format(@"
Garage System Menu:
-----------------------------------------------------------------------
1. Add a new vehicle.
2. Display the license plates of all vehicles.
3. Change a vehicle status.
4. Inflate wheels' air pressure to maximum.
5. Refuel vehicle's tank.
6. Recharge vehicle's battery.
7. Display a vehicle information by a license plate.
8. Exit garage system.
-----------------------------------------------------------------------
Please enter the number corresponding to your choice: ");
        }

        private int getMenuChoice()
        {
            string i_MenuChoiceString = Console.ReadLine();
            int i_MenuChoice = 0;
            int.TryParse(i_MenuChoiceString, out i_MenuChoice);
            // validation
            return i_MenuChoice;
        }

        private void addNewVehicle()
        {
            int i_LicenseNumber = GetLicenseNumber();

            if (m_Garage.IsVehicleInGarage(i_LicenseNumber))
            {
                Console.WriteLine("The vehicle is already in the garage");
                // change status to - "under repair"
            }
            else
            {
                
            }
        }

        private string getVehicleType()
        {
            string i_vechicleInput;
            Console.WriteLine("vehicle types: ");
            PrintList(Garage.GetVehicleTypeList(), i_IsListNumbered: true);
            Console.WriteLine("PLease enter the vehicle's type: ");
            while(true)
            {
                i_vechicleInput = Console.ReadLine();
                // first validation
                // is in garage validation
                if(!Garage.CheckVehicleTypeInputValidation(i_vechicleInput))
                {
                    Console.WriteLine("invalid input, try again");
                }
                else
                {
                    break;
                }
            }
            return i_vechicleInput;
        }

        public static void PrintList<T>(List<T> i_List, bool i_IsListNumbered = false)
        {
            int i = 1;
            foreach(T item in i_List)
            {
                if(i_IsListNumbered)
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

        public int GetLicenseNumber()
        {
            int i_LicenseNumber = 0;
            Console.WriteLine("please enter your license number:");
            while (true)
            {
                string i_LicenseNumberString = Console.ReadLine();
                if (CheckInputValidation(i_LicenseNumberString))
                {
                    int.TryParse(i_LicenseNumberString,out i_LicenseNumber);
                    break;
                }
                Console.WriteLine("valid input please");
            }
            return i_LicenseNumber;
        }

        public bool CheckInputValidation(string i_LicenseNumberString)
        {
            bool isValid = false;
            if(i_LicenseNumberString.Length == 9) // change 9 to k_
            {
                isValid = true;
                foreach (char c in i_LicenseNumberString)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                        break;
                    }
                }
            }
            return isValid;
        }
    }
}
