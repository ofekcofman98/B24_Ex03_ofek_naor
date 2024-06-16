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
            //
        }
        private enum eCarColor
        {
            Yellow = 1,
            White = 2,
            Red = 3,
            Black = 4
        }

        private enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder(base.ToString());
            carInfo.AppendLine($"Car Color: {m_CarColor}");
            carInfo.AppendLine($"Number of Doors: {m_NumOfDoors}");
            return carInfo.ToString();
        }
        //public static Car CreateNewCar(string i_LicensePlate, Engine i_Engine)
        //{
        //    return new Car(i_LicensePlate, i_Engine);
        //}
    }
}
