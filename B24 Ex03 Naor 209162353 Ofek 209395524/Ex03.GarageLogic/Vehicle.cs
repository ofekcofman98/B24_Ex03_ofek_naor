﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicensePlate;
        protected Engine m_Engine;
        protected List<Wheel> m_WheelsList;

        protected Vehicle(string i_LicensePlate, Engine i_Engine)
        {
            m_LicensePlate = i_LicensePlate;
            m_Engine = i_Engine;
            m_WheelsList = new List<Wheel>();
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

        public List<Wheel> WheelsList
        {
            get
            {
                return m_WheelsList;
            }
        }


        public void InflateTiresToMax()
        {
            foreach(Wheel wheel in m_WheelsList)
            {
                wheel.InflateToMax();
            }
        }


        public abstract Dictionary<string, Type> GetRequiredDataFields();
        public abstract void SetSpecificData(Dictionary<string, string> i_SpecificVehicleData);

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine($"Model Name: {m_ModelName}");
            vehicleInfo.AppendLine($"License Plate: {m_LicensePlate}");
            vehicleInfo.AppendLine($"{m_Engine.ToString()}");
            vehicleInfo.AppendLine("Tires Details:");

            foreach (Wheel wheel in m_WheelsList)
            {
                vehicleInfo.AppendLine($"  Manufacturer: {wheel.Manufacturer}, Current Air Pressure: {wheel.CurrentAirPressure}");
            }

            return vehicleInfo.ToString();
        }
    }
}
