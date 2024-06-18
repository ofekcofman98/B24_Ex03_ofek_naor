using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentAmountOfEnergy = 0; // 0 is const? 
        protected float m_EnergyPercentage;
        protected readonly float r_EnergyCapacity;

        protected const float k_MinimumAmountOfEnergy = 0;

        protected Engine(float i_EnergyCapacity)
        {
            r_EnergyCapacity = i_EnergyCapacity;
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }
            private set
            {
                m_CurrentAmountOfEnergy = value;
            }
        }
        public float EnergyCapacity
        {
            get
            {
                return r_EnergyCapacity;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            private set
            {
                m_EnergyPercentage = value;
            }
        }

        public void SetCurrentAmountAndPercentageOfEnergy(float i_CurrentAmountOfEnergy)
        {
            CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
            EnergyPercentage = (CurrentAmountOfEnergy / EnergyCapacity) * 100;
        }

        public abstract string GetTypeOfEnergy();


        public abstract void AddEnergy(
            string i_LicensePlateNumber,
            FuelEngine.eFuelType? i_FuelType,
            float i_AmountOfFuel);

        public abstract override string ToString();
    }
}
