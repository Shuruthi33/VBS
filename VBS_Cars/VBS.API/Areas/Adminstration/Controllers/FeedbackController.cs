using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Service.Interface;

namespace VBS.API.Areas.Adminstration.Controllers
{
    [Produces(AuthAPIController.InputType.ApplicationJson)]
    [ApiController]
    [Route(AuthAPIController.Property.APIController)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FeedbackController : ControllerBase
    {
        public readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        /// <summary>
        /// Get and View tha Feedback Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.FeedbackDetails.GetFeedbackDetailsAsync)]
        public async Task<IActionResult> GetFeedbackDetailsAsync()
        {
            return Ok(await _feedbackService.GetFeedbackDetailsAsync());
        }
        /// <summary>
        /// Get the Feedback ById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName(APIActionName.FeedbackDetails.GetFeedbackDetailsByIdAsync)]
        public async Task<IActionResult> GetFeedbackDetailsByIdAsync(int id)
        {
            return Ok(await _feedbackService.GetFeedbackDetailsByIdAsync(id));
        }

        /// <summary>
        /// Insert the FeedBack Details
        /// </summary>
        /// <param name="_feedbackDTO"></param>
        /// <returns></returns>

        [HttpPost]
        [ActionName(APIActionName.FeedbackDetails.SaveFeedbackDetailsAsync)]
        public async Task<IActionResult> SaveFeedbackDetailsAsync([FromBody] FeedbackDTO _feedbackDTO)
        {
            return Ok(await _feedbackService.SaveFeedbackDetailsAsync(_feedbackDTO));
        }

        /// <summary>
        /// Delete the Feedback Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName(APIActionName.FeedbackDetails.DeleteFeedbackDetailsAsync)]
        public async Task<IActionResult> DeleteFeedbackDetailsAsync(Int64 Id)
        {
            return Ok(await _feedbackService.DeleteFeedbackDetailsAsync(Id));
        }
    }
}
