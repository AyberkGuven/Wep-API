using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstAPI.ViewModel
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string imagePath { get; set; }
        public string Kind { get; set; }
        public string treeNameId { get; set; }
        public string diseaseId { get; set; }
        public string Description { get; set; }
    }
}