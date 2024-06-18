using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.VehicleCreator;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private const int k_GarageEmpty = 0;

        Dictionary<string, VehicleRecordInfo> m_VehiclesInGarageDict = new Dictionary<string, VehicleRecordInfo>();

        public bool IsGarageEmpty()
        {
            return m_VehiclesInGarageDict.Count == k_GarageEmpty;
        }

        public bool IsVehicleInGarage(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict.ContainsKey(i_LicensePlateNumber);
        }

        public bool CheckVehicleTypeInputValidation(string i_InputString, out int io_InputNumber)
        {
            bool isValid = false;

            if(int.TryParse(i_InputString, out io_InputNumber))
            {
                if(io_InputNumber >= 1 && io_InputNumber <= VehicleCreator.GetNumOfVehiclesType()) // if number is in the range of static num of type
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public string GetVehicleStatus(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].VehicleStatus.ToString();
        }

        public void ChangeVehicleStatusToInRepair(string i_LicensePlate)
        {
            m_VehiclesInGarageDict[i_LicensePlate].ChangeVehicleStatus(VehicleRecordInfo.eVehicleStatus.InRepair);
        }

        public List<string> GetVehicleTypeList()
        {
            return VehicleCreator.GetVehiclesTypes();
        }

        public List<int> GetLicensePlatesList()
        {
            List<int> licensePlatesList = new List<int>(m_VehiclesInGarageDict.Count);

            foreach(KeyValuePair<string, VehicleRecordInfo> vehicleRecordInfo in m_VehiclesInGarageDict)
            {
                licensePlatesList.Add(int.Parse(vehicleRecordInfo.Value.Vehicle.LicensePlate));
            }

            return licensePlatesList;
        }

        public List<string> GetLicensePlatesListByFilter(int i_UserChoice) 
        {

            if (!(i_UserChoice >= (int)VehicleRecordInfo.eVehicleStatus.InRepair && i_UserChoice <= (int)VehicleRecordInfo.eVehicleStatus.Paid))
            {// argument?
                throw new ValueOutOfRangeException((float)VehicleRecordInfo.eVehicleStatus.InRepair, (float)VehicleRecordInfo.eVehicleStatus.Paid);
            }

            List<string> licensePlatesList = new List<string>(m_VehiclesInGarageDict.Count);

            foreach (KeyValuePair<string, VehicleRecordInfo> vehicleRecordInfo in m_VehiclesInGarageDict)
            {
                if((int)vehicleRecordInfo.Value.VehicleStatus == i_UserChoice)
                {
                    licensePlatesList.Add((vehicleRecordInfo.Value.Vehicle.LicensePlate));
                }
            }

            return licensePlatesList;
        }


        public void ChangeVehicleStatus(string i_LicensePlateNumber, int i_UserPick)
        {
            if (!(i_UserPick >= (int)VehicleRecordInfo.eVehicleStatus.InRepair && i_UserPick <= (int)VehicleRecordInfo.eVehicleStatus.Paid))
            {// argument?
                throw new ValueOutOfRangeException((float)VehicleRecordInfo.eVehicleStatus.InRepair, (float)VehicleRecordInfo.eVehicleStatus.Paid);
            }

            m_VehiclesInGarageDict[i_LicensePlateNumber].VehicleStatus = (VehicleRecordInfo.eVehicleStatus)i_UserPick;
        }

        public void InflateTiresToMaximum(string i_LicensePlateNumber)
        {
            m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.InflateTiresToMax();
        }

        public string GetVehicleDetails(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].ToString();
        }

        public string GetTypeOfEnergy(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.Engine.GetTypeOfEnergy();
        }

        public void SetAirPressureToAllWheels(string i_LicensePlateNumber, float i_AirPressure, string i_WheelsManufacturer)
        {
            // validation for: float
            //                 in range (between 0 and MaxAirPressure)
            List<Wheel> currentVehicleWheelList = m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.WheelsList;
            foreach(Wheel wheel in currentVehicleWheelList)
            {
                wheel.CurrentAirPressure = i_AirPressure;
                wheel.Manufacturer = i_WheelsManufacturer;
            }
        }


        public void SetCurrentAmountOfEnergy(string i_LicensePlateNumber, float i_CurrnetAmountOfEnergy)
        {
            // validation for: float
            //                 in range (between 0 and EnergyCapacity)
            m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.Engine.SetCurrentAmountAndPercentageOfEnergy(i_CurrnetAmountOfEnergy);
        }

        public void AddNewVehicleToGarage(string i_LicensePlate, int i_VehicleTypeNumber, string i_OwnerName, string i_OwnerPhone)
        {
            eVehicleType vehicleType = (eVehicleType)i_VehicleTypeNumber;
            Vehicle newVehicle = CreateNewVehicle(i_LicensePlate, vehicleType);
            VehicleRecordInfo vehicleRecordInfo = new VehicleRecordInfo(i_OwnerName, i_OwnerPhone);
            vehicleRecordInfo.Vehicle = newVehicle;
            m_VehiclesInGarageDict.Add(i_LicensePlate, vehicleRecordInfo);
        }

        public void AddEnergy(string i_LicensePlateNumber, FuelEngine.eFuelType? i_FuelType, float i_AmountOfEnergy)
        {
            m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.Engine.AddEnergy(
                i_LicensePlateNumber,
                i_FuelType,
                i_AmountOfEnergy);
        }

        public void SetModelName(string i_LicensePlate, string i_ModelName)
        {
            m_VehiclesInGarageDict[i_LicensePlate].Vehicle.ModelName = i_ModelName;
        }

        public Dictionary<string, Type> GetVehicleRequiredDataFields(string i_LicensePlateNumber)
        {
            return m_VehiclesInGarageDict[i_LicensePlateNumber].Vehicle.GetRequiredDataFields();
        }

        public void SetSpecificData(string i_LicensePlate, Dictionary<string, string> i_SpecificData)
        {
            m_VehiclesInGarageDict[i_LicensePlate].Vehicle.SetSpecificData(i_SpecificData);
        }

        public float GetMaximumAirPressure(string i_LicensePlate)
        {
            return m_VehiclesInGarageDict[i_LicensePlate].Vehicle.WheelsList[0].MaximumAirPressure;
        }

        public float GetEnergyCapacity(string i_LicensePlate)
        {
            return m_VehiclesInGarageDict[i_LicensePlate].Vehicle.Engine.EnergyCapacity;
        }
    }
}
