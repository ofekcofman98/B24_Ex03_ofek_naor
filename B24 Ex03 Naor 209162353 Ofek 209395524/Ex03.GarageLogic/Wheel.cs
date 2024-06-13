using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly float r_MaximumAirPressure;
        private string m_Manufactor;
        private float m_CurrentAirPressure;

        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressure;
            }
        }
        public string Manufactor
        {
            get { return m_Manufactor; }
            set { m_Manufactor = value; }
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


    }
}
