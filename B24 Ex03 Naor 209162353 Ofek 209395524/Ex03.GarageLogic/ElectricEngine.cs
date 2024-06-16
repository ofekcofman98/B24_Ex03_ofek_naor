using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        //private readonly float r_MaximalAmountOfBattery;
        //private float m_BatteryLeft;
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

        //public override void PrintEnergycapacity()
        //{
        //    Console.WriteLine($"{MaximalAmountOfBattery} ");
        //}

        public void ChargeBattery(float i_HoursToCharge)
        {

        }

    }
}
