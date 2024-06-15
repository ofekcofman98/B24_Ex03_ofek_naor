using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly float  r_MaximalAmountOfGas;
        private float m_CurrentAmountOfGas;
        private eFuelType m_FuelType; // readonly? 
        private enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler,
        }

        public void AddFuel(float i_LitersToAdd, int i_FuelType)
        {

        }
    }
}
