using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class InstituteUpdateDomainModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string Branch { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public string ActivationKey { get; set; }
        public bool isActive { get; set; }
        public byte[] Logo { get; set; }
    }
}
