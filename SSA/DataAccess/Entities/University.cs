﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class University
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string UniversityCode { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string CountryCode { get; set; }
        public int Ratings { get; set; }
    }
}
