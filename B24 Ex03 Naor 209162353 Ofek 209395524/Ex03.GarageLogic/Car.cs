using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumOfDoors;

        public const int k_NumberOfWheels = 5;

        public Car(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(Wheel.k_MaximumAirPressureForCar));
            }
        }

        public override void SetSpecificData()
        {
        }

        //public override Dictionary<string, string> GetSpecificData()
        //{

        //}
        public override Dictionary<string, string> SpecificData { get; }



        public enum eCarColor
        {
            Yellow = 1,
            White = 2,
            Red = 3,
            Black = 4
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        public static List<string> GetColorsList()
        {
            return GetEnumKeys(typeof(eCarColor));
        }

        public static List<string> GetDoorsList()
        {
            return GetEnumKeys(typeof(eNumberOfDoors));
        }

        public int GetNumOfColorOptions()
        {
            return Enum.GetValues(typeof(eCarColor)).Length;
        }

        public int GetNumOfDoorOptions()
        {
            return Enum.GetValues(typeof(eNumberOfDoors)).Length;
        }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder(base.ToString());
            carInfo.AppendLine($"Car Color: {m_CarColor}");
            carInfo.AppendLine($"Number of Doors: {m_NumOfDoors}");
            return carInfo.ToString();
        }
    }
}
