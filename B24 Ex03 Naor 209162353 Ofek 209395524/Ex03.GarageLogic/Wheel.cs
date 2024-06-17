using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly float r_MaximumAirPressure;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;

        public const float k_MaximumAirPressureForMotorcycle = 33f;
        public const float k_MaximumAirPressureForCar = 31f;
        public const float k_MaximumAirPressureForTruck = 28f;

        public Wheel(float i_MaximumAirPressure)
        {
            r_MaximumAirPressure = i_MaximumAirPressure;
        }

        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressure;
            }
        }
        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public void Inflation(float i_AirAmountToAdd)
        {
            if (m_CurrentAirPressure + i_AirAmountToAdd <= r_MaximumAirPressure)
            {
                m_CurrentAirPressure += i_AirAmountToAdd;
            }
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = MaximumAirPressure;
        }
    }
}
