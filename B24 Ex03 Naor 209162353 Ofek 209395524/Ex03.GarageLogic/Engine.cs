using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentAmountOfEnergy = 0; // 0 is const? 
        protected readonly float r_EnergyCapacity;

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
        }
        public float EnergyCapacity
        {
            get
            {
                return r_EnergyCapacity;
            }
        }
        protected void SupplyEnergy(float i_AmountOfEnergyToAdd)
        {
            float newEnergyAmount = EnergyCapacity + i_AmountOfEnergyToAdd;
            if(CheckEnergySupplyingValidation(newEnergyAmount))
            {
                m_CurrentAmountOfEnergy = newEnergyAmount;
            }
            else
            {
                // exception!!!
            }
        }

        public abstract void PrintCurrentUnitsOfMeasurement();


        private bool CheckEnergySupplyingValidation(float i_NewEnergyAmount)
        {
            bool isAmountValid = false;
            if(i_NewEnergyAmount >= r_EnergyCapacity || i_NewEnergyAmount <= r_EnergyCapacity)
            {
                isAmountValid = true;
            }
            return isAmountValid;
        }

    }
}
