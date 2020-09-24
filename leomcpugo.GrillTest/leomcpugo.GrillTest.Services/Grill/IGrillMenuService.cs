using leomcpugo.GrillTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace leomcpugo.GrillTest.Services.Grill
{
    public interface IGrillMenuService
    {
        public Task<List<GrillMenuModel>> GetAll();
    }
}
