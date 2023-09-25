using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models;
using VBS.Models.Input;
using VBS.Repository.Interface;
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

        public Task<ResultDataArgs> DeleteFeedbackDetailsAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataArgs> GetFeedbackDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataArgs> GetFeedbackDetailsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataArgs> SaveFeedbackDetailsAsync(FeedbackDTO feedbackDTO)
        {
            throw new NotImplementedException();
        }
    }
}
