using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models.Output;

namespace VBS.Repository.Interface
{
    public interface IFeedbackRepository
    {
        Task<FeedbackDetailsResult> GetFeedbackDetailsAsync();
        Task<FeedbackDTO> GetFeedbackDetailsByIdAsync(int Id);
        Task<int> SaveFeedbackDetailsAsync(FeedbackDTO feedbackDTO);
        Task<Int16> DeleteFeedbackDetailsAsync(Int64 Id);
    }
}
