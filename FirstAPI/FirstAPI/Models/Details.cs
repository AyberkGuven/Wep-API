using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstAPI.Models
{
    public class Details
    {
        public int Id { get; set; }
        public bool Kind { get; set; }
        public byte treeNameId { get; set; }
        public treeName treeName { get; set; }
        public byte diseaseId { get; set; }
        public Disease Disease { get; set; }
        public string imagePath { get; set; }
        public string Description { get; set; }
    }
}