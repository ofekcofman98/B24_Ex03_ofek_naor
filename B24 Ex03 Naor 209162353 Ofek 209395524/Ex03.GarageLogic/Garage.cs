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
    }
}
