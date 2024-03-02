using ClassLibrary1.Data;
using ClassLibrary1.ETClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositories
{
    
        public class CustomerRepository
        {
            private readonly PharmaDbContext dbContext; //define database class object

            public CustomerRepository()
            {
                dbContext = new PharmaDbContext(); //intialize database object 
            }

            public IEnumerable<Customer> GetAllPatients()
            {
                return dbContext.Customers.ToList();
            }
            public void InsertPatient(Customer Customers)
            {
                dbContext.Customers.Add(Customers);
                dbContext.SaveChanges();
            }
            public void UpdatePatient(Customer Customers)
            {
                dbContext.Entry(Customers).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            public bool checkPatientLogin(Customer Customers)
            {
                return dbContext.Customers.Any(d => d.Email == Customers.Email && d.Password == Customers.Password);
            }
            public void DeletePatient(int id)
            {
                Customer found = dbContext.Customers.Find(id);
                if (found != null)
                {
                    dbContext.Customers.Remove(found);
                    dbContext.SaveChanges();
                }
            }
            public Customer FindPatientById(int id)
            {
                return dbContext.Customers.Find(id);
            }
            public Customer FindPatientByEmail(string Email)
            {
                return dbContext.Customers.FirstOrDefault(pro => pro.Email == Email);
            }
            //datatype
            public IEnumerable<Customer> FindPatientWithName(string Name)
            {
                return dbContext.Customers.Where(meds => meds.Name.ToLower().Contains(Name.ToLower()));
            }
        }
    }

