using Dapper;
using MajorProjctAPI.iInterface;
using MajorProjctAPI.Model;
using MajorProjctAPI.Repository;
using Newtonsoft.Json;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace MajorProjctAPI.ContactRepository
{
    public class ContactRepository : DbConnector, IContactRepository
    {
        private readonly ILogger<ContactRepository> _logger;

        private IDbConnection _connection;
        public ContactRepository(IConfiguration configuration, ILogger<ContactRepository> logger) : base(configuration)
        {
            _logger = logger;
        }

        // --- Insert/Update ---

        // public async Task<ReturnType<string>> AddContact(User user)
        public async Task<ReturnType<string>> AddContact(User user)
        {
            ReturnType<string> returnStatus = new ReturnType<string>();

            //  ReturnType<string> res = ReturnType<string>();

            DynamicParameters _Parameter = new DynamicParameters();

            try
            {
                _Parameter.Add("@FirstName", user.FirstName);
                _Parameter.Add("@LastName", user.LastName);
                _Parameter.Add("@Email", user.Email);
                _Parameter.Add("@PhoneNumber", user.PhoneNumber);
                _Parameter.Add("@Address", user.Address);
                _Parameter.Add("@City", user.City);
                _Parameter.Add("@State", user.State);
                _Parameter.Add("@Country", user.Country);
                _Parameter.Add("@PostalCode", user.PostalCode);

                _Parameter.Add("@ReturnVal", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);


                using (_connection = GetConnection())
                {
                    await _connection.ExecuteAsync("USP_ContactInsertUpdate", _Parameter, commandType: CommandType.StoredProcedure);
                    returnStatus.ReturnStatus = _Parameter.Get<ReturnStatus>("@ReturnVal");
                    _Parameter.Add("@Result", dbType: DbType.Int16, direction: ParameterDirection.ReturnValue);

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnStatus;
        }


        public async Task<ReturnType<User>> get()
        {
            ReturnType<User> returnStatus = new ReturnType<User>();

            var dyPrms1 = new DynamicParameters();
            dyPrms1.Add("ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            try
            {
                using (_connection = GetConnection())
                {
                    var lstData1 = await _connection.QueryAsync<User>("USP_ContactGET", dyPrms1, commandType: CommandType.StoredProcedure);
                    returnStatus.ReturnList = lstData1.ToList();
                }
                returnStatus.ReturnStatus = dyPrms1.Get<ReturnStatus>("@ReturnValue");
                
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnStatus;
        }


        // -- Delete -- //

        public async Task<ReturnType<string>> UserContact_Delete(User obj)
        {
            ReturnType<string> returnStatus = new ReturnType<string>();

            var dyPrms1 = new DynamicParameters();
            dyPrms1.Add("ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            try
            {
                using (_connection = GetConnection())
                {
                    var lstData1 = await _connection.QueryAsync<string>("USP_Contact_DELETE", dyPrms1, commandType: CommandType.StoredProcedure);
                }
                returnStatus.ReturnStatus = dyPrms1.Get<ReturnStatus>("@ReturnValue");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnStatus;
        }


    }

}