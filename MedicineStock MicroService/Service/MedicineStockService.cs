using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock_MicroService.Models;
using MedicineStock_MicroService.Repository;

namespace MedicineStock_MicroService.Service
{
    public class MedicineStockService:IMedicineStockService
    {
        private IMedicineStockRepository _repository;
        public static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MedicineStockService(IMedicineStockRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MedicineStock> GetStockDetails()
        {
            _logger.Info("Calling MedicineStockRepository");
            return _repository.GetStockDetails();
        }
    }
}
