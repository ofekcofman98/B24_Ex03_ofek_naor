using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<int, GarageVehicleInfo> m_VehiclesInGarageDict;

        public bool IsVehicleInGarage(int i_LicenseNumber)
        {
            return m_VehiclesInGarageDict.ContainsKey(i_LicenseNumber);
        }

        public static bool CheckVehicleTypeInputValidation(string i_InputString)
        {
            bool isValid = false;
            int inputNumber = int.Parse(i_InputString);
            if(inputNumber >= 1 && inputNumber <= VehicleCreator.GetNumOfVehiclesType()) // if number is in the range of static num of type 
            {
                isValid = true;
            }

            return isValid;
        }

        public string GetVehicleStatus(int i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].VehicleStatus.ToString();
        }

        public List<string> GetVehicleStatusList()
        {
            List<string> statusList = new List<string>();

            foreach (var status in Enum.GetValues(typeof(GarageVehicleInfo.eVehicleStatus))) // change var
            {
                statusList.Add($"{(int)status}. {status}");
            }

            return statusList;
        }

        public static List<string> GetVehicleTypeList()
        {
            return VehicleCreator.GetVehiclesTypes();
        }

        public void AddNewVehicle(int i_LicensePlateNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            GarageVehicleInfo newVehicleInfo = new GarageVehicleInfo(i_OwnerName, i_OwnerPhoneNumber);

            m_VehiclesInGarageDict.Add(i_LicensePlateNumber, newVehicleInfo);
            newVehicleInfo.Vehicle = VehicleCreator.CreateNewVehicle(i_LicensePlateNumber); // TO DO
        }

        public void ResetVehicleStatus(int i_LicensePlateNumber)
        {
            m_VehiclesInGarageDict[i_LicensePlateNumber].ResetStatusToInRepair();
        }

        public List<int> GetLicensePlatesList()
        {
            List<int> licensePlatesList = new List<int>(m_VehiclesInGarageDict.Count);

            foreach(KeyValuePair<int, GarageVehicleInfo> garageVehicleInfo in m_VehiclesInGarageDict)
            {
                licensePlatesList.Add(int.Parse(garageVehicleInfo.Value.Vehicle.LicensePlate));
            }

            return licensePlatesList;
        }

        public List<int> GetLicensePlatesListByFilter(int i_UserChoice)
        {
            List<int> licensePlatesList = new List<int>(m_VehiclesInGarageDict.Count);

            foreach (KeyValuePair<int, GarageVehicleInfo> garageVehicleInfo in m_VehiclesInGarageDict)
            {
                if((int)garageVehicleInfo.Value.VehicleStatus == i_UserChoice)
                {
                    licensePlatesList.Add(int.Parse(garageVehicleInfo.Value.Vehicle.LicensePlate));
                }
            }

            return licensePlatesList;
        }

        public void ChangeVehicleStatus(int i_LicensePlateNumber, int i_UserPick)
        {
            m_VehiclesInGarageDict[i_LicensePlateNumber].VehicleStatus = (GarageVehicleInfo.eVehicleStatus)i_UserPick;
        }
    }
}
