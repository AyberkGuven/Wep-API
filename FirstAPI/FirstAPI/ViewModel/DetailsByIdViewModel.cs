using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstAPI.ViewModel
{
    public class DetailsByIdViewModel
    {
        public int Id { get; set; }
        public bool Kind { get; set; }
        public byte treeNameId { get; set; }
        public byte diseaseId { get; set; }
        public string imagePath { get; set; }
        public string Description { get; set; }
    }
}