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
    public class GarageInterface
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
            DisplayVehicleFullInfo = 7,
            ExitSystem = 8
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
            string menuChoiceString = Console.ReadLine();
            int.TryParse(menuChoiceString, out int menuChoice);
            // validation
            return menuChoice;
        }

        private void userMenuChoiceManager(eMenuOptions i_MenuChoice)
        {
            switch (i_MenuChoice)
            {
                case eMenuOptions.AddNewVehicle:
                    //
                    break;
                case eMenuOptions.DisplayLicensePlates:
                    //
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    //
                    break;
                case eMenuOptions.InflationToMaximum:
                    //
                    break;
                case eMenuOptions.RefuelVehicleTank:
                    //
                    break;
                case eMenuOptions.ChargeVehicleBattery:
                    //
                    break;
                case eMenuOptions.DisplayVehicleFullInfo:
                    //
                    break;
                case eMenuOptions.ExitSystem:
                    //
                    break;
            }
        }

        private void addNewVehicle()
        {
            int licenseNumber = GetLicenseNumber();

            if (m_Garage.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("The vehicle is already in the garage");
                // change status to - "under repair"
            }
            else
            {
                getVehicleType();
            }
        }

        private string getVehicleType()
        {
            string vechcleInput;
            Console.WriteLine("vehicle types: ");
            PrintList(Garage.GetVehicleTypeList(), i_IsListNumbered: true);
            Console.WriteLine("PLease enter the vehicle's type: ");
            while(true)
            {
                vechcleInput = Console.ReadLine();
                // first validation
                // is in garage validation
                if(!Garage.CheckVehicleTypeInputValidation(vechcleInput))
                {
                    Console.WriteLine("invalid input, try again");
                }
                else
                {
                    break;
                }
            }

            return vechcleInput;
        }

        public static void PrintList<T>(List<T> i_List, bool i_IsListNumbered = false) // Fix names
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
            int licenseNumber = 0;
            Console.WriteLine("please enter your license number:");
            while (true)
            {
                string licenseNumberString = Console.ReadLine();
                if (CheckInputValidation(licenseNumberString))
                {
                    int.TryParse(licenseNumberString, out licenseNumber);
                    break;
                }
                Console.WriteLine("valid input please");
            }

            return licenseNumber;
        }

        public bool CheckInputValidation(string i_LicenseNumberString)
        {
            bool isValid = i_LicenseNumberString.Length == 8; // could be also 7, or 6 for vintage for ex... 

            if (isValid)
            {
                foreach (char c in i_LicenseNumberString)
                {
                    if (!char.IsDigit(c))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
