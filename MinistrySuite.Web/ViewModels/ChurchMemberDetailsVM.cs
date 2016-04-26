using MinistrySuite.SecondaryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinistrySuite.Web.ViewModels
{
    public class ChurchMemberDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ChurchMemberAddress PrimaryAddress { get; set; }
        public string PrimaryPhone { get; set; }
        public string PrimaryEmail { get; set; }
    }
}