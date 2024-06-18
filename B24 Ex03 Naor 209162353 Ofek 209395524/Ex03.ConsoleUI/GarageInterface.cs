using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageInterface
    {
        private Garage m_Garage = new Garage();
        private bool m_IsSystemQuit;

        private enum eMenuOptions
        {
            AddNewVehicle = 1,
            DisplayLicensePlates = 2, 
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

            while(!m_IsSystemQuit)
            {
                printGarageMenu();

                try
                {
                    eMenuOptions userMenuChoice = getMenuChoice();
                    userMenuChoiceManager(userMenuChoice);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            printGoodbye();
        }

        private void printWelcome()
        {
            Console.WriteLine("·································································\r\n: \u2566 \u2566\u250c\u2500\u2510\u252c  \u250c\u2500\u2510\u250c\u2500\u2510\u250c\u252c\u2510\u250c\u2500\u2510  \u250c\u252c\u2510\u250c\u2500\u2510  \u2554\u2566\u2557\u252c \u252c\u250c\u2500\u2510  \u2554\u2550\u2557\u250c\u2500\u2510\u252c\u2500\u2510\u250c\u2500\u2510\u250c\u2500\u2510\u250c\u2500\u2510\u252c :\r\n: \u2551\u2551\u2551\u251c\u2524 \u2502  \u2502  \u2502 \u2502\u2502\u2502\u2502\u251c\u2524    \u2502 \u2502 \u2502   \u2551 \u251c\u2500\u2524\u251c\u2524   \u2551 \u2566\u251c\u2500\u2524\u251c\u252c\u2518\u251c\u2500\u2524\u2502 \u252c\u251c\u2524 \u2502 :\r\n: \u255a\u2569\u255d\u2514\u2500\u2518\u2534\u2500\u2518\u2514\u2500\u2518\u2514\u2500\u2518\u2534 \u2534\u2514\u2500\u2518   \u2534 \u2514\u2500\u2518   \u2569 \u2534 \u2534\u2514\u2500\u2518  \u255a\u2550\u255d\u2534 \u2534\u2534\u2514\u2500\u2534 \u2534\u2514\u2500\u2518\u2514\u2500\u2518o :\r\n·································································");
            Console.WriteLine("        _______\r\n       //  ||\\ \\\r\n _____//___||_\\ \\___\r\n )  _          _    \\\r\n |_/ \\________/ \\___|\r\n___\\_/________\\_/______");
            Console.WriteLine();
        }

        private void printGoodbye()
        {
            Console.WriteLine();
            Console.WriteLine("\u2554\u2550\u2557\u250c\u2500\u2510\u250c\u2500\u2510\u250c\u252c\u2510\u250c\u2510 \u252c \u252c\u250c\u2500\u2510\u252c\r\n\u2551 \u2566\u2502 \u2502\u2502 \u2502 \u2502\u2502\u251c\u2534\u2510\u2514\u252c\u2518\u251c\u2524 \u2502\r\n\u255a\u2550\u255d\u2514\u2500\u2518\u2514\u2500\u2518\u2500\u2534\u2518\u2514\u2500\u2518 \u2534 \u2514\u2500\u2518o");
            Console.WriteLine();
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

        private eMenuOptions getMenuChoice()
        {
            string menuChoiceString = Console.ReadLine();

            if(!int.TryParse(menuChoiceString, out int menuChoice))
            {
                throw new FormatException($"Invalid input, please enter a number between {(int)eMenuOptions.AddNewVehicle} and {(int)eMenuOptions.ExitSystem}");
            }

            if (!(menuChoice >= (int)eMenuOptions.AddNewVehicle && menuChoice <= (int)eMenuOptions.ExitSystem)) // change to argument? 
            {
                throw new ValueOutOfRangeException((float)eMenuOptions.AddNewVehicle, (float)eMenuOptions.ExitSystem);
            }

            return (eMenuOptions)menuChoice;
        }

        private void userMenuChoiceManager(eMenuOptions i_MenuChoice)
        {
            switch (i_MenuChoice)
            {
                case eMenuOptions.AddNewVehicle:
                    addNewVehicle();
                    break;
                case eMenuOptions.DisplayLicensePlates:
                    displayLicensePlatesInGarage();
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
                    chargeVehicle();
                    break;
                case eMenuOptions.DisplayVehicleFullInfo:
                    displayVehicleFullInfo();
                    break;
                case eMenuOptions.ExitSystem:
                    m_IsSystemQuit = true;
                    break;
            }
        }

        private void addNewVehicle()
        {
            string licensePlate = getLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlate))
            {
                Console.WriteLine("The vehicle is already in the garage");
                m_Garage.ChangeVehicleStatusToInRepair(licensePlate);
            }
            else
            {
                Console.WriteLine("Please enter the owner's name:");
                string ownerName = Console.ReadLine(); // check no "enter"

                Console.WriteLine("Please enter the owner's phone number:");
                string ownerPhoneNumber = Console.ReadLine(); // need to check validation (no letters, no "enter")

                int vehicleTypeInputNumber = getVehicleTypeNumber();
                m_Garage.AddNewVehicleToGarage(licensePlate, vehicleTypeInputNumber, ownerName, ownerPhoneNumber);

                Console.WriteLine("Please enter model name");
                string modelName = Console.ReadLine();  // check no "enter"
                m_Garage.SetModelName(licensePlate, modelName);

                Dictionary<string, Type> requiredDataFields = m_Garage.GetVehicleRequiredDataFields(licensePlate);
                Dictionary<string, string> specificData = collectSpecificData(requiredDataFields);

                m_Garage.SetSpecificData(licensePlate, specificData);

                Console.WriteLine("Please enter name of wheels manufacturer:"); // check no "enter"
                string wheelsManufacturer = Console.ReadLine();
                Console.WriteLine("Please enter air pressure for the wheels:");
                string  airPressureString = Console.ReadLine();
                if(wheelsManufacturer == "" || !(float.TryParse(airPressureString, out float airPressure)))
                {
                    throw new FormatException("Invalid input");
                }
                // validation for: float
                //                 in range (between 0 and r_MaximumAirPressure)
                m_Garage.SetAirPressureToAllWheels(licensePlate, airPressure , wheelsManufacturer);

                Console.WriteLine($"Please enter current amount of {m_Garage.GetTypeOfEnergy(licensePlate)}");
                string currentAmountOfEnergyString = Console.ReadLine();
                // validation for: float
                //                 in range (between 0 and EnergyCapacity)
                float currentAmountOfEnergy = float.Parse(currentAmountOfEnergyString);
                m_Garage.SetCurrentAmountOfEnergy(licensePlate, currentAmountOfEnergy);
            }
        }

        private Dictionary<string, string> collectSpecificData(Dictionary<string, Type> i_RequiredDataFields)
        {
            Dictionary<string, string> specificDataDic = new Dictionary<string, string>();

            foreach (KeyValuePair<string, Type> field in i_RequiredDataFields)
            {
                string fieldName = field.Key;
                Type fieldType = field.Value;

                if (fieldType.IsEnum)
                {
                    List<string> enumValues = Utilities.GetEnumKeys(fieldType);
                    Utilities.PrintInputRequest(fieldName);
                    Utilities.PrintList(enumValues, true);
                    int choice = Utilities.ChooseFromEnumList(enumValues);
                    specificDataDic.Add(fieldName, enumValues[choice - 1]);
                }
                else
                {
                    Console.WriteLine($"Please enter {fieldName}:");
                    string inputData = Console.ReadLine();
                    specificDataDic.Add(fieldName, inputData);
                }
            }

            return specificDataDic;
        }

        private int getVehicleTypeNumber()
        {
            int vehicleTypeInputNumber;

            Console.WriteLine("vehicle types: ");
            Utilities.PrintList(m_Garage.GetVehicleTypeList(), i_IsListNumbered: true);
            Console.WriteLine("PLease enter the vehicle's type: ");

            while (true)
            {
                string vehicleTypeInputString = Console.ReadLine();
                if (!m_Garage.CheckVehicleTypeInputValidation(vehicleTypeInputString, out vehicleTypeInputNumber))
                {
                    Console.WriteLine("invalid input, try again");
                }
                else
                {
                    break;
                }
            }

            return vehicleTypeInputNumber;
        }

        private void displayLicensePlatesInGarage()
        {
            if(m_Garage.IsGarageEmpty())
            {
                printEmptyGarage();
            }
            else
            {
                string question = string.Format("Do you want to filter the vehicles by their status? ");
                bool isAnswerPositive = Utilities.GetYesOrNoFromUser(question);

                if(isAnswerPositive)
                {
                    displayFilteredLicensePlatesInGarage();
                }
                else
                {
                    List<int> licensePlates = m_Garage.GetLicensePlatesList();
                    Utilities.PrintList(licensePlates);
                }
            }  

        }

        private void displayFilteredLicensePlatesInGarage()
        {
            List<string> vehicleStatusesList = Utilities.GetEnumKeys(typeof(VehicleRecordInfo.eVehicleStatus));

            Utilities.PrintInputRequest("status");
            int userStatusChoice = Utilities.ChooseFromEnumList(vehicleStatusesList);

            List<int> licensePlates = m_Garage.GetLicensePlatesListByFilter(userStatusChoice);
            Utilities.PrintList(licensePlates);
        }

        private void changeVehicleStatus()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                Console.WriteLine($"The current status of the car is {m_Garage.GetVehicleStatus(licensePlateNumber)}.");

                List<string> vehicleStatusesList = Utilities.GetEnumKeys(typeof(VehicleRecordInfo.eVehicleStatus));

                Utilities.PrintInputRequest("status");
                int userStatusChoice = Utilities.ChooseFromEnumList(vehicleStatusesList);

                m_Garage.ChangeVehicleStatus(licensePlateNumber, userStatusChoice);

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
            else if (m_Garage.IsVehicleInGarage(licensePlateNumber))
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

            if(m_Garage.IsGarageEmpty())
            {
                printEmptyGarage();
            }
            else if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                FuelEngine.eFuelType fuelType = getDesiredTypeOfFuel();
                float amountOfFuel = getDesiredAMountOfFuel();

                m_Garage.AddEnergy(licensePlateNumber, fuelType, amountOfFuel);
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private FuelEngine.eFuelType getDesiredTypeOfFuel()
        {
            List<string> fuelTypesList = Utilities.GetEnumKeys(typeof(FuelEngine.eFuelType));

            Utilities.PrintInputRequest("status");
            int userFuelTypeChoice = Utilities.ChooseFromEnumList(fuelTypesList);

            return (FuelEngine.eFuelType)userFuelTypeChoice;
        }

        private float getDesiredAMountOfFuel()
        {
            Console.WriteLine("Please enter your desired amount of fuel in litres:");
            string userFuelAmountChoice = Console.ReadLine();
            // parse validation MISSING
            return float.Parse(userFuelAmountChoice);
        }

        private void chargeVehicle()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsGarageEmpty())
            {
                printEmptyGarage();
            }
            else if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                float minutesOfElectricity = getDesiredAmountOfElectricityInMinutes();
                float hoursOfElectricity = minutesOfElectricity / 60;

                m_Garage.AddEnergy(licensePlateNumber, null, hoursOfElectricity);
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private float getDesiredAmountOfElectricityInMinutes()
        {
            Console.WriteLine("Please enter your desired amount of electricity in minutes:");
            string userMinutesAmountChoice = Console.ReadLine();
            if(!float.TryParse(userMinutesAmountChoice, out float minutesResult))
            {
                throw new FormatException(message: "Invalid Input, please enter number of minutes.");
            }

            return minutesResult;
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

        private void printEmptyGarage()
        {
            Console.WriteLine("No vehicles in the garage.");
        }
        
        private string getLicensePlateNumber() // NEED TO USE EXCEPTIONS!
        {
            string licenseNumberString;
            Console.WriteLine("please enter your license plate number:");

            while (true)
            {
                licenseNumberString = Console.ReadLine();
                if (checkInputValidation(licenseNumberString))
                {
                    break;
                }
                Console.WriteLine("valid input please");
            }
            return licenseNumberString;
        }

        private bool checkInputValidation(string i_LicenseNumberString)
        {
            bool isValid = true;/*i_LicenseNumberString.Length == 8; // could be also 7, or 6 for vintage for ex... */

            if (isValid) // check no "enter"
            {
                foreach (char c in i_LicenseNumberString)
                {
                    if (!char.IsLetterOrDigit(c))
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
