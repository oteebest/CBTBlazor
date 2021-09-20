using CBTBlazor.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Services
{
    public interface IDataService
    {
        public Task<PredefinedDataResponseModel> GetPredefinedData();
    }
}
