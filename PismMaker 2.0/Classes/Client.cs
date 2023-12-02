using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PismMaker_2._0.Classes
{
    public class Client
    {

        #region Properties
        public string Name { get; set; }
        public string ClientNumber { get; set; }
        public string Address1stPage { get; set; }
        public string Address2ndPage { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CDDRisk { get; set; }
        public string CaseNumber { get; set; }
        public string ReplyDate { get; set; }
        public string MessangeType { get; set; }
        public string CddRisk { get; set; }
        public string CddDateEnd { get; set; }
        public string PkdUsed { get; set; }
        public string ConnectedString { get; set; }




        public Client(string name = null, string clientNumber = null, string address1 = null, string address2 = null,
                      string phoneNumber = null, string emailAddress = null, string cddRisk = null, string cddDateEnd = null,
                      string caseNumber = null, string replyDate = null, string messengeType = null, string pkdUsed = null)
        {
            Name = string.IsNullOrEmpty(name) ? "<<Name>>" : name;
            ClientNumber = string.IsNullOrEmpty(clientNumber) ? "<<ClientNumber>>" : clientNumber;
            Address1stPage = string.IsNullOrEmpty(address1) ? "<<Address1stPage>>" : address1;
            Address2ndPage = string.IsNullOrEmpty(address2) ? "<<Address2ndPage>>" : address2;
            PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? "<<PhoneNumber>>" : phoneNumber;
            EmailAddress = string.IsNullOrEmpty(emailAddress) ? "<<EmailAddress>>" : emailAddress;
            CDDRisk = string.IsNullOrEmpty(cddRisk) ? "<<CDDRisk>>" : cddRisk;
            CddDateEnd = string.IsNullOrEmpty(cddDateEnd) ? "<<CddDateEnd>>" : cddDateEnd;
            CaseNumber = string.IsNullOrEmpty(cddRisk) ? "<<CaseNumber>>" : caseNumber;
            ReplyDate = string.IsNullOrEmpty(replyDate) ? "<<ReplyDate>>" : replyDate;
            MessangeType = string.IsNullOrEmpty(messengeType) ? "<<MessangeType>>" : messengeType;
            PkdUsed = string.IsNullOrEmpty(pkdUsed) ? "<<PkdUsed>>" : pkdUsed;
            



        }

        #endregion

        #region Methods
        // mozliwe ze nie potrzebne albo lepiej tego uzyc? poczytaj.
        static Dictionary<string, string> ClientObjectToDictionary(Client client)
        {

            Type type = client.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                dictionary.Add(property.Name, property.GetValue(client)?.ToString());
            }

            return dictionary;
        }


        #endregion


    }
}
