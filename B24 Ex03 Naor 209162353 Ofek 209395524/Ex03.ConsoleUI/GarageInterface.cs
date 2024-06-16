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
            getVehicleTypeNumber();
        }

        private void printWelcome()
        {
            Console.WriteLine("welcome to laGarage");
        }

        private void printGarageMenu() // make it dynamic
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
                    addNewVehicle();
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
            string licensePlate = GetLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlate))
            {
                Console.WriteLine("The vehicle is already in the garage");
                m_Garage.ChangeVehicleStatusToInRepair(licensePlate);
            }
            else
            {
                int vechicleTypeInputNumber = getVehicleTypeNumber();

                Console.WriteLine("Please enter the owner's name:");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please enter the owner's phone number:");
                string ownerPhoneNumber = Console.ReadLine();
                m_Garage.AddNewVehicleToGarage(licensePlate, vechicleTypeInputNumber, ownerName, ownerPhoneNumber);

            }
        }


        private int getVehicleTypeNumber()
        {
            string vechicleTypeInputString;
            int vechicleTypeInputNumber;
            Console.WriteLine("vehicle types: ");
            PrintList(m_Garage.GetVehicleTypeList(), i_IsListNumbered: true);
            Console.WriteLine("PLease enter the vehicle's type: ");
            while(true)
            {
                vechicleTypeInputString = Console.ReadLine();
                if(!m_Garage.CheckVehicleTypeInputValidation(vechicleTypeInputString, out vechicleTypeInputNumber))
                {
                    Console.WriteLine("invalid input, try again");
                }
                else
                {
                    break;
                }
            }
            return vechicleTypeInputNumber;
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

        public string GetLicensePlateNumber()
        {
            string licenseNumberString;
            Console.WriteLine("please enter your license number:");
            while (true)
            {
                licenseNumberString = Console.ReadLine();
                if (CheckInputValidation(licenseNumberString))
                {
                    break;
                }
                Console.WriteLine("valid input please");
            }
            return licenseNumberString;
        }

        public bool CheckInputValidation(string i_LicenseNumberString)
        {
            bool isValid = i_LicenseNumberString.Length == 8; // could be also 7, or 6 for vintage for ex... 

            if (isValid)
            {
                foreach (char c in i_LicenseNumberString)
                {
                    if (!char.IsDigit(c) && !char.IsUpper(c))
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
