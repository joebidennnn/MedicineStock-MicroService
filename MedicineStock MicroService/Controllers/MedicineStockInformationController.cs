using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineStock_MicroService.Models;
using MedicineStock_MicroService.Service;
using Microsoft.AspNetCore.Mvc;
namespace MedicineStock_MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineStockInformationController : ControllerBase
    {
        private IMedicineStockService _service;
        public static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MedicineStockInformationController(IMedicineStockService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMedicineStock()
        {

            try
            {
                var res = _service.GetStockDetails();
                if (res != null)
                {
                    _logger.Info("Medicine Stock Retrived");
                    return Ok(res);
                }
                _logger.Info("Could not Retrieve");
                return Content("Something went wrong");
            }
            catch (Exception e)
            {
                _logger.Info("Excpetion:" + e.Message);
                return Content(e.Message);
            }
        }
    }
}
