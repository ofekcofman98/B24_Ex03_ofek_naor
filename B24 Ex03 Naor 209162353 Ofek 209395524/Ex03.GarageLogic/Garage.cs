using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.VehicleCreator;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, GarageVehicleInfo> m_VehiclesInGarageDict = new Dictionary<string, GarageVehicleInfo>();

        public bool IsVehicleInGarage(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict.ContainsKey(i_LicensePlateNumber);
        }

        public bool CheckVehicleTypeInputValidation(string i_InputString, out int io_InputNumber)
        {
            bool isValid = false;
            if(int.TryParse(i_InputString, out io_InputNumber))
            {
                if(io_InputNumber >= 1 && io_InputNumber <= VehicleCreator.GetNumOfVehiclesType()) // if number is in the range of static num of type
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public string GetVehicleStatus(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].VehicleStatus.ToString();
        }

        public void GetVehicleTypeSpecificData(string i_LicensePlateNumber)
        {
            Vehicle currentVehicle = m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle;
            //currentVehicle.
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

        public void ChangeVehicleStatusToInRepair(string i_LicensePlate)
        {
            m_VehiclesInGarageDict[i_LicensePlate].ChangeVehicleStatus(GarageVehicleInfo.eVehicleStatus.InRepair);
        }

        public List<string> GetVehicleTypeList()
        {
            return VehicleCreator.GetVehiclesTypes();
        }

        public List<int> GetLicensePlatesList()
        {
            List<int> licensePlatesList = new List<int>(m_VehiclesInGarageDict.Count);

            foreach(KeyValuePair<string, GarageVehicleInfo> garageVehicleInfo in m_VehiclesInGarageDict)
            {
                licensePlatesList.Add(int.Parse(garageVehicleInfo.Value.Vehicle.LicensePlate));
            }

            return licensePlatesList;
        }

        public List<int> GetLicensePlatesListByFilter(int i_UserChoice)
        {
            List<int> licensePlatesList = new List<int>(m_VehiclesInGarageDict.Count);

            foreach (KeyValuePair<string, GarageVehicleInfo> garageVehicleInfo in m_VehiclesInGarageDict)
            {
                if((int)garageVehicleInfo.Value.VehicleStatus == i_UserChoice)
                {
                    licensePlatesList.Add(int.Parse(garageVehicleInfo.Value.Vehicle.LicensePlate));
                }
            }

            return licensePlatesList;
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, int i_UserPick)
        {
            m_VehiclesInGarageDict[i_LicensePlateNumber].VehicleStatus = (GarageVehicleInfo.eVehicleStatus)i_UserPick;
        }

        public void InflateTiresToMaximum(string i_LicensePlateNumber)
        {
            m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.InflateTiresToMax();
        }

        public string GetVehicleDetails(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].ToString();
        }
        public void AddNewVehicleToGarage(string i_LicensePlate, int i_VehicleTypeNumber, string i_OwnerName, string i_OwnerPhone)
        {
            eVehicleType vehicleType = (eVehicleType)i_VehicleTypeNumber;
            Vehicle newVehicle = CreateNewVehicle(i_LicensePlate, vehicleType);
            GarageVehicleInfo nameToChange = new GarageVehicleInfo(i_OwnerName, i_OwnerPhone);
            m_VehiclesInGarageDict.Add(i_LicensePlate,nameToChange);
        }

    }
}
