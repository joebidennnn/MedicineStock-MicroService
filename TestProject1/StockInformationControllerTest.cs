using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineStock_MicroService.Controllers;
using MedicineStock_MicroService.Models;
using MedicineStock_MicroService.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    class StockInformationControllerTest
    {
        private Mock<IMedicineStockService> _service;
        public IMedicineStockService service;
        IEnumerable<MedicineStock> medicineStock;
        [SetUp]
        public void setup()
        {
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
        }
        [Test]
        public void GetStockInformation_ValidInput_ReturnsMedicineList()
        {
            _service.Setup(x => x.GetStockDetails()).Returns(medicineStock);
            var controller = new MedicineStockInformationController(_service.Object);
            var data = controller.GetMedicineStock();
            var res = data as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
        [Test]
        public void GetStockInformation_InValidInput_ReturnsNull()
        {
            medicineStock = null;
            _service.Setup(x => x.GetStockDetails()).Returns(medicineStock);
            var controller = new MedicineStockInformationController(_service.Object);
            var data = controller.GetMedicineStock();
            var res = data as OkObjectResult;
            Assert.IsNull(res);
        }

        [Test]
        public void GetStockInformation_ValidInput_ReturnsSuccessResponse()
        {
            _service.Setup(x => x.GetStockDetails()).Returns(medicineStock);
            var controller = new MedicineStockInformationController(_service.Object);
            var data = controller.GetMedicineStock();
            var res = data as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }


    }
}
