using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock_MicroService.Models;

namespace MedicineStock_MicroService.Repository
{
    public interface IMedicineStockRepository
    {
        public IEnumerable<MedicineStock> GetStockDetails();
    }
}
