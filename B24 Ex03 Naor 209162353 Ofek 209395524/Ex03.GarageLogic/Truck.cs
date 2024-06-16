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

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder(base.ToString());
            truckInfo.AppendLine($"Carries Hazardous Materials: {m_DoesCarryHazardousMaterials}");
            truckInfo.AppendLine($"Luggage Volume: {m_LagageVolume} cubic meters");
            return truckInfo.ToString();
        }
    }
}
