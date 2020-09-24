using System;
using System.Collections.Generic;
using System.Text;

namespace leomcpugo.GrillTest.Shared.Models
{
    /// <summary>
    /// Menu
    /// </summary>
    public class GrillMenuModel
    {
        public Guid Id { get; set; }
        public string Menu { get; set; }
        /// <summary>
        /// Items of the menu
        /// </summary>
        public List<GrillMenuItemModel> Items { get; set; }
    }
}
