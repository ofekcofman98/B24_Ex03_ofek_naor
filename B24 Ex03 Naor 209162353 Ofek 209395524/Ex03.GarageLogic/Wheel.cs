namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaximumAirPressure;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;

        public const float k_MaximumAirPressureForMotorcycle = 33f;
        public const float k_MaximumAirPressureForCar = 31f;
        public const float k_MaximumAirPressureForTruck = 28f;

        public Wheel(float i_MaximumAirPressure)
        {
            r_MaximumAirPressure = i_MaximumAirPressure;
        }

        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressure;
            }
        }
        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = MaximumAirPressure;
        }
    }
}
