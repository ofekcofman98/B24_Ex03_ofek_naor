using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<int, GarageVehicleInfo> vehiclesInGarageDict;

        public bool IsVehicleInGarage(int i_LicenseNumber)
        {
            return vehiclesInGarageDict.ContainsKey(i_LicenseNumber);
        }

        public static bool CheckVehicleTypeInputValidation(string i_InputString)
        {
            bool isValid = false;
            int i_InputNumber = int.Parse(i_InputString);
            if(i_InputNumber >= 1 && i_InputNumber <= VehicleCreator.GetNumOfVehiclesType()) // if number is in the range of static num of type 
            {
                isValid = true;
            }
            return isValid;
        }


        public static List<string> GetVehicleTypeList()
        {
            return VehicleCreator.GetVehiclesTypes();
        }
    }
}
