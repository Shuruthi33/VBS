using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Framework.Helper;
using VBS.Models;
using VBS.Models.Input;
using VBS.Repository.Interface;
using VBS.Service.Interface;

namespace VBS.Service.Service
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleService (IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<ResultDataArgs> DeleteVehicleDetailsAsync(Int64 Id)
        {
            var RresultArgs = new ResultDataArgs();
            try
            {

                var objUserDetail = await _vehicleRepository.DeleteVehicleDetailsAsync(Id);
                RresultArgs.MessageTitle = MessageCatalog.MessageTitle.UserDetails;

                if (RresultArgs.StatusCode == 0)
                {
                    RresultArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    RresultArgs.StatusMessage = MessageCatalog.ErrorMessages.DeleteSuccess;
                }
                else
                {
                    RresultArgs.StatusCode = MessageCatalog.ErrorCodes.Failed;
                    RresultArgs.StatusMessage = MessageCatalog.ErrorMessages.DeleteFailed;
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return (RresultArgs);
        }

        public async Task<ResultDataArgs> GetVehicleDetailsAsync()
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                var objUserDetail = await _vehicleRepository.GetVehicleDetailsAsync();

                ResultDataArgs.MessageTitle = MessageCatalog.MessageTitle.UserDetails;

                if (objUserDetail != null)
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.Success;
                    ResultDataArgs.ResultData = objUserDetail.VehicleDetailsList;
                }
                else
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.NoRecordFound;
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ResultDataArgs;
        }

        public async Task<ResultDataArgs> GetVehicleDetailsByIdAsync(int Id)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                var objUserDetail = await _vehicleRepository.GetVehicleDetailsByIdAsync(Id);
                if (objUserDetail != null)
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.Success;
                    ResultDataArgs.ResultData = objUserDetail;
                }
                else
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.NoRecordFound;
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ResultDataArgs;
        }
    

        public async Task<ResultDataArgs> SaveVehicleDetailsAsync(VehicleDetailsDTO vehicleDetailsDTO)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                int objUserDetail = await _vehicleRepository.SaveVehicleDetailsAsync(vehicleDetailsDTO);
                if (objUserDetail == 200)
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.SaveSuccess;

                }
                else
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.Failed;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.SaveFailed;
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ResultDataArgs;
        }
    

    }
}
