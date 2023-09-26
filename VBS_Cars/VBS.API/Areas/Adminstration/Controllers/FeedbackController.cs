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
        [HttpGet]
        [ActionName(APIActionName.FeedbackDetails.GetFeedbackDetailsAsync)]
        public async Task<IActionResult> GetFeedbackDetailsAsync()
        {
            return Ok(await _feedbackService.GetFeedbackDetailsAsync());
        }

        [HttpGet]
        [ActionName(APIActionName.FeedbackDetails.GetFeedbackDetailsByIdAsync)]
        public async Task<IActionResult> GetFeedbackDetailsByIdAsync(int id)
        {
            return Ok(await _feedbackService.GetFeedbackDetailsByIdAsync(id));
        }



        [HttpPost]
        [ActionName(APIActionName.FeedbackDetails.SaveFeedbackDetailsAsync)]
        public async Task<IActionResult> SaveFeedbackDetailsAsync([FromBody] FeedbackDTO _feedbackDTO)
        {
            return Ok(await _feedbackService.SaveFeedbackDetailsAsync(_feedbackDTO));
        }


        [HttpDelete]
        [ActionName(APIActionName.FeedbackDetails.DeleteFeedbackDetailsAsync)]
        public async Task<IActionResult> DeleteFeedbackDetailsAsync(Int64 Id)
        {
            return Ok(await _feedbackService.DeleteFeedbackDetailsAsync(Id));
        }
    }
}
