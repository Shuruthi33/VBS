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
    public class BookingRepository: IBookingRepository
    {
        private readonly IDapperHandler _SQLDapperHandler;

        public BookingRepository(IDapperHandler SQLDapperHandler)
        {
            _SQLDapperHandler = SQLDapperHandler;
        }
        public async Task<Int16> DeleteBookingDetailsAsync(Int64 Id)
        {
            Int16 ReturnValue = 0;
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add(DBParameter.BookingDetails.BookingId, Id, DbType.Int64, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<Int16>(StroredProc.BookingDetails.DeleteBooking, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }

        public async Task<BookingDetailsResult> GetBookingDetailsAsync()
        {
            BookingDetailsResult bookingDetailsResult = new BookingDetailsResult();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.BookingDetails.BookingId, 0, DbType.Int32, ParameterDirection.Input);
                bookingDetailsResult.BookingDetailsList = (await _SQLDapperHandler.QueryAsync<BookingDTO>(StroredProc.BookingDetails.GetBookingInfo)).ToList();
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return bookingDetailsResult;
        }

        public async Task<BookingDTO> GetBookingDetailsByIdAsync(int Id)
        {
            BookingDTO bookingDTO = new BookingDTO();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.BookingDetails.BookingId, Id, DbType.Int32, ParameterDirection.Input);
                bookingDTO = (await _SQLDapperHandler.QueryFirstOrDefaultAsync<BookingDTO>(StroredProc.BookingDetails.GetBookingById, parameters));
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return bookingDTO;
        }

        public async Task<int> SaveBookingDetailsAsync(BookingDTO bookingDTO)
        {
            var parameters = new DynamicParameters();
            int ReturnValue = 0;
            try
            {
                parameters.Add(DBParameter.BookingDetails.BookingId, bookingDTO.BookingId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.CustomerId, bookingDTO.CustomerId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.VehicleId, bookingDTO.VehicleId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.BookingDate, bookingDTO.BookingDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.PickupDate, bookingDTO.PickupDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.ReturnDate, bookingDTO.ReturnDate, DbType.Date, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.CancelBooking, bookingDTO.CancelBooking, DbType.Boolean, ParameterDirection.Input);
                parameters.Add(DBParameter.BookingDetails.ReturnStatus, bookingDTO.ReturnStatus, DbType.String, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<int>(StroredProc.BookingDetails.SaveBooking, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }

    }
}
