using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType m_FuelType; // readonly?

        public const eFuelType k_FuelTypeForMotorcycle = eFuelType.Octan98;
        public const eFuelType k_FuelTypeForCar = eFuelType.Octan95;
        public const eFuelType k_FuelTypeForTruck = eFuelType.Soler;

        public const string k_FueledEnergy = "gas";
        public const float k_LiterFuelTankForMotorcycle = 5.5f;
        public const float k_LiterFuelTankForCar = 45f;
        public const float k_LiterFuelTankForTruck = 120f;


        public enum eFuelType
        {
            Octan95 = 1,
            Octan98,
            Octan96,
            Soler,
        }

        public FuelEngine(float i_MaximalAmountOfGas, eFuelType i_FuelType) : base(i_MaximalAmountOfGas)
        {
            
        }

        public float CurrentAmountOfGas
        {
            get
            {
                return this.CurrentAmountOfEnergy;
            }
        }

        public float MaximalAmountOfGas
        {
            get
            {
                return this.EnergyCapacity;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
        public override void PrintCurrentUnitsOfMeasurement()
        {
            Console.WriteLine($"{CurrentAmountOfGas} liters of fuel left");
        }

        public override string GetTypeOfEnergy()
        {
            return k_FueledEnergy;
        }

        public static List<eFuelType> GetFuelTypesList()
        {
            List<eFuelType> fuelTypesList = Enum.GetValues(typeof(eFuelType)).Cast<eFuelType>().ToList();

            return fuelTypesList;
        }

        public override void AddEnergy(string i_LicensePlateNumber, eFuelType? i_FuelType, float i_AmountOfFuel)
        {
            if(i_FuelType == null)
            {
                throw new ArgumentException(message: "Can't charge a fuel engine vehicle.");
            }

            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException(message: $"Wrong type of fuel. Please refuel with {m_FuelType}.");
            }

            if(i_AmountOfFuel < k_MinimumAmountOfEnergy || m_CurrentAmountOfEnergy + i_AmountOfFuel > r_EnergyCapacity)
            {
                float topAmountOfGas = r_EnergyCapacity - m_CurrentAmountOfEnergy;
                throw new ValueOutOfRangeException(k_MinimumAmountOfEnergy, topAmountOfGas);
            }

            m_CurrentAmountOfEnergy += i_AmountOfFuel;

            m_EnergyPercentage = (m_CurrentAmountOfEnergy / r_EnergyCapacity) * 10;
        }
    }
}
