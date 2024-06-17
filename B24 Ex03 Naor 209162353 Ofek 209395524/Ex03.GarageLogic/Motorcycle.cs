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

        private const string k_EngineVolume = "engine eolume";
        private const string k_LicenseType = "license type";

        public const int k_NumberOfWheels = 2;

        public enum eLicenseType
        {
            B1 = 1,
            AA = 2,
            A1 = 3,
            A = 4,
        }

        public static List<string> GetLicenseTypeList()
        {
            return GetEnumKeys(typeof(eLicenseType));
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

        public override void SetSpecificData()
        {
            Utilities.PrintInputRequest(k_LicenseType);
            Utilities.PrintList(GetLicenseTypeList(), i_IsListNumbered: true);
            this.LicenseType = (eLicenseType)Utilities.ChooseFromEnumList(GetLicenseTypeList());

            Utilities.PrintInputRequest(k_EngineVolume);
            string i_EngineVolumeString = Console.ReadLine();
            int i_EngineVolume;
            int.TryParse(i_EngineVolumeString, out i_EngineVolume);

            // validation !!!!
            this.EngineVolume = i_EngineVolume;
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
