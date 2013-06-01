using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace MvcJqGrid.Example.Models
{
    /// <summary>
    /// This repository is implemented using RavenDB. We load all customers in memory from the database once to keep things simple.
    /// </summary>
    public class Repository
    {
        private static readonly IQueryable<Customer> Customers;

        /// <summary>
        /// Static contructors are called automatically before the first instance is created or any static members are referenced.
        /// A static constructor is executed only once.
        /// </summary>
        static Repository()
        {
            // Initialize embedded ravendb data store.
            var documentStore = new EmbeddableDocumentStore { DataDirectory = "~/App_Data" };
            documentStore.Initialize();
            
            // Create indexes
            IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), documentStore);
    
            // Retrieve all customers in database
            using (var session = documentStore.OpenSession())
            {
                // 847 customers exist in the database, ravendb limits results to 128 by default.
                // This is why we need to specifically ask for 847 customers.
                Customers = session.Query<Customer>().Take(847).ToList().AsQueryable();
            }
        }
        
        public IList<Customer> GetCustomers(GridSettings gridSettings)
        {
            var orderedCustomers = OrderCustomers(Customers, gridSettings.SortColumn, gridSettings.SortOrder);

            if (gridSettings.IsSearch)
            {
                orderedCustomers = gridSettings.Where.rules.Aggregate(orderedCustomers, FilterCustomers);
            }

            return orderedCustomers.Skip((gridSettings.PageIndex - 1)*gridSettings.PageSize).Take(gridSettings.PageSize).ToList();
        }

        public int CountCustomers(GridSettings gridSettings)
        {
            return gridSettings.IsSearch ? gridSettings.Where.rules.Aggregate(Customers, FilterCustomers).Count() : Customers.Count();
        }

        public string[] GetCompanyNames()
        {
            return Customers.OrderBy(x=>x.Company).Select(c => c.Company).Distinct().ToArray();
        }

        private static IQueryable<Customer> FilterCustomers(IQueryable<Customer> customers, Rule rule)
        {
            switch (rule.field)
            {
                case "CustomerId":
                    return customers.Where(c => c.CustomerId == rule.data);

                case "Name":
                    return customers.Where(c => c.Fullname.ToLower().Contains(rule.data.ToLower()));

                case "Company":
                    return customers.Where(c => c.Company.ToLower().Contains(rule.data.ToLower()));
                
                case "EmailAddress":
                    return customers.Where(c => c.EmailAddress.ToLower().Contains(rule.data.ToLower()));
                
                case "Last Modified":
                    DateTime dateResult;
                    return !DateTime.TryParse(rule.data, out dateResult) ? customers : customers.Where(c => c.LastModified.Date == dateResult.Date);

                case "Telephone":
                    return customers.Where(c => c.Telephone.ToLower().Contains(rule.data.ToLower()));
                    
                default:
                    return customers;
            }
        }

        private static IQueryable<Customer> OrderCustomers(IQueryable<Customer> customers, string sortColumn, string sortOrder)
        {
            switch (sortColumn)
            {
                case "CustomerId":
                    return (sortOrder == "desc") ? customers.OrderByDescending(c => Convert.ToInt32(c.CustomerId)) : customers.OrderBy(c => Convert.ToInt32(c.CustomerId));
                
                case "Name":
                    return (sortOrder == "desc") ? customers.OrderByDescending(c => c.Fullname) : customers.OrderBy(c => c.Fullname);
                
                case "Company":
                    return (sortOrder == "desc") ? customers.OrderByDescending(c => c.Company) : customers.OrderBy(c => c.Company);
                
                case "EmailAddress":
                    return (sortOrder == "desc") ? customers.OrderByDescending(c => c.EmailAddress) : customers.OrderBy(c => c.EmailAddress);
                
                case "Last Modified":
                    return (sortOrder == "desc") ? customers.OrderByDescending(c => c.LastModified) : customers.OrderBy(c => c.LastModified);
                
                case "Telephone":
                    return (sortOrder == "desc") ? customers.OrderByDescending(c => c.Telephone) : customers.OrderBy(c => c.Telephone);
                
                default:
                    return customers;
            }
        }
    }
}