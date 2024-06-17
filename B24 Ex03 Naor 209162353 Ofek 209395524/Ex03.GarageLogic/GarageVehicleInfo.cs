﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageVehicleInfo
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

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 3,
        }

        public override string ToString()
        {
            StringBuilder garageVehicleInfo = new StringBuilder();
            garageVehicleInfo.AppendLine($"Owner Name: {m_OwnerName}");
            garageVehicleInfo.AppendLine($"Owner Phone: {m_OwnerPhone}");
            garageVehicleInfo.AppendLine($"Vehicle Status: {m_VehicleStatus}");
            garageVehicleInfo.AppendLine("Vehicle Details:");
            garageVehicleInfo.AppendLine(m_Vehicle.ToString());

            return garageVehicleInfo.ToString();
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
