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


        public static List<string> GetVehicleTypeList()
        {
            return VehicleCreator.GetVehiclesTypes();
        }
    }
}
