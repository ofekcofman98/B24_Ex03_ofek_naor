using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected Engine m_Engine;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_Wheels;


        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }
        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
            set
            {
                m_LicensePlate = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }
        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
            //set
            //{
            //    m_Wheels = value;
            //}
        }
    }
}
