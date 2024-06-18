using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        public const int k_NumberOfWheels = 12;

        private bool m_DoesCarryHazardousMaterials;
        private float m_CargoVolume;

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder(base.ToString());
            truckInfo.AppendLine($"Carries Hazardous Materials: {m_DoesCarryHazardousMaterials}");
            truckInfo.AppendLine($"Cargo Volume: {m_CargoVolume} cubic meters");

            return truckInfo.ToString();
        }

        public override Dictionary<string, Type> GetRequiredDataFields()
        {
            return new Dictionary<string, Type>
                       {
                           { "Does Carry Hazardous Materials", typeof(bool) },
                           { "Cargo Volume", typeof(float) }
                       };
        }

        public override void SetSpecificData(Dictionary<string, string> i_Data)
        {
            m_DoesCarryHazardousMaterials = bool.Parse(i_Data["Does Carry Hazardous Materials"]);
            m_CargoVolume = float.Parse(i_Data["Cargo Volume"]);
        }

        public bool DoesCarryHazardousMaterials
        {
            get
            {
                return m_DoesCarryHazardousMaterials;
            }
            set
            {
                m_DoesCarryHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
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
