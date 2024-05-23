using CrudApplication.CommonLayer.Model;
using CrudApplication.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        public readonly ICrudApplicationSL _crudApplicationSL;
        public readonly ILogger<CrudApplicationController> _logger;

        public CrudApplicationController(ICrudApplicationSL crudApplicationSL, ILogger<CrudApplicationController> logger)
        {
            _crudApplicationSL = crudApplicationSL;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();
            _logger.LogInformation(message: $"AddInformation API Calling in Controller....{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.AddInformation(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"AddInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }


        [HttpGet]
        public async Task<IActionResult> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            _logger.LogInformation(message: "ReadAllInformation API Calling in Controller....");

            try
            {
                response = await _crudApplicationSL.ReadAllInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"ReadAllInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            _logger.LogInformation(message: $"ReadAllInformation API Calling in Controller....{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.UpdateAllInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"ReadAllInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            _logger.LogInformation(message: $"DeleteInformationById API Calling in Controller....{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.DeleteInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"AddInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpGet]
        public async Task<IActionResult> GetDeleteReadAllInformation()
        {
            GetDeleteReadAllInformationResponse response = new GetDeleteReadAllInformationResponse();
            _logger.LogInformation(message: "GetDeleteReadAllInformation API Calling in Controller....");

            try
            {
                response = await _crudApplicationSL.GetDeleteReadAllInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getreadAllInformation });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetDeleteReadAllInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getreadAllInformation });

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllInformation()
        {
            DeleteAllInformationResposne response = new DeleteAllInformationResposne();
            _logger.LogInformation(message: $"DeleteAllInformation API Calling in Controller....");

            try
            {
                response = await _crudApplicationSL.DeleteAllInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"DeleteAllInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpPost]
        public async Task<IActionResult> ReadInformationById(ReadInformationByIdRequest request)
        {
            ReadInformationByIdResponse response = new ReadInformationByIdResponse();
            _logger.LogInformation(message: $"ReadAllInformation API Calling in Controller....{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.ReadInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getreadInformationById });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"ReadAllInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getreadInformationById });
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOneInformationById(UpdateOneInformationByIdRequest request)
        {
            UpdateOneInformationByIdResponse response = new UpdateOneInformationByIdResponse();
            _logger.LogInformation(message: $"UpdateOneInformationById API Calling in Controller....{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.UpdateOneInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"UpdateOneInformationById API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

    }

}

