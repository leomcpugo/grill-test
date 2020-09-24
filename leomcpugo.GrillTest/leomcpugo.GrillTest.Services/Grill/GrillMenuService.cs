using leomcpugo.GrillTest.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leomcpugo.GrillTest.Services.Grill
{
    public class GrillMenuService : BaseService, IGrillMenuService
    {
        public async Task<List<GrillMenuModel>> GetAll()
        {
            // TODO: handle URL from a configuration file
            return await Get<List<GrillMenuModel>>("http://isol-grillassessment.azurewebsites.net/api/GrillMenu");
        }

        public GrillMenuCookedInfoModel GetCookInfo(GrillModel grill, GrillMenuModel menu)
        {
            double areaOfGrill = grill.Width * grill.Length;
            var areaOfMenuList = menu.Items.Select(x => (x.Width * x.Length) * x.Quantity);
            double areaOfMenu = areaOfMenuList.Sum();

            // TODO: improve calculation so only full pieces are cooked each time
            double numberOfRounds = areaOfMenu / areaOfGrill;

            return new GrillMenuCookedInfoModel
            {
                Rounds = Convert.ToInt32(Math.Ceiling(numberOfRounds))
            };
        }

    }
}

