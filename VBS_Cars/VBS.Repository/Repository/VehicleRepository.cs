using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.DBEngine;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Models.Output;
using VBS.Repository.Interface;

namespace VBS.Repository.Repository
{
    public class VehicleRepository: IVehicleRepository
    {
        private readonly IDapperHandler _SQLDapperHandler;

        public VehicleRepository(IDapperHandler SQLDapperHandler)
        {
            _SQLDapperHandler = SQLDapperHandler;
        }

        public async Task<Int16> DeleteVehicleDetailsAsync(Int64 Id)
        {
            Int16 ReturnValue = 0;
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add(DBParameter.VehicleDetails.VehicleId, Id, DbType.Int64, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<Int16>(StroredProc.VehicleDetails.DeleteVehicle, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }

        public async Task<VehicleDetailsResult> GetVehicleDetailsAsync()
        {
            VehicleDetailsResult vehicleDetailsResult = new VehicleDetailsResult();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.VehicleDetails.VehicleId, 0, DbType.Int32, ParameterDirection.Input);
                vehicleDetailsResult.VehicleDetailsList = (await _SQLDapperHandler.QueryAsync<VehicleDetailsDTO>(StroredProc.VehicleDetails.GetVehicleInfo)).ToList();
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return vehicleDetailsResult;
        }

        public async Task<VehicleDetailsDTO> GetVehicleDetailsByIdAsync(int Id)
        {
            VehicleDetailsDTO vehicleDetailsDTO = new VehicleDetailsDTO();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.VehicleDetails.VehicleId, Id, DbType.Int32, ParameterDirection.Input);
                vehicleDetailsDTO = (await _SQLDapperHandler.QueryFirstOrDefaultAsync<VehicleDetailsDTO>(StroredProc.VehicleDetails.GetVehicleById, parameters));
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return vehicleDetailsDTO;
        }

        public async Task<int> SaveVehicleDetailsAsync(VehicleDetailsDTO vehicleDetailsDTO)
        {
            var parameters = new DynamicParameters();
            int ReturnValue = 0;
            try
            {
                parameters.Add(DBParameter.VehicleDetails.VehicleId, vehicleDetailsDTO.VehicleId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Make, vehicleDetailsDTO.Make, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Model, vehicleDetailsDTO.Model, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Year, vehicleDetailsDTO.Year, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Price, vehicleDetailsDTO.Price, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Mileage, vehicleDetailsDTO.Mileage, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.LicensePlate, vehicleDetailsDTO.LicensePlate, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Colour, vehicleDetailsDTO.Colour, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.VIN, vehicleDetailsDTO.VIN, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.EngineType, vehicleDetailsDTO.EngineType, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.EngineSize, vehicleDetailsDTO.EngineSize, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.FuelType, vehicleDetailsDTO.FuelType, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.FuelTank, vehicleDetailsDTO.FuelTank, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.SeatingCapacity, vehicleDetailsDTO.SeatingCapacity, DbType.Int32, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Condition, vehicleDetailsDTO.Condition, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Features, vehicleDetailsDTO.Features, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.VersionName, vehicleDetailsDTO.VersionName, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.ExShowroomPrice, vehicleDetailsDTO.ExShowroomPrice, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.RTO, vehicleDetailsDTO.RTO, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Insurance, vehicleDetailsDTO.Insurance, DbType.Decimal, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.ImageURLs, vehicleDetailsDTO.ImageURLs, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.VideoURLs, vehicleDetailsDTO.VideoURLs, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.VehicleDetails.Availability, vehicleDetailsDTO.Availability, DbType.Boolean, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<int>(StroredProc.VehicleDetails.SaveVehicles, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }
    }
}
