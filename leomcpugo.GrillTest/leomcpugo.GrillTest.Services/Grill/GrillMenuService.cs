using leomcpugo.GrillTest.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace leomcpugo.GrillTest.Services.Grill
{
    public class GrillMenuService : BaseService, IGrillMenuService
    {
        public async Task<List<GrillMenuModel>> GetAll()
        {
            return await Get<List<GrillMenuModel>>("http://isol-grillassessment.azurewebsites.net/api/GrillMenu");
        }
    }
}
