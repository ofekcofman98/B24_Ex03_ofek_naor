using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_DoesCarryHazardousMaterials;
        private float m_LagageVolume;

        public const int k_NumberOfWheels = 12;

        public Truck(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
        }
    }
}
