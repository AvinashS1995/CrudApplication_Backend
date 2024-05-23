using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.CommonLayer.Model
{
    public class AddInformationRequest
    {
        [Required (ErrorMessage ="UserName is Mandetory Field")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(pattern: "^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "Email Id Not In Correct Format Example: developer@gmail.com")]
        public string EmailID { get; set; }

        [Required]
        [RegularExpression (pattern: "([1-9]{1}[0-9]{9})$", ErrorMessage = "Mobile Number Not In Correct Format Example:     9865142536")]
        public string Mobile { get; set; }

        [Required]
        [Range (minimum:1,int.MaxValue, ErrorMessage = "Please Enter Value Greater Than 0")]
        public int Salary { get; set; }

        [Required]
        [RegularExpression(pattern: "^(?:m|M|male|Male|f|F|female|Female)$", ErrorMessage = "Gender Not In Correct Format Ex: m, M, male, Male, f, F, female, Female")]
        public string Gender { get; set; }
    }

    public class AddInformationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
