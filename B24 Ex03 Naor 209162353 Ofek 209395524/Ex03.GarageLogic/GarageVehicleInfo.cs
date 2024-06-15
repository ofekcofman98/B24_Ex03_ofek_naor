﻿using System;
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

        internal GarageVehicleInfo(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhoneNumber;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        internal enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 3,
        }

        internal void ResetStatusToInRepair()
        {
            m_VehicleStatus = eVehicleStatus.InRepair;
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

    }
}
