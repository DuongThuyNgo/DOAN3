using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANLYDIEM.Models
{
    public class HocSinhModel
    {
        public IList<HocSinh> list_HocSinh { get; set; }
        public int TotalRecords { get; set; }
    }
}