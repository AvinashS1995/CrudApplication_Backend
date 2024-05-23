using CrudApplication.CommonLayer.Model;
using CrudApplication.RepositoryLayer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudApplication.ServiceLayer
{
    public class CrudApplicationSL : ICrudApplicationSL
    {
        public readonly ICrudApplicationRL _crudApplicationRL;
        public readonly ILogger<CrudApplicationSL> _logger;
        public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string MobileRegex = @"([1-9]{1}[0-9]{9})$";
        public readonly string GenderRegex = @"^(?:m|M|male|Male|f|F|female|Female)$";
        public CrudApplicationSL(ICrudApplicationRL crudApplicationRL, ILogger<CrudApplicationSL> logger)
        {
            _crudApplicationRL = crudApplicationRL;
            _logger = logger;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {

            /* 
             AddInformationResponse response = new AddInformationResponse();

             if (String.IsNullOrEmpty(request.UserName))
             {
                 response.IsSuccess = false;
                 response.Message = "UserName Can't Null or Empty";
                 return response;
             }

             if (String.IsNullOrEmpty(request.EmailID))
             {
                 response.IsSuccess = false;
                 response.Message = "Email Id Can't Null or Empty";
                 return response;
             }
             else
             {
                 if(!(Regex.IsMatch(request.EmailID, EmailRegex)))
                 {
                     response.IsSuccess = false;
                     response.Message = "Email Id Not In Correct Format Example: developer@gmail.com";
                     return response;
                 }
             }

             if (String.IsNullOrEmpty(request.Mobile))
             {
                 response.IsSuccess = false;
                 response.Message = "Mobile Can't Null or Empty";
                 return response;
             }
             else
             {
                 if(!(Regex.IsMatch(request.Mobile, MobileRegex)))
                 {
                     response.IsSuccess = false;
                     response.Message = "Mobile Number Not In Correct Format Example: 9865142536";
                     return response;
                 }
             }

             if (request.Salary <= 0)
             {
                 response.IsSuccess = false;
                 response.Message = "Salary Can't Null or Empty";
                 return response;
             }

             if (String.IsNullOrEmpty(request.Gender))
             {
                 response.IsSuccess = false;
                 response.Message = "Gender Can't Null or Empty";
                 return response;
             }
             else
             {
                 if (!(Regex.IsMatch(request.Gender, GenderRegex)))
                 {
                     response.IsSuccess = false;
                     response.Message = "Gender Not In Correct Format Example: m, M, male, Male, f, F, female, Female";
                     return response;
                 }
             }

            */


            _logger.LogInformation("AddInformation Method Calling In Service Layer");
            return await _crudApplicationRL.AddInformation(request);
        }

        public async Task<DeleteAllInformationResposne> DeleteAllInformation()
        {
            _logger.LogInformation("DeleteAllInformation Method Calling In Service Layer");
            return await _crudApplicationRL.DeleteAllInformation();
        }

        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation("AddInformation Method Calling In Service Layer");
            return await _crudApplicationRL.DeleteInformationById(request);
        }

        public async Task<GetDeleteReadAllInformationResponse> GetDeleteReadAllInformation()
        {
            _logger.LogInformation("GetDeleteReadAllInformation Method Calling In Service Layer");
            return await _crudApplicationRL.GetDeleteReadAllInformation();
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            _logger.LogInformation("ReadAllInformation Method Calling In Service Layer");
            return await _crudApplicationRL.ReadAllInformation();
        }

        public async Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request)
        {
            _logger.LogInformation("ReadInformationById Method Calling In Service Layer");
            return await _crudApplicationRL.ReadInformationById(request);
        }

        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateAllInformation Method Calling In Service Layer");
            return await _crudApplicationRL.UpdateAllInformationById(request);
        }

        public async Task<UpdateOneInformationByIdResponse> UpdateOneInformationById(UpdateOneInformationByIdRequest request)
        {
            _logger.LogInformation("UpdateOneInformationById Method Calling In Service Layer");
            return await _crudApplicationRL.UpdateOneInformationById(request);
        }
    }
}
