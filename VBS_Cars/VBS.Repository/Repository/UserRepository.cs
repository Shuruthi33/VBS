using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using VBS.DBEngine;
using VBS.Framework.Helper;
using VBS.Models.Input;
using VBS.Models.Output;
using VBS.Repository.Interface;
using static Dapper.SqlMapper;

namespace VBS.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperHandler _SQLDapperHandler;

        public UserRepository(IDapperHandler SQLDapperHandler)
        {
            _SQLDapperHandler = SQLDapperHandler;
        }
        public async Task<Int16> DeleteUserDetailsAsync(Int64 Id)
        {
            Int16 ReturnValue = 0;
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add(DBParameter.UserDetails.CustomerId, Id, DbType.Int64, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<Int16>(StroredProc.UserDetails.DeleteCustomer, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }

        public async Task<UserDetailsResult> GetUserDetailsAsync()
        {
            UserDetailsResult userDetailResults = new UserDetailsResult();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.UserDetails.CustomerId, 0, DbType.Int32, ParameterDirection.Input);
                userDetailResults.UserDetailsList = (await _SQLDapperHandler.QueryAsync<UserDetailsResponseDTO>(StroredProc.UserDetails.GetCustomerInfo)).ToList();
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return userDetailResults;
        }

        public async Task<UserDetailsResponseDTO> GetUserDetailsByIdAsync(int Id)
        {
            UserDetailsResponseDTO userDetailsDTO = new UserDetailsResponseDTO();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.UserDetails.CustomerId, Id, DbType.Int32, ParameterDirection.Input);
                userDetailsDTO = (await _SQLDapperHandler.QueryFirstOrDefaultAsync<UserDetailsResponseDTO>(StroredProc.UserDetails.GetCustomerById, parameters));
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return userDetailsDTO;
        }

        public async Task<int> SaveUserDetailsAsync(UserDetailsDTO userDetailsDTO)
        {
            var parameters = new DynamicParameters();
            int ReturnValue = 0;
            try
            {
                parameters.Add(DBParameter.UserDetails.CustomerId, userDetailsDTO.CustomerId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.CustomerName, userDetailsDTO.CustomerName, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.Password, HashEncryption.HashPassword(userDetailsDTO.Password),DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.Email, userDetailsDTO.Email, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.Address, userDetailsDTO.Address, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.PhoneNo, userDetailsDTO.PhoneNo, DbType.String, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.RoleId, userDetailsDTO.RoleId, DbType.Int16, ParameterDirection.Input);
                parameters.Add(DBParameter.UserDetails.ImagePath, userDetailsDTO.ImagePath, DbType.String, ParameterDirection.Input);

                ReturnValue = await _SQLDapperHandler.ExecuteScalarAsync<int>(StroredProc.UserDetails.SaveCustomer, parameters);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return ReturnValue;
        }

     
    }
}
