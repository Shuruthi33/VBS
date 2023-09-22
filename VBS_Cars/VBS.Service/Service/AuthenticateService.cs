using VBS.Framework;
using VBS.Framework.Helper;
using VBS.Models;
using VBS.Models.Input;
using VBS.Models.Output;
using VBS.Repository.Interface;
using VBS.Service.Interface;


namespace VBS.Service.Service
{
	public class AuthenticateService : IAuthenticateService
	{
		private readonly IAuthenticateRepository _authRepository;

		#region Constructor

		public AuthenticateService(IAuthenticateRepository authRepository)
		{
			this._authRepository = authRepository;
		}

		#endregion Constructor

		#region Methods

		/// <summary>
		/// Authenticate User service
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<UserDetailsResult> AuthenticateUserAsync(UserCredential user)
		{
			UserDetailsResult objUserDetail = new UserDetailsResult();
			var ResultArgs = new UserDetailsResult();
			try
			{
				string str = HashEncryption.HashPassword(user.Password);


                objUserDetail = await _authRepository.AuthenticateUserAsync(user);
				if (objUserDetail.UserDetails != null)
				{
					if (HashEncryption.VerifyPassword(objUserDetail.UserDetails.Password, user.Password))
                    {
						ResultArgs.StatusCode = MessageCatalog.ErrorCodes.Success;
						ResultArgs.StatusMessage = MessageCatalog.ErrorMessages.Success;


						ResultArgs.UserDetails = objUserDetail.UserDetails; 
					}
					else
					{
						ResultArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
						ResultArgs.StatusMessage = MessageCatalog.ErrorMessages.PasswordIncorrect;

                        ResultArgs.UserDetails = objUserDetail.UserDetails;
                    }
				}
				else
				{
					if (objUserDetail.StatusCode == 200)
					{
						ResultArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
						ResultArgs.StatusMessage = MessageCatalog.ErrorMessages.UserNameNotExists;
					}
					else if (objUserDetail.StatusCode == -91)
					{
						ResultArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
						ResultArgs.StatusMessage = MessageCatalog.ErrorMessages.UserNameNotExists;
					}
					else if (objUserDetail.StatusCode == -92)
					{
						ResultArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
						ResultArgs.StatusMessage = MessageCatalog.ErrorMessages.PasswordIncorrect;
					}
					else
					{
						ResultArgs.StatusCode = MessageCatalog.ErrorCodes.NoRecordFound;
						ResultArgs.StatusMessage = MessageCatalog.ErrorMessages.UserNameNotExists;
					}
				}
			}
			catch (Exception ex)
			{
				new ErrorLog().WriteLog(ex);
			}
			return ResultArgs;
		}

       

        #endregion Methods
    }
}