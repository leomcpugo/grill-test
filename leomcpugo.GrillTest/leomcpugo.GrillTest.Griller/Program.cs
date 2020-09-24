using leomcpugo.GrillTest.Services.Grill;
using leomcpugo.GrillTest.Shared.Models;
using System;
using System.Linq;

namespace leomcpugo.GrillTest.Griller
{
    class Program
    {
        static void Main(string[] args)
        {
            var grill = new GrillModel
            {
                Width = 20,
                Length = 30
            };

            Console.WriteLine($"HEATING UP OUR GRILL {grill.Width}x{grill.Length}");
            IGrillMenuService grillMenuService = new GrillMenuService();
            var grillMenuList = grillMenuService.GetAll().Result;

            Console.WriteLine($"GRILL OPENED - WE HAVE {grillMenuList.Count} MENUS TO SERVE");
            Console.WriteLine($"-----------------------------------------------------------");
            foreach (var grillMenu in grillMenuList.OrderBy(x => x.Menu))
            {
                var grillMenuInfo = grillMenuService.GetCookInfo(grill, grillMenu);

                Console.WriteLine($"NOW COOKING {grillMenu.Menu} - WILL TAKE {grillMenuInfo.Rounds} ROUNDS");
                foreach (var grillMenuItem in grillMenu.Items.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"- {grillMenuItem.Name} x {grillMenuItem.Quantity}");
                }
            }

            Console.WriteLine($"GRILL IS CLOSED");
        }
    }
}
