using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan95 = 1,
        Octan98,
        Octan96,
        Soler,
    }

    internal class FuelEngine : Engine
    {
        //private float m_CurrentAmountOfGas;
        //private readonly float  r_MaximalAmountOfGas;
        private readonly eFuelType m_FuelType; // readonly?

        public const eFuelType k_FuelTypeForMotorcycle = eFuelType.Octan98;
        public const eFuelType k_FuelTypeForCar = eFuelType.Octan95;
        public const eFuelType k_FuelTypeForTruck = eFuelType.Soler;

        public const float k_LiterFuelTankForMotorcycle = 5.5f;
        public const float k_LiterFuelTankForCar = 45f;
        public const float k_LiterFuelTankForTruck = 120f;


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


        public void RefuelTank(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if(i_FuelType == this.FuelType)
            {
                this.SupplyEnergy(i_LitersToAdd);
            }
            else
            {
                // exeption of not the same fuel type
            }
        }
    }
}
