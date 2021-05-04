using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock_MicroService.DBHelper;
using MedicineStock_MicroService.Models;

namespace MedicineStock_MicroService.Repository
{
    public class MedicineStockRepository:IMedicineStockRepository
    {
        private readonly MedicineStockDBHelper _context;
        public static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MedicineStockRepository(MedicineStockDBHelper context)
        {
            _context = context;

            try
            {
                _logger.Info("Generating Medicine List");
                _context.medicineStocks.AddRange(
                 new MedicineStock() { Name = "Orthoherb", ChemicalComposition = "Castor Plant,Adulsa,Neem", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 10000 },
                 new MedicineStock() { Name = "Cholecalciferol", ChemicalComposition = "aspartame ,food dyes", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2023-1-1"), NumberOfTabletsInStock = 5000 },
                 new MedicineStock() { Name = "Gaviscon", ChemicalComposition = "sodium alginate, sodium bicarbonate", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 4000 },
                 new MedicineStock() { Name = "Dolo-650", ChemicalComposition = "Acetaminophen , Dexbrompheniramine", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 8000 },
                 new MedicineStock() { Name = "Cyclopam", ChemicalComposition = "Dicyclomine  , Paracetamol ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 12000 },
                 new MedicineStock() { Name = "Hilact", ChemicalComposition = "Asparagus racemosus  , Anethum sowa ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 6000 });
                _context.SaveChanges();
            }
            catch(Exception e) 
            {
                _logger.Error(e.Message);
            }
        }
        public IEnumerable<MedicineStock> GetStockDetails()
        {
            return _context.medicineStocks.ToList();
        }
    }
}
