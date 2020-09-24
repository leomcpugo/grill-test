using System;
using System.Collections.Generic;
using System.Text;

namespace leomcpugo.GrillTest.Shared.Models
{
    public class GrillMenuModel
    {
        public Guid Id { get; set; }
        public string Menu { get; set; }
        public List<GrillMenuItemModel> Items { get; set; }
    }
}
