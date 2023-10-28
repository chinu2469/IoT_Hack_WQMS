using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using QualitySensorData.Data;
using QualitySensorData.Model;

namespace QualitySensorData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Consumption : ControllerBase
    {
        private readonly QualitySensorDbContext _dataset;
        //private readonly ILogger<AQMSapiDbContext> _logger;             //logger instance to get all logger method
        public Consumption(QualitySensorDbContext dataset) //, ILogger<AQMSapiDbContext> logger
        {
            this._dataset = dataset;                                    //assigning instance

            //this._logger = logger;
        }
        [HttpGet]
        public IActionResult GetConsumptions()
        {
            try
            {
                //_logger.LogInformation("-------********************-------getting all data-------****************-------");
                IEnumerable<ConsumptionStat>? data = _dataset.ConsumptionData.ToList();        //use getall method to retrive data from database
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

        [HttpGet("floor")]
        public IActionResult FloorConsumption(int floor)
        {
            try
            {
                //_logger.LogInformation("-------********************-------getting all data-------****************-------");
                 IEnumerable<ConsumptionStat>? data =  _dataset.ConsumptionData.Where(x => x.sfloor == floor).ToList();        //use getall method to retrive data from database
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
