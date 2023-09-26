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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IDapperHandler _SQLDapperHandler;

        public FeedbackRepository(IDapperHandler SQLDapperHandler)
        {
            _SQLDapperHandler = SQLDapperHandler;
        }
        public async Task<Int16> DeleteFeedbackDetailsAsync(Int64 Id)
        {
            Int16 ReturnValue = 0;
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add(DBParameter.FeedbackDetails.FeedbackId, Id, DbType.Int64, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<Int16>(StroredProc.FeedbackDetails.DeleteFeedback, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }

        public async Task<FeedbackDetailsResult> GetFeedbackDetailsAsync()
        {
            FeedbackDetailsResult feedbackDetailsResult = new FeedbackDetailsResult();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.FeedbackDetails.FeedbackId, 0, DbType.Int32, ParameterDirection.Input);
                feedbackDetailsResult.FeedbackDetailsList = (await _SQLDapperHandler.QueryAsync<FeedbackResponseDTO>(StroredProc.FeedbackDetails.GetFeedback)).ToList();
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return feedbackDetailsResult;
        }

        public async Task<FeedbackResponseDTO> GetFeedbackDetailsByIdAsync(int Id)
        {
            FeedbackResponseDTO feedbackDTO = new FeedbackResponseDTO();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.FeedbackDetails.FeedbackId, Id, DbType.Int32, ParameterDirection.Input);
                feedbackDTO = (await _SQLDapperHandler.QueryFirstOrDefaultAsync<FeedbackResponseDTO>(StroredProc.FeedbackDetails.GetFeedbackById, parameters));
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return feedbackDTO;
        }

        public async Task<int> SaveFeedbackDetailsAsync(FeedbackDTO feedbackDTO)
        {
            var parameters = new DynamicParameters();
            int ReturnValue = 0;
            try
            {
                parameters.Add(DBParameter.FeedbackDetails.FeedbackId, feedbackDTO.FeedbackId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.FeedbackDetails.BookingId, feedbackDTO.BookingId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.FeedbackDetails.Rating, feedbackDTO.Rating, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.FeedbackDetails.Comment, feedbackDTO.Comment, DbType.String, ParameterDirection.Input);
               
                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<int>(StroredProc.FeedbackDetails.SaveFeedback, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }
    }
 }

