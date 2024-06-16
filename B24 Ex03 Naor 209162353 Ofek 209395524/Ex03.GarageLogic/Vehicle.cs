using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected Engine m_Engine;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_Wheels;

        protected Vehicle(string i_LicensePlate, Engine i_Engine)
        {
            m_LicensePlate = i_LicensePlate;
            m_Engine = i_Engine;
            // continue
        }

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

        public void InflateTiresToMax()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine($"Model Name: {m_ModelName}");
            vehicleInfo.AppendLine($"License Plate: {m_LicensePlate}");
            vehicleInfo.AppendLine($"Energy Percentage: {m_EnergyPercentage}%");
            vehicleInfo.AppendLine($"Engine Details: {m_Engine}");
            vehicleInfo.AppendLine("Tires Details:");

            foreach (Wheel wheel in m_Wheels)
            {
                vehicleInfo.AppendLine($"  Manufacturer: {wheel.Manufacturer}, Current Air Pressure: {wheel.CurrentAirPressure}");
            }

            return vehicleInfo.ToString();
        }
    }
}
