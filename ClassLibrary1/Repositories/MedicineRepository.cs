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
    public class MedicineRepository
    {
        private readonly PharmaDbContext dbContext;
        public MedicineRepository()
        {
            dbContext = new PharmaDbContext();
        }

        public List<Medicine> GetAllMedicines()
        {
            var obj = dbContext.Medicines.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Medicine GetMedicineById(int medicineId)
        {
            var obj = dbContext.Medicines.Find(medicineId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Medicine> FindMedicineByName(string Name)
        {
            return dbContext.Medicines.Where(meds => meds.MName.Contains(Name));
        }

        public void AddMedicine(Medicine medicine)
        {
            if (medicine != null)
            {
                dbContext.Medicines.Add(medicine);
                dbContext.SaveChanges();
            }
        }

        public void UpdateMedicine(Medicine medicine)
        {
            dbContext.Entry(medicine).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void DeleteMedicine(int medicineId)
        {
            var medicine = dbContext.Medicines.Find(medicineId);
            if (medicine != null)
            {
                dbContext.Medicines.Remove(medicine);
                dbContext.SaveChanges();
            }
        }
    }
}
