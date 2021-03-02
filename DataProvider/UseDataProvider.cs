using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Test247_WebApi.Models;

namespace Test247_WebApi.DataProvider
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly IConfiguration _configuration;
        public UserDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string ConnectionString()
        {
            string config = "";

            config = _configuration["ConnectionString:BDConStr"];

            return config;
        }

        public async Task AddUser(UserModel item)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString()))
            {

                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CRUD", "C");
                dynamicParameters.Add("@User_ID", null);
                dynamicParameters.Add("@Password", item.password);
                dynamicParameters.Add("@User_Name", item.username);
                await sqlConnection.ExecuteAsync(
                    "procUser_Crude",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UserModel>> GetUser(string UserName, string Password)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString()))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CRUD", "GetUser");
                dynamicParameters.Add("@User_ID", null);
                dynamicParameters.Add("@User_Name", UserName);
                dynamicParameters.Add("@Password", Password);
                return await sqlConnection.QueryAsync<UserModel>(
                 "procUser_Crude",
                 dynamicParameters,
                 commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<UserModel>> GetClientUsers(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString()))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CRUD", "GetClientUsers");
                dynamicParameters.Add("@Client_ID", id);
                dynamicParameters.Add("@Test_ID", null);
                dynamicParameters.Add("@User_ID", null);
                dynamicParameters.Add("@User_Name", null);
                dynamicParameters.Add("@Password", null);
                return await sqlConnection.QueryAsync<UserModel>(
                 "procUser_Crude",
                 dynamicParameters,
                 commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<IEnumerable<UserModel>> GetClientTestUsers(int clientID, int testID)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString()))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CRUD", "GetClientTestUsers");
                dynamicParameters.Add("@Client_ID", clientID);
                dynamicParameters.Add("@Test_ID", testID);
                dynamicParameters.Add("@User_ID", null);
                dynamicParameters.Add("@User_Name", null);
                dynamicParameters.Add("@Password", null);
                return await sqlConnection.QueryAsync<UserModel>(
                 "procUser_Crude",
                 dynamicParameters,
                 commandType: CommandType.StoredProcedure);

            }
        }



    }
}
