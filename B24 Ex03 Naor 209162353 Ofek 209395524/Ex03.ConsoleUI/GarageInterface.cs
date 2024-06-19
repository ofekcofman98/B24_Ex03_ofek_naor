using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageInterface
    {
        private Garage m_Garage = new Garage();
        private bool m_IsSystemQuit;

        private const bool k_PrintListNumbered = true;

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
            string garageMenu = string.Format($@"
Garage Menu:
{Utilities.PrintBuffer()}
1. Add a new vehicle.
2. Display the license plates of all vehicles.
3. Change a vehicle status.
4. Inflate wheels' air pressure to maximum.
5. Refuel vehicle's tank.
6. Recharge vehicle's battery.
7. Display a vehicle information by a license plate.
8. Exit garage system.
{Utilities.PrintBuffer()}
Please enter the number corresponding to your choice: ");
            Console.Write(garageMenu);
        }

        private eMenuOptions getMenuChoice()
        {
            return (eMenuOptions)Utilities.ChooseFromEnumList(getMenuOptionsList());
        }

        private List<string> getMenuOptionsList()
        {
            return Utilities.GetEnumKeys(typeof(eMenuOptions));
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
            Console.WriteLine(Utilities.PrintBuffer());
            string licensePlate = getLicensePlateNumber();

            if(m_Garage.IsVehicleInGarage(licensePlate))
            {
                Console.WriteLine("The vehicle is already in the garage");
                m_Garage.ChangeVehicleStatusToInRepair(licensePlate);
                setVehicleTiresAndEnergy(licensePlate);
                Console.WriteLine("Information added successfully");
            }
            else
            {
                string ownerName = Utilities.GetValidatedString("Please enter the owner's name:");
                string ownerPhoneNumber =
                    Utilities.GetValidatedPhoneNumber("Please enter the owner's phone number:");
                Console.WriteLine();
                int vehicleTypeInputNumber = getVehicleTypeNumber();
                m_Garage.AddNewVehicleToGarage(licensePlate, vehicleTypeInputNumber, ownerName, ownerPhoneNumber);

                while (true)
                {
                    try
                    {
                        Console.WriteLine();
                        string modelName = Utilities.GetValidatedString("Please enter the model name:");
                        m_Garage.SetModelName(licensePlate, modelName);

                        Dictionary<string, Type> requiredDataFields = m_Garage.GetVehicleRequiredDataFields(licensePlate);
                        Dictionary<string, string> specificData = collectSpecificData(requiredDataFields);

                        m_Garage.SetSpecificData(licensePlate, specificData);

                        setVehicleTiresAndEnergy(licensePlate);

                        Console.WriteLine("Vehicle added successfully.");
                        
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Format Error: {ex.Message}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Argument Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                }
            }
        }

        private void setVehicleTiresAndEnergy(string i_LicensePlate)
        {
            string wheelsManufacturer =
                Utilities.GetValidatedString("Please enter name of wheels manufacturer:");
            float maxAirPressure = m_Garage.GetMaximumAirPressure(i_LicensePlate);
            float airPressure = Utilities.GetValidatedFloat(
                $"Please enter air pressure for the wheels between 0 and {maxAirPressure}:");
            m_Garage.SetAirPressureToAllWheels(i_LicensePlate, airPressure, wheelsManufacturer);

            float energyCapacity = m_Garage.GetEnergyCapacity(i_LicensePlate);
            float currentAmountOfEnergy = Utilities.GetValidatedFloat(
                $"Please enter current amount of {m_Garage.GetTypeOfEnergy(i_LicensePlate)} between 0 and {energyCapacity}:");
            m_Garage.SetCurrentAmountOfEnergy(i_LicensePlate, currentAmountOfEnergy);
        }

        private Dictionary<string, string> collectSpecificData(Dictionary<string, Type> i_RequiredDataFields)
        {
            Dictionary<string, string> specificDataDic = new Dictionary<string, string>();

            while(true)
            {
                foreach(KeyValuePair<string, Type> field in i_RequiredDataFields)
                {
                    string fieldName = field.Key;
                    Type fieldType = field.Value;

                    try
                    {
                        if(fieldType.IsEnum)
                        {
                            List<string> enumValues = Utilities.GetEnumKeys(fieldType);
                            Utilities.PrintInputRequest(fieldName);
                            Utilities.PrintList(enumValues, k_PrintListNumbered);
                            int choice = Utilities.ChooseFromEnumList(enumValues);
                            specificDataDic.Add(fieldName, enumValues[choice - 1]);
                        }
                        else
                        {
                            string input = Utilities.GetValidatedString($"Please enter {fieldName}:");
                            specificDataDic.Add(fieldName, input);
                        }
                    }
                    catch(FormatException ex)
                    {
                        throw new FormatException($"Format Error collecting data for {fieldName}: {ex.Message}");
                    }
                    catch(ArgumentException ex)
                    {
                        throw new ArgumentException($"Argument Error collecting data for {fieldName}: {ex.Message}");
                    }
                }

                return specificDataDic;
            }
        }

        private int getVehicleTypeNumber()
        {
            Console.WriteLine("vehicle types: ");
            Utilities.PrintList(m_Garage.GetVehicleTypeList(), k_PrintListNumbered);
            Console.WriteLine("PLease enter the vehicle's type: ");
            int vehicleTypeInputNumber = Utilities.GetValidatedInteger("");

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
                    Console.WriteLine("License Plates: ");
                    Utilities.PrintList(licensePlates);
                }
            }  

        }

        private void displayFilteredLicensePlatesInGarage()
        {
            List<string> vehicleStatusesList = Utilities.GetEnumKeys(typeof(VehicleRecordInfo.eVehicleStatus));

            Utilities.PrintInputRequest("status");
            Utilities.PrintList(Utilities.GetEnumKeys(typeof(VehicleRecordInfo.eVehicleStatus)), k_PrintListNumbered);
            int userStatusChoice = Utilities.ChooseFromEnumList(vehicleStatusesList);

            List<string> licensePlates = m_Garage.GetLicensePlatesListByFilter(userStatusChoice);

            if(licensePlates.Count == 0)
            {
                Console.WriteLine("No vehicles in the garage in that status.");
            }
            else
            {
                Console.WriteLine("License Plates: ");
                Utilities.PrintList(licensePlates);
            }
        }

        private void changeVehicleStatus()
        {
            string licensePlateNumber = getLicensePlateNumber();

            if (m_Garage.IsVehicleInGarage(licensePlateNumber))
            {
                Console.WriteLine($"The current status of the car is {m_Garage.GetVehicleStatus(licensePlateNumber)}.");

                List<string> vehicleStatusesList = Utilities.GetEnumKeys(typeof(VehicleRecordInfo.eVehicleStatus));

                Utilities.PrintInputRequest("status");
                Utilities.PrintList(Utilities.GetEnumKeys(typeof(VehicleRecordInfo.eVehicleStatus)), k_PrintListNumbered);
                int userStatusChoice = Utilities.ChooseFromEnumList(vehicleStatusesList);
                m_Garage.ChangeVehicleStatus(licensePlateNumber, userStatusChoice);

                Console.WriteLine("Status was changed.");
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
                Console.WriteLine("Tires are now full.");
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

                Console.WriteLine($"{amountOfFuel} litres  of {fuelType} were added to the vehicle");
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private FuelEngine.eFuelType getDesiredTypeOfFuel()
        {
            List<string> fuelTypesList = Utilities.GetEnumKeys(typeof(FuelEngine.eFuelType));
            Utilities.PrintList(fuelTypesList, true);
            Utilities.PrintInputRequest("Fuel type");
            int userFuelTypeChoice = Utilities.ChooseFromEnumList(fuelTypesList);

            return (FuelEngine.eFuelType)userFuelTypeChoice;
        }

        private float getDesiredAMountOfFuel()
        {
            return Utilities.GetValidatedFloat("Please enter your desired amount of fuel in litres:");
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

                Console.WriteLine($"{minutesOfElectricity} of battery time were added to vehicle.");
            }
            else
            {
                Console.WriteLine("Vehicle is not in the garage");
            }
        }

        private float getDesiredAmountOfElectricityInMinutes()
        {
            return Utilities.GetValidatedFloat("Please enter your desired amount of electricity in minutes:");
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
        
        private string getLicensePlateNumber() 
        {

            string licenseNumberString = Utilities.GetValidatedString("Please enter your license plate number:");
            if (checkInputValidation(licenseNumberString))
            {
                return licenseNumberString;
            }

            throw new ArgumentException("License plate number contains invalid characters.");
                
        }

        private bool checkInputValidation(string i_LicenseNumberString)
        {
            foreach (char c in i_LicenseNumberString)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
