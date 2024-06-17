using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public const float k_MotorcycleMaximumBatteryTime = 2.5f;
        public const float k_CarMaximumBatteryTime = 3.5f;

        public ElectricEngine(float i_MaximumBatteryTime) : base(i_MaximumBatteryTime)
        {

        }

        public float BatteryTimeLeft
        {
            get
            {
                return this.CurrentAmountOfEnergy;
            }
        }
        public float MaximalAmountOfBattery
        {
            get
            {
                return this.EnergyCapacity;
            }
        }

        public override void PrintCurrentUnitsOfMeasurement()
        {
            Console.WriteLine($"{BatteryTimeLeft} Hours of battery left");
        }

        public override void AddEnergy(string i_LicensePlateNumber, FuelEngine.eFuelType? i_FuelType, float i_AmountOfElectricity)
        {

            if(i_FuelType != null)
            {
                throw new ArgumentException(message: "Can't add fuel to an electric vehicle.");
            }

            if(i_AmountOfElectricity < k_MinimumAmountOfEnergy
               || i_AmountOfElectricity + CurrentAmountOfEnergy > r_EnergyCapacity)
            {
                float topAmountOfElectricity = r_EnergyCapacity - m_CurrentAmountOfEnergy;
                throw new ValueOutOfRangeException(k_MinimumAmountOfEnergy, topAmountOfElectricity);
            }

            m_CurrentAmountOfEnergy += i_AmountOfElectricity;

            m_EnergyPercentage = (m_CurrentAmountOfEnergy / r_EnergyCapacity) * 100;
        }

        //public override void PrintEnergycapacity()
        //{
        //    Console.WriteLine($"{MaximalAmountOfBattery} ");
        //}

        public void ChargeBattery(float i_HoursToCharge) // METHOD NOT NEEDED !!!
        {

        }

    }
}
