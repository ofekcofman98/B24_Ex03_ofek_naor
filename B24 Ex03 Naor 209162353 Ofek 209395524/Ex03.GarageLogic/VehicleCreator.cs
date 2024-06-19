using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal static class VehicleCreator
    {
        private static readonly List<string> sr_VehiclesTypes = new List<string>()
        {
            "Fueled Motorcycle",
            "Electric Motorcycle",
            "Fueled Car",
            "Electric Car",
            "Truck"
        };

        public enum eVehicleType
        {
            FueledMotorcycle = 1,
            ElectricMotorcycle = 2,
            FueledCar = 3,
            ElectricCar = 4,
            Truck = 5
        }


        public static List<string> GetVehiclesTypes()
        {
            return sr_VehiclesTypes;
        }

        public static Vehicle CreateNewVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            if(!(i_VehicleType >= eVehicleType.FueledMotorcycle && i_VehicleType <= eVehicleType.Truck))
            {
                throw new ValueOutOfRangeException((float)eVehicleType.FueledMotorcycle, (float)eVehicleType.Truck);
            }

            Engine engine = CreateEngine(i_VehicleType);
            Vehicle vehicle = CreateVehicleType(i_LicensePlate, i_VehicleType, engine);

            return vehicle;
        }

        public static Engine CreateEngine(eVehicleType i_VehicleType)
        {
            Engine newEngine;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar:
                    newEngine =  new FuelEngine(FuelEngine.k_LiterFuelTankForCar, FuelEngine.k_FuelTypeForCar);
                    break;
                case eVehicleType.ElectricCar:
                    newEngine = new ElectricEngine(ElectricEngine.k_CarMaximumBatteryTime);
                    break;
                case eVehicleType.FueledMotorcycle:
                    newEngine = new FuelEngine(FuelEngine.k_LiterFuelTankForMotorcycle, FuelEngine.k_FuelTypeForMotorcycle);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newEngine = new ElectricEngine(ElectricEngine.k_MotorcycleMaximumBatteryTime);
                    break;
                case eVehicleType.Truck:
                    newEngine = new FuelEngine(FuelEngine.k_LiterFuelTankForTruck, FuelEngine.k_FuelTypeForTruck);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type", nameof(i_VehicleType));
            }

            return newEngine;
        }

        public static Vehicle CreateVehicleType(string i_LicensePlate, eVehicleType i_VehicleType, Engine i_Engine)
        {
            Vehicle newVehicle;
            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar:
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(i_LicensePlate, i_Engine);
                    break;
                case eVehicleType.FueledMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_LicensePlate, i_Engine);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(i_LicensePlate, i_Engine);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type", nameof(i_VehicleType));
            }

            return newVehicle;
        }
    }
}
