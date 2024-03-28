﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.FeesManagement
{
    public class FeesManagementRequest
    {
        public int StudentId { get; set; }
        public double Fees { get; set; }
        public double PendingFees { get; set; }
        public double PaidFees { get; set; }
        public DateTime Date { get; set; }
        public int StandardId { get; set; }
        public int TeacherId { get; set; }
        public int DevisionId { get; set; }
        public bool isActive { get; set; }
    }
}
