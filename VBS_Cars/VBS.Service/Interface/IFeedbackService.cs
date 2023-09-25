using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models;

namespace VBS.Service.Interface
{
    public interface IFeedbackService
    {
        Task<ResultDataArgs> GetFeedbackDetailsAsync();

        Task<ResultDataArgs> GetFeedbackDetailsByIdAsync(int Id);
        Task<ResultDataArgs> SaveFeedbackDetailsAsync(FeedbackDTO feedbackDTO);

        Task<ResultDataArgs> DeleteFeedbackDetailsAsync(Int64 Id);
    }
}
