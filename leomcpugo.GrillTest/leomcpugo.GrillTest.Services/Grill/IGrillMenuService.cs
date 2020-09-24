using leomcpugo.GrillTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace leomcpugo.GrillTest.Services.Grill
{
    public interface IGrillMenuService
    {
        /// <summary>
        /// Retrieves all the Grill Menus
        /// </summary>
        /// <returns></returns>
        Task<List<GrillMenuModel>> GetAll();

        /// <summary>
        /// Calculates the cooking info
        /// </summary>
        /// <param name="grill"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        GrillMenuCookedInfoModel GetCookInfo(GrillModel grill, GrillMenuModel menu);
    }
}
