using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualitySensorData.Data;
using QualitySensorData.Model;

namespace QualitySensorData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainTankData : ControllerBase
    {
        private readonly QualitySensorDbContext _dataset;
        public MainTankData(QualitySensorDbContext dataset) //, ILogger<AQMSapiDbContext> logger
        {
            this._dataset = dataset;                                    //assigning instance

        }
        [HttpGet]
        public IActionResult GetConsumptions()
        {
            try
            {
               
                IEnumerable<MainTankStat>? data = _dataset.MainTankdata.ToList();        //use getall method to retrive data from database
                if (data.Count() == 0)
                {
                    throw new Exception("data not found");
                }
                return Ok(data);                                    //return enumerable object with 200
            }
            catch (Exception ex)
            {
                //_logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);                       //returns badrequest
            }
        }

        [HttpGet("date")]
        public IActionResult TankConsumptionByDate(DateTime date)
        {
            try
            {
                IEnumerable<MainTankStat>? data = _dataset.MainTankdata.Where(x => x.date == date).ToList();        //use getall method to retrive data from database
                if (data.Count() == 0)
                {
                    throw new Exception("data not found");
                }
                return Ok(data);                                    //return enumerable object with 200
            }
            catch (Exception ex)
            {
                //_logger.LogInformation(ex.Message);
                return StatusCode(404);                       //returns badrequest
            }
        }
    }
}
