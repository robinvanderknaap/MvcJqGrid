using System;

namespace MvcJqGrid.Example.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string CustomerId
        {
            get
            {
                return Id.Replace("customers/", ""); // Remove ravendb prefix from identifier
            }
        } 
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get 
            {
                return String.IsNullOrWhiteSpace(Middlename) ?
                    string.Format("{0} {1}", Firstname, Lastname) :
                    string.Format("{0} {1} {2}", Firstname, Middlename, Lastname);
            }
        }
        public string Company { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastModified { get; set; }
        public string Telephone { get; set; }
    }
}