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
        private float m_CargoVolume;

        private const string k_DoesCarryHazardousMaterials = "does carry hazzardous material";
        private const string k_CargoVolume = "cargo volume";

        public override string ToString()
        {
            StringBuilder truckInfo = new StringBuilder(base.ToString());
            truckInfo.AppendLine($"Carries Hazardous Materials: {m_DoesCarryHazardousMaterials}");
            truckInfo.AppendLine($"Cargo Volume: {m_CargoVolume} cubic meters");
            return truckInfo.ToString();
        }


        public override void SetSpecificData()
        {
            inputAndSetDoesCarryHazardousMaterials();

        }

        private void inputAndSetDoesCarryHazardousMaterials()
        {
            this.DoesCarryHazardousMaterials = Utilities.GetYesOrNoFromUser(k_DoesCarryHazardousMaterials);
            inputAndSetCargoVolume();
        }

        private void inputAndSetCargoVolume()
        {
            Utilities.PrintInputRequest(k_CargoVolume);
            string i_InputString = Console.ReadLine();
            int i_Input;
            int.TryParse(i_InputString, out i_Input);

            // validation !!!!
            this.CargoVolume = i_Input;
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

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
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
