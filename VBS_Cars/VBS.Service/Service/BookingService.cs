using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Models;
using VBS.Repository.Interface;
using VBS.Service.Interface;

namespace VBS.Service.Service
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository BookingRepository)
        {
            _bookingRepository = BookingRepository;
        }
        public async Task<ResultDataArgs> DeleteBookingDetailsAsync(Int64 Id)
        {
            var RresultArgs = new ResultDataArgs();
            try
            {

                var objUserDetail = await _bookingRepository.DeleteBookingDetailsAsync(Id);
                RresultArgs.MessageTitle = MessageCatalog.MessageTitle.BookingDetails;

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

        public async Task<ResultDataArgs> GetBookingDetailsAsync()
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                var objUserDetail = await _bookingRepository.GetBookingDetailsAsync();

                ResultDataArgs.MessageTitle = MessageCatalog.MessageTitle.UserDetails;

                if (objUserDetail != null)
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.Success;
                    ResultDataArgs.ResultData = objUserDetail.BookingDetailsList;
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

        public async Task<ResultDataArgs> GetBookingDetailsByIdAsync(int Id)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                var objUserDetail = await _bookingRepository.GetBookingDetailsByIdAsync(Id);
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

        public async Task<ResultDataArgs> SaveBookingDetailsAsync(BookingDTO bookingDTO)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                int objUserDetail = await _bookingRepository.SaveBookingDetailsAsync(bookingDTO);
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
