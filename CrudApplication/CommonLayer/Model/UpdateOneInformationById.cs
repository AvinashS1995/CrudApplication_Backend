using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.CommonLayer.Model
{
    public class UpdateOneInformationByIdRequest
    {
        [Required(ErrorMessage = "User Id is Required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "User Id is Required")]
        public int Salary { get; set; }
    }

    public class UpdateOneInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
