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
            Console.WriteLine("Welcome to laGarage");
        }

        private void printGarageMenu() // make it dynamic
        {
            string garageMenu = string.Format(@"
Garage Menu:
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
            Console.WriteLine(garageMenu);

        }

        private int getMenuChoice()
        {
            string menuChoiceString = Console.ReadLine();
            int.TryParse(menuChoiceString, out int menuChoice);

            while(menuChoice < (int)eMenuOptions.AddNewVehicle || menuChoice > (int)eMenuOptions.ExitSystem) // k_
            {
                Console.WriteLine($"Invalid input. Please input a number between {eMenuOptions.AddNewVehicle} and {eMenuOptions.ExitSystem}");
                menuChoiceString = Console.ReadLine();
                int.TryParse(menuChoiceString, out menuChoice);
            }

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
                    displayLicensePlatesinGarage();
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eMenuOptions.InflationToMaximum:
                    inflateTiresToMaximum();
                    break;
                case eMenuOptions.RefuelVehicleTank:
                    refuelVehicle();
                    break;
                case eMenuOptions.ChargeVehicleBattery:
                    //
                    break;
                case eMenuOptions.DisplayVehicleFullInfo:
                    displayVehicleFullInfo();
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

            while (true)
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

            return vehicleInput;
        }

        private void displayLicensePlatesinGarage()
        {
            if(m_Garage.IsGarageEmpty())
            {
                printEmptyGarage();
            }
            else
            {
                Console.WriteLine("Do you want to filter the vehicles by status? (y/n)");
                string userChoice = Console.ReadLine().ToLower();
                while (userChoice != "y" && userChoice != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    userChoice = Console.ReadLine().ToLower();
                }

                if(userChoice == "n")
                {
                    List<int> licensePlates = m_Garage.GetLicensePlatesList();
                    PrintList(licensePlates);
                }
                else
                {
                    displayFilteredLicensePlatesinGarage();
                }
            }  

        }

        private void displayFilteredLicensePlatesinGarage()
        {
            Console.WriteLine("Filter by vehicles in repair (1), vehicles repaired (2) and vehicles that their repair was paid (3)");
            string userChoice = Console.ReadLine();
            int userPick;

            while (!int.TryParse(userChoice, out userPick) || (userChoice != "1" && userChoice != "2" && userChoice != "3") )
            {
                Console.WriteLine("Invalid input. Please enter (1), (2) or (3).");
                userChoice = Console.ReadLine();
            }

            List<int> licensePlates = m_Garage.GetLicensePlatesListByFilter(userPick);
            PrintList(licensePlates);


        }

        private void changeVehicleStatus()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                Console.WriteLine($"The current status of the car is {m_Garage.GetVehicleStatus(licensePlateNumber)}.");
                Console.WriteLine("Please choose the desired vehicle status: (1), (2) or (3)");
                PrintList(m_Garage.GetVehicleStatusList());

                // DUPLICATION OF CODE FROM displayFilteredLicensePlatesinGarage() !!!!!!
                // Maybe move second condition to logics? // Maybe use Exceptions?
                string userChoice = Console.ReadLine();
                int userPick;
                while (!int.TryParse(userChoice, out userPick) || (userChoice != "1" && userChoice != "2" && userChoice != "3"))
                {
                    Console.WriteLine("Invalid input. Please enter (1), (2) or (3).");
                    userChoice = Console.ReadLine();
                }

                m_Garage.ChangeVehicleStatus(licensePlateNumber, userPick);

            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private void inflateTiresToMaximum()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsGarageEmpty())
            {
                printEmptyGarage();
            }
            else if(m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                m_Garage.InflateTiresToMaximum(licensePlateNumber);
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private void refuelVehicle()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                if(m_Garage.IsVehicleEngineFuel(licensePlateNumber))
                {
                    FuelEngine.eFuelType fuelType = getDesiredTypeOfFuel(licensePlateNumber);
                    if(m_Garage.IsFuelMatchVehicle(licensePlateNumber, fuelType))
                    {
                        float amountOfFuel = getDesired
                    }
                }
                else
                {
                    Console.WriteLine("Vehicle's engine is electric.");
                }
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private void displayVehicleFullInfo()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsGarageEmpty())
            {
                printEmptyGarage();
            }
            else if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                Console.WriteLine(m_Garage.GetVehicleDetails(licensePlateNumber));
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
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

        private void printEmptyGarage()
        {
            Console.WriteLine("No vehicles in the garage");
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

        private bool checkInputValidation(string i_LicenseNumberString)
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
