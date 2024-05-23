using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.CommonLayer.Model
{
    public class DeleteInformationByIdRequest
    {
        [Required (ErrorMessage = "User Id Is Required")]
        public int UserId { get; set; }
    }

    public class DeleteInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
