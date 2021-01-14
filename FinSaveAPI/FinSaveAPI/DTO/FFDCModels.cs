using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinSaveAPI.DTO
{
    public class TransactArgs
    {
        public string fromAccountId { get; set; }
        public string toAccountId { get; set; }
        public float amount { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
    }

    public class FFDCAccounts
    {
        public List<FFDCAccount> Accounts { get; set; }
    }
    public class FFDCAccount
    {
        public int accountId { get; set; }
        public string formattedAccountNumber { get; set; }
        public string accountType { get; set; }
        public string nickname { get; set; }
    }
    public class Address
    {
        public string streetLine_1 { get; set; }
        public string streetLine_2 { get; set; }
        public string streetLine_3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string province { get; set; }

        public string postalCode { get; set; }

        public string postalCodeExtension { get; set; }

        public string addressType { get; set; }
    }
    public class Phone
    {
        public string countryCode { get; set; }
        public string number { get; set; }
        public string extension { get; set; }
        public string phoneType { get; set; }
    }
    public class Email
    {
        public string address { get; set; }
        public string emailType { get; set; }
    }
    public class CoreId
    {
        public string idNumber { get; set; }
        public string idType { get; set; }
    }
    public class FFDCUserModel
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public List<Address> addresses { get; set; }
        public List<Phone> phones { get; set; }
        public List<Email> emails { get; set; }
        public List<CoreId> coreIdentifications { get; set; }

    }
}
