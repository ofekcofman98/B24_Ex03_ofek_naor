using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.VehicleCreator;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, GarageVehicleInfo> vehiclesInGarageDict = new Dictionary<string, GarageVehicleInfo>();

        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return vehiclesInGarageDict.ContainsKey(i_LicensePlate);
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

        public void ChangeVehicleStatusToInRepair(string i_LicensePlate)
        {
            vehiclesInGarageDict[i_LicensePlate].ChangeVehicleStatus(GarageVehicleInfo.eVehicleStatus.InRepair);
        }

        public List<string> GetVehicleTypeList()
        {
            return VehicleCreator.GetVehiclesTypes();
        }

        public void AddNewVehicleToGarage(string i_LicensePlate, int i_VehicleTypeNumber, string i_OwnerName, string i_OwnerPhone)
        {
            eVehicleType vehicleType = (eVehicleType)i_VehicleTypeNumber;
            Vehicle newVehicle = CreateNewVehicle(i_LicensePlate, vehicleType);
            GarageVehicleInfo nameToChange = new GarageVehicleInfo();
            nameToChange.OwnerName = i_OwnerName;
            nameToChange.OwnerPhone = i_OwnerPhone;
            nameToChange.Vehicle = newVehicle;
            nameToChange.VehicleStatus = GarageVehicleInfo.eVehicleStatus.InRepair;
            vehiclesInGarageDict.Add(i_LicensePlate,nameToChange);
        }

    }
}
