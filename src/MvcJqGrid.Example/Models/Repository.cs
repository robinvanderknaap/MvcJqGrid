using System;
using System.Linq;

namespace MvcJqGrid.Example.Models
{
    public class Repository
    {
        private readonly AdventureWorksDataContext _dataContext = new AdventureWorksDataContext();

        public int CountCustomers(GridSettings gridSettings)
        {
            var customers = _dataContext.Customers.AsQueryable();
            
            if (gridSettings.IsSearch)
            {
                customers = gridSettings.Where.rules.Aggregate(customers, FilterCustomers);
            }   
            return customers.Count();
        }

        public IQueryable<Customer> GetCustomers(GridSettings gridSettings)
        {
            var customers = orderCustomers(_dataContext.Customers.AsQueryable(), gridSettings.SortColumn, gridSettings.SortOrder);

            if (gridSettings.IsSearch)
            {
                customers = gridSettings.Where.rules.Aggregate(customers, FilterCustomers);
            }   

             return customers.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);     
        }

        public string[] GetCompanyNames()
        {
            return _dataContext.Customers.Select(c => c.CompanyName).Distinct().ToArray();
        }

        private static IQueryable<Customer> FilterCustomers(IQueryable<Customer> customers, Rule rule)
        {
            if (rule.field == "CustomerId")
            {
                int result;
                if (!int.TryParse(rule.data, out result))
                    return customers;
                return customers.Where(c => c.CustomerID == Convert.ToInt32(rule.data));

            }
            if (rule.field == "Name")
                return from c in customers
                       where c.FirstName.Contains(rule.data) || c.LastName.Contains(rule.data)
                       select c;
            if (rule.field == "Company")
                return customers.Where(c => c.CompanyName.Contains(rule.data));
            if (rule.field == "EmailAddress")
                return customers.Where(c => c.EmailAddress.Contains(rule.data));
            if (rule.field == "Last Modified")
            {
                DateTime result;
                if (!DateTime.TryParse(rule.data, out result))
                    return customers;
                if (result < new DateTime(1754, 1, 1)) // sql can't handle dates before 1-1-1753
                    return customers;
                return customers.Where(c => c.ModifiedDate.Date == Convert.ToDateTime(rule.data).Date);
            }
            if (rule.field == "Telephone")
                return customers.Where(c => c.Phone.Contains(rule.data));
            return customers;
        }

        private IQueryable<Customer> orderCustomers(IQueryable<Customer> customers, string sortColumn, string sortOrder)
        {
            if (sortColumn == "CustomerId")
                return (sortOrder == "desc") ? customers.OrderByDescending(c => c.CustomerID) : customers.OrderBy(c => c.CustomerID);
            if (sortColumn == "Name")
                return (sortOrder == "desc") ? customers.OrderByDescending(c=>c.FirstName) : customers.OrderBy(c=>c.FirstName);
            if (sortColumn == "Company") 
               return (sortOrder == "desc")? customers.OrderByDescending(c=>c.CompanyName) : customers.OrderBy(c=>c.CompanyName);
            if (sortColumn == "EmailAddress")
                return (sortOrder == "desc") ? customers.OrderByDescending(c => c.EmailAddress) : customers.OrderBy(c => c.EmailAddress);
            if (sortColumn == "Last Modified")
                return (sortOrder == "desc") ? customers.OrderByDescending(c => c.ModifiedDate) : customers.OrderBy(c => c.ModifiedDate);
            if (sortColumn == "Telephone")
                return (sortOrder == "desc") ? customers.OrderByDescending(c => c.Phone) : customers.OrderBy(c => c.Phone);
            return customers;
        }
       
    }
}