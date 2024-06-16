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
        private eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 3,
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }
        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
            set
            {
                m_OwnerPhone = value;
            }   
        }
        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }
        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public void ChangeVehicleStatus(eVehicleStatus e_Status)
        {
            this.VehicleStatus = e_Status;
        }
    }
}
