
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
    
        public class AdminRepository
        {
            private readonly PharmaDbContext dbContext;
            public AdminRepository()
            {
                dbContext = new PharmaDbContext();
            }
            public Admin FindAdminByEmail(string email)
            {
                return dbContext.Admin.FirstOrDefault(m => m.Email == email);
            }

            public bool checkAdminLogin(Admin manager)
            {
                return dbContext.Admin.Any(e => e.Email == manager.Email && e.Password == manager.Password);
            }

            public void UpdateAdmin(Admin manager)
            {
                if (manager != null)
                {
                    dbContext.Entry(manager).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            public List<Admin> GetAllAdmins()
            {
                return dbContext.Admin.ToList();
            }
        }
    }

