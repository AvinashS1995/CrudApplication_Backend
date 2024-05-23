using CrudApplication.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.RepositoryLayer
{
   public interface ICrudApplicationRL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);

        public Task<ReadAllInformationResponse> ReadAllInformation();
        public Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request);
        public Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request);
        public Task<GetDeleteReadAllInformationResponse> GetDeleteReadAllInformation();
        public Task<DeleteAllInformationResposne> DeleteAllInformation();
        public Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request);
        public Task<UpdateOneInformationByIdResponse> UpdateOneInformationById(UpdateOneInformationByIdRequest request);

    }
}
