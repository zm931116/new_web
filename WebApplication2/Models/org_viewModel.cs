using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Org_viewModel
    {
        public List<ac_org> Ac { get; set; }

        public List<food_org> Fd { get; set; }

        public List<Public_toilets> Pt { get; set; }

        public List<Drinking_fountains> Df { get; set; }
    }
}