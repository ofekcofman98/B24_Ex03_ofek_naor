﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        public const int k_NumberOfWheels = 12;

        private bool m_DoesCarryHazardousMaterials;
        private float m_LagageVolume;


        public override void SetSpecificData()
        {
        }

        //public override Dictionary<string, string> GetSpecificData()
        //{

        //}
        public override Dictionary<string, string> SpecificData { get; }

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder(base.ToString());
            truckInfo.AppendLine($"Carries Hazardous Materials: {m_DoesCarryHazardousMaterials}");
            truckInfo.AppendLine($"Luggage Volume: {m_LagageVolume} cubic meters");
            return truckInfo.ToString();
        }


        public Truck(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(Wheel.k_MaximumAirPressureForTruck));
            }

        }
    }
}
