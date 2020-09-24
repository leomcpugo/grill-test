using System;
using System.Collections.Generic;
using System.Text;

namespace leomcpugo.GrillTest.Shared.Models
{
    public class GrillMenuItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Duration { get; set; }
        public int Quantity { get; set; }
    }
}
