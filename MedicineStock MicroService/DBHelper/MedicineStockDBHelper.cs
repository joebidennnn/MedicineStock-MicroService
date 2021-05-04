using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock_MicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicineStock_MicroService.DBHelper
{
    public class MedicineStockDBHelper:DbContext
    {
        public MedicineStockDBHelper(DbContextOptions<MedicineStockDBHelper> option):base(option)
        {

        }
        public DbSet<MedicineStock> medicineStocks { get; set; }

    }
}
