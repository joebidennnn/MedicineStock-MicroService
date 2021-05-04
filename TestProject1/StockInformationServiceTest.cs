using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineStock_MicroService.Models;
using MedicineStock_MicroService.Repository;
using MedicineStock_MicroService.Service;
using Moq;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    class StockInformationServiceTest
    {
        private Mock<IMedicineStockService> _service;
        private Mock<IMedicineStockRepository> _repository;

        public IMedicineStockRepository repository;
        public IMedicineStockService service;
        IEnumerable<MedicineStock> medicineStock;

        [SetUp]
        public void setup()
        {
            _repository = new Mock<IMedicineStockRepository>();
            _service = new Mock<IMedicineStockService>();
            medicineStock = new List<MedicineStock>() {
                 new MedicineStock() { Name = "Orthoherb", ChemicalComposition = "Castor Plant,Adulsa,Neem", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 10000 },
                 new MedicineStock() { Name = "Cholecalciferol", ChemicalComposition = "aspartame ,food dyes", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2023-1-1"), NumberOfTabletsInStock = 5000 },
                 new MedicineStock() { Name = "Gaviscon", ChemicalComposition = "sodium alginate, sodium bicarbonate", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 4000 },
                 new MedicineStock() { Name = "Dolo-650", ChemicalComposition = "Acetaminophen , Dexbrompheniramine", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 8000 },
                 new MedicineStock() { Name = "Cyclopam", ChemicalComposition = "Dicyclomine  , Paracetamol ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 12000 },
                 new MedicineStock() { Name = "Hilact", ChemicalComposition = "Asparagus racemosus  , Anethum sowa ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 6000 }}.AsEnumerable();

            _service.Setup(x => x.GetStockDetails()).Returns(medicineStock);
            service = _service.Object;
            _repository.Setup(m => m.GetStockDetails()).Returns(medicineStock);
            repository = _repository.Object;
        }

        [Test]
        public void GetStockDetails_ValidInput_ReturnsMedicineStockList()
        {
            MedicineStockService mservice = new MedicineStockService(repository);
            IEnumerable<MedicineStock> answer = mservice.GetStockDetails();
            Assert.AreEqual(medicineStock, answer);
            Assert.Pass();
        }

        [Test]
        public void GetStockDetails_InValidInput_ReturnsNULL()
        {
            medicineStock = null;
            _service.Setup(x => x.GetStockDetails()).Returns(medicineStock);
            service = _service.Object;
            List<MedicineStock> result = (List<MedicineStock>)service.GetStockDetails();
            Assert.IsNull(result);
        }
    }
}
