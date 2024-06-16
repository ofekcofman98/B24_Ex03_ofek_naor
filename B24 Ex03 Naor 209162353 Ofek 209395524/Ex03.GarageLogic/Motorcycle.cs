using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        private const string k_EngineVolume = "Engine Volume";
        private const string k_LicenseType = "License Type";

        public const int k_NumberOfWheels = 2;

        private enum eLicenseType
        {
            B1,
            AA,
            A1,
            A,
        }
        public Motorcycle(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
            for(int i = 0; i < k_NumberOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(Wheel.k_MaximumAirPressureForMotorcycle));
            }
            m_SpecificData.Add(k_EngineVolume,);
            m_SpecificData.Add(k_LicenseType,);
        }


        public override void SetSpecificData()
        {
        }

        //public override Dictionary<string, string> GetSpecificData()
        //{

        //}
        public override Dictionary<string, string> SpecificData { get;}

        public static List<string> GetLicenseTypeList()
        {
            return GetEnumKeys(typeof(eLicenseType));
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
