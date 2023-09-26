using Dapper;
using VBS.DBEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Models.Output;
using VBS.Repository.Interface;

namespace VBS.Repository.Repository
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        #region Constructor

        private readonly IDapperHandler _SQLDapperHandler;

        public AuthenticateRepository(IDapperHandler SQLDapperHandler)
        {
            _SQLDapperHandler = SQLDapperHandler;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Authenticate Login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDetailsResult> AuthenticateUserAsync(UserCredential user)
        {
            UserDetailsResult userDetailResult = new UserDetailsResult();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerName", user.CustomerName, DbType.String, ParameterDirection.Input);
                var multipleResults = await _SQLDapperHandler.QueryMultipleAsync("LoginProcess", parameters);
                if (multipleResults != null)
                {
                    userDetailResult.StatusCode = await multipleResults.ReadSingleOrDefaultAsync<Int16>();
                    if (userDetailResult.StatusCode == 200)
                    {
                        userDetailResult.UserDetails = await multipleResults.ReadSingleOrDefaultAsync<UserDetailsDTO>();
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return userDetailResult;
        }

        #endregion Methods
    }
}
