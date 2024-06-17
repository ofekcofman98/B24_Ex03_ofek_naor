using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        public const int k_NumberOfWheels = 12;

        private bool m_DoesCarryHazardousMaterials;
        private float m_LagageVolume;

        private const string k_DoesCarryHazardousMaterials = "does carry hazzardous material";
        private const string k_LagageVolume = "laggage volume";


        //public override Dictionary<string, string> GetSpecificData()
        //{

        //}
        //public override Dictionary<string, string> SpecificData { get; }

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder(base.ToString());
            truckInfo.AppendLine($"Carries Hazardous Materials: {m_DoesCarryHazardousMaterials}");
            truckInfo.AppendLine($"Luggage Volume: {m_LagageVolume} cubic meters");
            return truckInfo.ToString();
        }


        public override void SetSpecificData()
        {
            Console.WriteLine($"Please enter {k_DoesCarryHazardousMaterials} (y/n)");
            string userChoice = Console.ReadLine().ToLower();
            while (userChoice != "y" && userChoice != "n")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                userChoice = Console.ReadLine().ToLower();
            }

            if (userChoice == "n")
            {
                m_DoesCarryHazardousMaterials = false;
            }
            else
            {
                m_DoesCarryHazardousMaterials = true;
            }


            Console.WriteLine($"Please enter {k_LagageVolume}");
            string i_InputString = Console.ReadLine();
            int i_Input;
            int.TryParse(i_InputString, out i_Input);

            // validation !!!!
            this.LagageVolume = i_Input;
        }

        public bool DoesCarryHazardousMaterials
        {
            get
            {
                return m_DoesCarryHazardousMaterials;
            }
            set
            {
                m_DoesCarryHazardousMaterials = value;
            }
        }

        public float LagageVolume
        {
            get
            {
                return m_LagageVolume;
            }
            set
            {
                m_LagageVolume = value;
            }
        }

        public Truck(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(Wheel.k_MaximumAirPressureForTruck));
            }

        }
    }
}
