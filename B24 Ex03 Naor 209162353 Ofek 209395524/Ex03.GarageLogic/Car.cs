using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumOfDoors;

        private const string k_CarColor = "car color";
        private const string k_NumberOfDoors = "number of doors";

        public const int k_NumberOfWheels = 5;

        public Car(string i_LicensePlate, Engine i_Engine) : base(i_LicensePlate, i_Engine)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_WheelsList.Add(new Wheel(Wheel.k_MaximumAirPressureForCar));
            }
        }

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

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }
        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }

        public override Dictionary<string, Type> GetRequiredDataFields()
        {
            return new Dictionary<string, Type>
                       {
                           { "Car Color", typeof(eCarColor) },
                           { "Number of Doors", typeof(eNumberOfDoors) }
                       };
        }

        public override void SetSpecificData(Dictionary<string, string> i_Data)
        {
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_Data["Car Color"]);
            m_NumOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_Data["Number of Doors"]);
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
