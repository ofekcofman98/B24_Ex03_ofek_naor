using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public const int k_NumberOfWheels = 2;

        public enum eLicenseType
        {
            B1 = 1,
            AA = 2,
            A1 = 3,
            A = 4,
        }

        public Motorcycle(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
            for(int i = 0; i < k_NumberOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(Wheel.k_MaximumAirPressureForMotorcycle));
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public override Dictionary<string, Type> GetRequiredDataFields()
        {
            return new Dictionary<string, Type>
                       {
                           { "Engine Volume", typeof(int) },
                           { "License Type", typeof(eLicenseType) }
                       };
        }

        public override void SetSpecificData(Dictionary<string, string> i_Data)
        {
            m_EngineVolume = int.Parse(i_Data["Engine Volume"]);
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_Data["License Type"]);
        }

        public override string ToString()
        {
            StringBuilder motorcycleInfo = new StringBuilder(base.ToString());
            motorcycleInfo.AppendLine($"Engine Volume: {m_EngineVolume} cc");
            motorcycleInfo.AppendLine($"License Type: {m_LicenseType}");

            return motorcycleInfo.ToString();
        }

    }
}
