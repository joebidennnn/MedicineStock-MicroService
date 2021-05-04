using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineStock_MicroService.DBHelper;
using MedicineStock_MicroService.Models;
using MedicineStock_MicroService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    class StockInformationRepositoryTest
    {
        private Mock<IMedicineStockRepository> _repository;

        public IMedicineStockRepository repository;
        IEnumerable<MedicineStock> medicineStock;
        [SetUp]
        public void setup()
        {
            _repository = new Mock<IMedicineStockRepository>();
            medicineStock = new List<MedicineStock>() {
                 new MedicineStock() { Name = "Orthoherb", ChemicalComposition = "Castor Plant,Adulsa,Neem", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 10000 },
                 new MedicineStock() { Name = "Cholecalciferol", ChemicalComposition = "aspartame ,food dyes", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2023-1-1"), NumberOfTabletsInStock = 5000 },
                 new MedicineStock() { Name = "Gaviscon", ChemicalComposition = "sodium alginate, sodium bicarbonate", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 4000 },
                 new MedicineStock() { Name = "Dolo-650", ChemicalComposition = "Acetaminophen , Dexbrompheniramine", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 8000 },
                 new MedicineStock() { Name = "Cyclopam", ChemicalComposition = "Dicyclomine  , Paracetamol ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 12000 },
                 new MedicineStock() { Name = "Hilact", ChemicalComposition = "Asparagus racemosus  , Anethum sowa ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"), NumberOfTabletsInStock = 6000 }}.AsEnumerable();

            
            _repository.Setup(m => m.GetStockDetails()).Returns(medicineStock);
            repository = _repository.Object;
        }
        [Test]
        public void GetStockDetails_ValidInput_ReturnsMedicineStockList()
        {
            var context = new MedicineStockDBHelper(
                new DbContextOptionsBuilder<MedicineStockDBHelper>()
                .UseInMemoryDatabase("MedicineStock").Options);
            MedicineStockRepository repo = new MedicineStockRepository(context);
            IEnumerable<MedicineStock> answer = repo.GetStockDetails();
            Assert.IsNotNull(answer);
            Assert.Pass("Passed");
        }

        [Test]
        public void StockRepository_InValidInput_FailCase_ReturnsNull()
        {
            medicineStock = null;
            _repository.Setup(m => m.GetStockDetails()).Returns(medicineStock);
            repository = _repository.Object;
            List<MedicineStock> result = (List<MedicineStock>)repository.GetStockDetails();
            Assert.IsNull(result);
        }
    }
}
