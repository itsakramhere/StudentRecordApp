using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecords.Models
{

    public class StudentViewModel
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}