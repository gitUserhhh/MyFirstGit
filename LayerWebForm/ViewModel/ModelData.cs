using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayerWebForm.ViewModel
{
    public class ModelData
    {
        public int Sid { get; set; }
        public Nullable<int> Ssex { get; set; }
        public string Sschool { get; set; }
        public string Sjobname { get; set; }
        public string Sphone { get; set; }
        public Nullable<System.DateTime> Addtime { get; set; }
        public Nullable<int> Scid { get; set; }
        public string Cname { get; set; }
    }
}