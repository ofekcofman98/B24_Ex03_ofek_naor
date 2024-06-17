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
        protected List<Wheel> m_Wheels;

        protected Vehicle(string i_LicensePlate, Engine i_Engine)
        {
            m_LicensePlate = i_LicensePlate;
            m_Engine = i_Engine;
        }

        public abstract void SetSpecificData();


        //public abstract Dictionary<string, string> SpecificData
        //{
        //    get;
        //}
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

        public List<Wheel> WheelsList
        {
            get
            {
                return m_WheelsList;
            }
            //set
            //{
            //    m_WheelsList = value;
            //}
        }


        public void InflateTiresToMax()
        {
            foreach(Wheel wheel in m_WheelsList)
            {
                wheel.InflateToMax();
            }
        }

        protected static List<string> GetEnumKeys(Type enumType)
        {
            string[] keys = Enum.GetNames(enumType);

            return new List<string>(keys);
        }


        //public abstract VehicleTypeSpecificData

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine($"Model Name: {m_ModelName}");
            vehicleInfo.AppendLine($"License Plate: {m_LicensePlate}");
            vehicleInfo.AppendLine($"Engine Details: {m_Engine}");
            vehicleInfo.AppendLine("Tires Details:");

            foreach (Wheel wheel in m_WheelsList)
            {
                vehicleInfo.AppendLine($"  Manufacturer: {wheel.Manufacturer}, Current Air Pressure: {wheel.CurrentAirPressure}");
            }

            return vehicleInfo.ToString();
        }
    }
}
