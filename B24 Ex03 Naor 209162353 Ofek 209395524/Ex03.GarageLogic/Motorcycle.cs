using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public const int k_NumberOfWheels = 2;

        private enum eLicenseType
        {
            B1,
            AA,
            A1,
            A,
        }

        public override string ToString()
        {
            StringBuilder motorcycleInfo = new StringBuilder(base.ToString());
            motorcycleInfo.AppendLine($"Engine Volume: {m_EngineVolume} cc");
            motorcycleInfo.AppendLine($"License Type: {m_LicenseType}");
            return motorcycleInfo.ToString();
        }
        public Motorcycle(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
        }

    }
}
