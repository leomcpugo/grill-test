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
            int areaOfGrill = grill.Width * grill.Length;

            var areaOfMenuList = menu.Items
                .SelectMany(x => Enumerable.Repeat((x.Width * x.Length), x.Quantity))
                .OrderByDescending(x => x)
                .ToList();
            var menuItemsCount = areaOfMenuList.Count;

            if (areaOfMenuList.Any(x => x == 0)) throw new ArgumentException("One of the menu items has no area");
            if (areaOfMenuList.Any(x => x > areaOfGrill)) throw new ArgumentException("One of the menu items is larger than the grill");

            var currentRound = 1;
            double currentRoundSpace = 0;

            // calculation made to grill only full pieces
            for (int i = 0; i < menuItemsCount; i++)
            {
                var nextItem = areaOfMenuList.FirstOrDefault(x => x + currentRoundSpace <= areaOfGrill);

                // There's no more space left in the grill
                if (nextItem == default)
                {
                    currentRound++;
                    currentRoundSpace = 0;
                    nextItem = areaOfMenuList.First();
                }

                currentRoundSpace += nextItem;
                areaOfMenuList.Remove(nextItem);
            }

            return new GrillMenuCookedInfoModel
            {
                Rounds = currentRound
            };
        }

    }
}

