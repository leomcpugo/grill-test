using leomcpugo.GrillTest.Services.Grill;
using leomcpugo.GrillTest.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace leomcpugo.GrillTest.Test
{
    [TestClass]
    public class GrillService_Test
    {
        private readonly IGrillMenuService _grillMenuService;

        public GrillService_Test()
        {
            _grillMenuService = new GrillMenuService();
        }

        [TestMethod]
        public void GrillService_CookingInfo_ReturnsCalculation()
        {
            var grill = new GrillModel
            {
                Width = 20,
                Length = 30,
            };

            var grillMenu = new GrillMenuModel
            {
                Items = new List<GrillMenuItemModel>
                {
                    new GrillMenuItemModel
                    {
                        Width = 30,
                        Length = 20,
                        Quantity = 12
                    }
                }
            };

            var grillCookingInfo = _grillMenuService.GetCookInfo(grill, grillMenu);

            Assert.AreEqual(grillCookingInfo.Rounds, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GrillService_CookingInfo_Exception()
        {
            var grill = new GrillModel
            {
                Width = 20,
                Length = 30,
            };

            var grillMenu = new GrillMenuModel
            {
                Items = new List<GrillMenuItemModel>
                {
                    new GrillMenuItemModel
                    {
                        Width = 100,
                        Length = 20,
                        Quantity = 12
                    }
                }
            };

            var grillCookingInfo = _grillMenuService.GetCookInfo(grill, grillMenu);
        }
    }
}
