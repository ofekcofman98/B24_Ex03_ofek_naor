using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType; 

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
            r_FuelType = i_FuelType;
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

        public override string GetTypeOfEnergy()
        {
            return k_FueledEnergy;
        }

        public override void AddEnergy(string i_LicensePlateNumber, eFuelType? i_FuelType, float i_AmountOfFuel)
        {
            if(i_FuelType == null)
            {
                throw new ArgumentException(message: "Can't charge a fuel engine vehicle.");
            }

            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(message: $"Wrong type of fuel. Please refuel with {r_FuelType}.");
            }

            if(i_AmountOfFuel < k_MinimumAmountOfEnergy || m_CurrentAmountOfEnergy + i_AmountOfFuel > r_EnergyCapacity)
            {
                float topAmountOfGas = r_EnergyCapacity - m_CurrentAmountOfEnergy;
                throw new ValueOutOfRangeException(k_MinimumAmountOfEnergy, topAmountOfGas);
            }

            m_CurrentAmountOfEnergy += i_AmountOfFuel;
            m_EnergyPercentage = (m_CurrentAmountOfEnergy / r_EnergyCapacity) * 100;
        }

        public override string ToString()
        {
            return string.Format($"Fuel Engine Details:\nCurrent Amount of Gas: {CurrentAmountOfGas} liters, Maximum Gas Capacity: {MaximalAmountOfGas} liters,\n Fuel Type: {r_FuelType}\n Fuel Percentage: {m_EnergyPercentage}%");
        }
    }
}
