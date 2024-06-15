using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class GarageVehicleInfo
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private Vehicle m_Vehicle;
        private eCarStatus m_CarStatus;

        private enum eCarStatus
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 3,
        }
    }
}
