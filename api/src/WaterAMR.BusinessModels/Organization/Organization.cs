using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Organization
{
    public class Organization
    {
        public long organizationid { get; set; }
        public string code { get; set; }
        public string organizationname { get; set; }
        public decimal organizationtypeid { get; set; }
        public decimal? parentid { get; set; }
        public string createdby { get; set; }
        public DateTime creationtime { get; set; }
        public string modifiedby { get; set; }
        public DateTime? modifiedtime { get; set; }
        public bool isdeleted { get; set; }
    }
    public class OrgInfo
    {
        public long Id { get; set; }
        public long DivisionId { get; set; }
        public string HeaderPath { get; set; }
        public string HeaderText { get; set; }
        public string SubHeaderText { get; set; }

    }
    public class OrgShort
    {
        public long organizationid { get; set; }
        public string code { get; set; }
        public string organizationname { get; set; }
        public decimal organizationtypeid { get; set; }
        public decimal? parentid { get; set; }
        public string createdby { get; set; }
    }

    public class OrgInput {
        public decimal? parentid { get; set; }
        public string SearchText { get; set; }
    }
}
