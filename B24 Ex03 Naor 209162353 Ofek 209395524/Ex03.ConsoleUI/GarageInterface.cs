using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageInterface
    {
        private Garage m_Garage;

        public static void Menu()
        {
            Console.WriteLine("welcome to laGarage");
        }

        public void hi()
        {
            int i_LicenseNumber = GetLicenseNumber();

            if (m_Garage.IsVehicleInGarage(i_LicenseNumber))
            {

            }
        }

        public int GetLicenseNumber()
        {
            int i_LicenseNumber = 0;
            Console.WriteLine("please enter your license number:");
            while (true)
            {
                string i_LicenseNumberString = Console.ReadLine();
                if (CheckInputValidation(i_LicenseNumberString))
                {
                    int.TryParse(i_LicenseNumberString,out i_LicenseNumber);
                    break;
                }
                Console.WriteLine("valid input please");
            }
            return i_LicenseNumber;
        }

        public bool CheckInputValidation(string i_LicenseNumberString)
        {
            bool isValid = false;
            if(i_LicenseNumberString.Length == 9) // change 9 to k_
            {
                isValid = true;
                foreach (char c in i_LicenseNumberString)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                        break;
                    }
                }
            }
            return isValid;
        }
    }
}
