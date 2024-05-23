using CrudApplication.CommonLayer.Model;
using CrudApplication.CommonUtility;
using CrudApplication.Controllers;
using CrudApplication.ServiceLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        public readonly IConfiguration _configuration;
        ILogger<CrudApplicationRL> _logger;
        public readonly MySqlConnection _mySqlConnection;
        public CrudApplicationRL(IConfiguration configuration, ILogger<CrudApplicationRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _mySqlConnection = new MySqlConnection(_configuration[key: "ConnectionStrings:MySqlDBString"]);
        }
        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            _logger.LogInformation("AddInformation Method Calling In Repository Layer");
            AddInformationResponse response = new AddInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Added";

            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                   await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.AddInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Mobile", request.Mobile);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Gender", request.Gender);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occur : Query Not Executed");
                        return response;
                    }
                }
                {

                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occur At AddInformation Repository Layer : Message {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response; 
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Get";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.readAllInformation = new List<GetReadAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation getdata = new GetReadAllInformation();
                                    getdata.UserId = dataReader[name: "UserId"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "UserId"]) : 0;
                                    getdata.UserName = dataReader[name: "UserName"] != DBNull.Value ? Convert.ToString(dataReader[name: "UserName"]) :String.Empty;
                                    getdata.EmailId = dataReader[name: "EmailId"] != DBNull.Value ? Convert.ToString(dataReader[name: "EmailId"]) : String.Empty;
                                    getdata.Mobile = dataReader[name: "Mobile"] != DBNull.Value ? Convert.ToString(dataReader[name: "Mobile"]) : String.Empty;
                                    getdata.Salary = dataReader[name: "Salary"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "Salary"]) : 0;
                                    getdata.Gender = dataReader[name: "Gender"] != DBNull.Value ? Convert.ToString(dataReader[name: "Gender"]) : String.Empty;
                                    getdata.IsActive = dataReader[name: "IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader[name: "IsActive"]) : false;
                                    response.readAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Foud / Database Empty";
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetAllInformation Error Occur : Message" + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();

                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetAllInformation Error Occur : Message" + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateAllInformationById Method Calling In Repository Layer");
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Updated";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.UpdateAllInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Mobile", request.Mobile);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Gender", request.Gender);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occur : Query Not Executed");
                        return response;
                    }
                }
               
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occur At UpdateAllInformationById Repository Layer : Message {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation("DeleteInformationById Method Calling In Repository Layer");
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Deleted";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.DeleteInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserId", request.UserId);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occur : Query Not Executed");
                        return response;
                    }
                }
                {

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occur At DeleteInformationById Repository Layer : Message {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<GetDeleteReadAllInformationResponse> GetDeleteReadAllInformation()
        {
            GetDeleteReadAllInformationResponse response = new GetDeleteReadAllInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Get";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetDeleteReadAllInformation, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getreadAllInformation = new List<GetDeleteReadAllInformation>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetDeleteReadAllInformation getdata = new GetDeleteReadAllInformation();
                                    getdata.UserId = dataReader[name: "UserId"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "UserId"]) : 0;
                                    getdata.UserName = dataReader[name: "UserName"] != DBNull.Value ? Convert.ToString(dataReader[name: "UserName"]) : String.Empty;
                                    getdata.EmailId = dataReader[name: "EmailId"] != DBNull.Value ? Convert.ToString(dataReader[name: "EmailId"]) : String.Empty;
                                    getdata.Mobile = dataReader[name: "Mobile"] != DBNull.Value ? Convert.ToString(dataReader[name: "Mobile"]) : String.Empty;
                                    getdata.Salary = dataReader[name: "Salary"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "Salary"]) : 0;
                                    getdata.Gender = dataReader[name: "Gender"] != DBNull.Value ? Convert.ToString(dataReader[name: "Gender"]) : String.Empty;
                                    getdata.IsActive = dataReader[name: "IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader[name: "IsActive"]) : false;
                                    response.getreadAllInformation.Add(getdata);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Foud / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("GetAllInformation Error Occur : Message" + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("GetAllInformation Error Occur : Message" + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<DeleteAllInformationResposne> DeleteAllInformation()
        {
            _logger.LogInformation("DeleteAllInformation Method Calling In Repository Layer");
            DeleteAllInformationResposne response = new DeleteAllInformationResposne();
            response.IsSuccess = true;
            response.Message = "Successfully Deleted";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.DeleteAllInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
       
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occur : Query Not Executed");
                        return response;
                    }
                }
                {

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occur At DeleteAllInformation Repository Layer : Message {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request)
        {
            ReadInformationByIdResponse response = new ReadInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Get";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadInformationById, _mySqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        sqlCommand.Parameters.AddWithValue(parameterName: "@UserId", request.UserId);

                        using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getreadInformationById = new List<GetreadInformationById>();

                                while (await dataReader.ReadAsync())
                                {
                                    GetreadInformationById getdata = new GetreadInformationById();
                                    getdata.UserId = dataReader[name: "UserId"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "UserId"]) : 0;
                                    getdata.UserName = dataReader[name: "UserName"] != DBNull.Value ? Convert.ToString(dataReader[name: "UserName"]) : String.Empty;
                                    getdata.EmailId = dataReader[name: "EmailId"] != DBNull.Value ? Convert.ToString(dataReader[name: "EmailId"]) : String.Empty;
                                    getdata.Mobile = dataReader[name: "Mobile"] != DBNull.Value ? Convert.ToString(dataReader[name: "Mobile"]) : String.Empty;
                                    getdata.Salary = dataReader[name: "Salary"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "Salary"]) : 0;
                                    getdata.Gender = dataReader[name: "Gender"] != DBNull.Value ? Convert.ToString(dataReader[name: "Gender"]) : String.Empty;
                                    getdata.IsActive = dataReader[name: "IsActive"] != DBNull.Value ? Convert.ToBoolean(dataReader[name: "IsActive"]) : false;
                                    response.getreadInformationById.Add(getdata);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Foud / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError("ReadInformationById Error Occur : Message" + ex.Message);
                    }
                    finally
                    {
                        await sqlCommand.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError("ReadInformationById Error Occur : Message" + ex.Message);
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }

        public async Task<UpdateOneInformationByIdResponse> UpdateOneInformationById(UpdateOneInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateOneInformationById Method Calling In Repository Layer");
            UpdateOneInformationByIdResponse response = new UpdateOneInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successfully Updated";

            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.UpdateOneInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Salary", request.Salary);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError("Error Occur : Query Not Executed");
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"Error Occur At UpdateOneInformationById Repository Layer : Message {ex.Message}");
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }
    }
}
