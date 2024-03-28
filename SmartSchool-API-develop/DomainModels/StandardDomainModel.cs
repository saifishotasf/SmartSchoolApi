﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class StandardDomainModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Fees { get; set; }
        public bool isActive { get; set; }
    }
}