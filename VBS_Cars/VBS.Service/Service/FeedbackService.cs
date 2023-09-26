using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Framework.Helper;
using VBS.Models;
using VBS.Models.Input;
using VBS.Repository.Interface;
using VBS.Repository.Repository;
using VBS.Service.Interface;

namespace VBS.Service.Service
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<ResultDataArgs> DeleteFeedbackDetailsAsync(Int64 Id)
        {
            var RresultArgs = new ResultDataArgs();
            try
            {

                var objUserDetail = await _feedbackRepository.DeleteFeedbackDetailsAsync(Id);
                RresultArgs.MessageTitle = MessageCatalog.MessageTitle.FeedbackDetails;

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

        public async Task<ResultDataArgs> GetFeedbackDetailsAsync()
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                var objUserDetail = await _feedbackRepository.GetFeedbackDetailsAsync();

                ResultDataArgs.MessageTitle = MessageCatalog.MessageTitle.FeedbackDetails;

                if (objUserDetail != null)
                {
                    ResultDataArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = MessageCatalog.ErrorMessages.Success;
                    ResultDataArgs.ResultData = objUserDetail.FeedbackDetailsList;
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

        public async Task<ResultDataArgs> GetFeedbackDetailsByIdAsync(int Id)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                var objUserDetail = await _feedbackRepository.GetFeedbackDetailsByIdAsync(Id);
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

        public async Task<ResultDataArgs> SaveFeedbackDetailsAsync(FeedbackDTO feedbackDTO)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                int objUserDetail = await _feedbackRepository.SaveFeedbackDetailsAsync(feedbackDTO);
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



