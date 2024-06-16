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
            Console.WriteLine("Welcome to laGarage");
        }

        private void printGarageMenu()
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
            int licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                Console.WriteLine("The vehicle is already in the garage");
                m_Garage.ResetVehicleStatus(licensePlateNumber);
            }
            else
            {
                Console.WriteLine("Please enter the owner's name:");
                string ownerName = Console.ReadLine();

                Console.WriteLine("Please enter the owner's phone number:");
                string ownerPhoneNumber = Console.ReadLine();

                getVehicleType();
                m_Garage.AddNewVehicle(licensePlateNumber, ownerName, ownerPhoneNumber); // TO DO

                // Get more SPECIFIC details of the vehicle 
            }

        }

        private string getVehicleType()
        {
            string vehicleInput;
            Console.WriteLine("vehicle types: ");
            PrintList(Garage.GetVehicleTypeList(), i_IsListNumbered: true);
            Console.WriteLine("PLease enter the vehicle's type: ");

            while (true)
            {
                vehicleInput = Console.ReadLine();
                // first validation
                // is in garage validation
                if (!Garage.CheckVehicleTypeInputValidation(vehicleInput))
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
            int licensePlateNumber = getLicensePlateNumber();

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

        private int getLicensePlateNumber()
        {
            int licenseNumber = 0;
            Console.WriteLine("please enter your license plate number:");
            while (true)
            {
                string licensePlateNumberString = Console.ReadLine();
                if (checkInputValidation(licensePlateNumberString))
                {
                    int.TryParse(licensePlateNumberString, out licenseNumber);
                    break;
                }
                Console.WriteLine("Invalid input, Please try again.");
            }

            return licenseNumber;
        }

        private bool checkInputValidation(string i_LicenseNumberString)
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
