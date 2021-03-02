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
    public class TestDataProvider : ITestDataProvider
    {
        private readonly IConfiguration _configuration;
        public TestDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string ConnectionString()
        {
            string config = "";

            config = _configuration["ConnectionString:BDConStr"];

            return config;
        }

        public async Task AddTest(TestModel item)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString()))
            {

                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CRUD", "C");
                dynamicParameters.Add("@Test_ID", null);
                dynamicParameters.Add("@Testname", item.testname);
                dynamicParameters.Add("@Description", null);
                await sqlConnection.ExecuteAsync(
                    "procTest_Crude",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
