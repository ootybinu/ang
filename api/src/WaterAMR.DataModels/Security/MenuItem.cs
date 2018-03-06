using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Security
{
    public class MenuItem
    {
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string ContainerURL { get; set; }
        public bool OpenInNewWindow { get; set; }
        public string StaticMessage { get; set; }
        public string HelpURL { get; set; }
        public Int32 ParentMenuId { get; set; }
        public bool HasChildren { get; set; }
        public Int32 AllowedTo { get; set; }
        public Int32 MenuOrder { get; set; }
        public bool Active { get; set; }
        [Key]
        public Int32 MenuId { get; set; }
        public string ValidTill { get; set; }
        public Int32 MenuLevel { get; set; }
        public bool ShowInMenu { get; set; }
        public string IconPath { get; set; }
    }
}
