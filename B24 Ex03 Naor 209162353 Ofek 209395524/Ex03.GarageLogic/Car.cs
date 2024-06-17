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

        public override void SetSpecificData()
        {

            
            //int j = HelperFunctions.EnumChoosing(k_CarColor, GetColorsList());
            //this.CarColor = (eCarColor)j;

            //HelperFunctions.EnumChoosing(k_NumberOfDoors, GetColorsList());
            Console.WriteLine($"Please enter {k_CarColor}: ");
            PrintList(GetColorsList(),i_IsListNumbered: true);
            int i_CarColorChoice;
            while (true)
            {
                string carColorChoiceString = Console.ReadLine();
                int.TryParse(carColorChoiceString, out i_CarColorChoice);

                if(!(i_CarColorChoice >= 1 && i_CarColorChoice <= GetColorsList().Count))
                {
                    Console.WriteLine($"Invalid input. Please input a number between 1 and {GetColorsList().Count}");
                }
                else
                {
                    break;
                }
            }
            this.CarColor = (eCarColor)i_CarColorChoice;

            Console.WriteLine($"Please enter {k_NumberOfDoors}: ");
            PrintList(GetColorsList(), i_IsListNumbered: true);
            int i_NumOfDoorsChoice;
            while (true)
            {
                string i_NumOfDoorsChoiceString = Console.ReadLine();
                int.TryParse(i_NumOfDoorsChoiceString, out i_NumOfDoorsChoice);

                if (!(i_NumOfDoorsChoice >= 1 && i_NumOfDoorsChoice <= GetColorsList().Count))
                {
                    Console.WriteLine($"Invalid input. Please input a number between 1 and {GetColorsList().Count}");
                }
                else
                {
                    break;
                }
            }
            this.NumberOfDoors = (eNumberOfDoors)i_NumOfDoorsChoice;
        }

        //public override Dictionary<string, string> GetSpecificData()
        //{
        //    Console.WriteLine("Enter ");
        //}

        //public override Dictionary<string, string> SpecificData
        //{
        //    get
        //    {
        //        return new Dictionary<string, string>(m_SpecificData);
        //    }
        //}



        public enum eCarColor
        {
            Yellow = 1,
            White = 2,
            Red = 3,
            Black = 4
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

        //public int GetNumOfColorOptions()
        //{
        //    return Enum.GetValues(typeof(eCarColor)).Length;
        //}

        //public int GetNumOfDoorOptions()
        //{
        //    return Enum.GetValues(typeof(eNumberOfDoors)).Length;
        //}

        public static void PrintList<T>(List<T> i_List, bool i_IsListNumbered = false) // Fix names
        {
            int i = 1;

            foreach (T item in i_List)
            {
                if (i_IsListNumbered)
                {
                    Console.WriteLine($"{i}. {item}");
                    i++;
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
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
