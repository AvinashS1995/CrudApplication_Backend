using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.CommonLayer.Model
{
    public class ReadInformationByIdRequest
    {
        [Required(ErrorMessage = "User Id Is Required")]
        public int UserId { get; set; }
    }

     public class ReadInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetreadInformationById>   getreadInformationById  { get; set; }
    }

    public class GetreadInformationById
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }

}
