using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock_MicroService.Models;

namespace MedicineStock_MicroService.Service
{
    public interface IMedicineStockService
    {
        public IEnumerable<MedicineStock> GetStockDetails();
    }
}
