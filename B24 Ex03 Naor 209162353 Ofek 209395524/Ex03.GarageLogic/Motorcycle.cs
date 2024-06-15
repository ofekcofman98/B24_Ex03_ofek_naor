using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;
        private enum eLicenseType
        {
            B1,
            AA,
            A1,
            A,
        }
    }
}
