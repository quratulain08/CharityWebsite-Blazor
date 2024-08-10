 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    //DonorId, DonorName, DonorEmail, DonorContact, OrganizationName, DonorCNIC, AccountNumber, BankName, Amount
    public class ModelDonors
    {
        public int DonorId { get; set; }
        public string? DonorName { get; set; }
        public string? DonorEmail { get; set; }
        public string? DonorContact { get; set; }
        public string? OrganizationName { get; set; }
        public string? DonorCNIC { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? Amount { get; set; }



    }
}