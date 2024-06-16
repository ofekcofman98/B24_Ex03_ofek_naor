using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Ex03.GarageLogic
{
    internal static class VehicleCreator
    {
        private static List<string> s_VehiclesTypes = new List<string>()
        {
            "Fueled Motorcycle",
            "Electric Motorcycle",
            "Fueled Car",
            "Electric Motorcycle",
            "Truck"
        };

        public static List<string> GetVehiclesTypes()
        {
            return s_VehiclesTypes;
        }

        public static int GetNumOfVehiclesType()
        {
            return s_VehiclesTypes.Count;
        }

        public static Vehicle CreateNewVehicle(string i_LicensePlateNumber)
        {

        }
    }
}
