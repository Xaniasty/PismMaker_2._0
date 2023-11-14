using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PismMaker_2._0.Classes
{
    public class Client
    {

        #region Properties
        public string Name { get; set; }
        public string ClientNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CDDRisk { get; set; }
        public string CaseNumber { get; set; }

        public Client(string name = null, string clientNumber = null, string address = null, string phoneNumber = null, string emailAddress = null, string cddRisk = null, string caseNumber = null)
        {
            Name = string.IsNullOrEmpty(name) ? "<<name>>" : name;
            ClientNumber = string.IsNullOrEmpty(clientNumber) ? "<<clientNumber>>" : clientNumber;
            Address = string.IsNullOrEmpty(address) ? "<<address>>" : address;
            PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? "<<phoneNumber>>" : phoneNumber;
            EmailAddress = string.IsNullOrEmpty(emailAddress) ? "<<emailAddress>>" : emailAddress;
            CDDRisk = string.IsNullOrEmpty(cddRisk) ? "<<cddRisk>>" : cddRisk;
            CaseNumber = string.IsNullOrEmpty(cddRisk) ? "<<caseNumber>>" : caseNumber;
        }

        #endregion

        #region Methods

        #endregion


    }
}
