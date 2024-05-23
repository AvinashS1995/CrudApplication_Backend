using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.CommonLayer.Model
{
    public class ReadAllInformationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<GetReadAllInformation> readAllInformation { get; set; }
    }

    public class GetReadAllInformation
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
