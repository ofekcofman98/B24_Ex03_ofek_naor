using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private Engine m_Engine;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
    }
}
