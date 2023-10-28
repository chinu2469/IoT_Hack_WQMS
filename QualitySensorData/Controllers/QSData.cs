using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QualitySensorData.Data;
using QualitySensorData.Model;
using System.Data;


namespace QualitySensorData.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class QSData : Controller
        {
            // creting private instance of repository to acces its method in this class only
            private readonly QualitySensorDbContext _dataset;
            public QSData(QualitySensorDbContext dataset) //, ILogger<AQMSapiDbContext> logger
            {
                this._dataset = dataset;                                    //assigning instance

            }

            [HttpGet]
           
            public ActionResult Getalldata()
            {
                try
                {
                    IEnumerable<QualitySensorDataMdl>? data = _dataset.QualitySensorDataTable.ToList();        //use getall method to retrive data from database
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

        [HttpGet("day")]
        public ActionResult DaysQuality(DateTime day) 
        {
            try 
            { 
                IEnumerable<QualitySensorDataMdl>? data= _dataset.QualitySensorDataTable.Where(x => x.date == day).ToList();
                if (data.Count() == 0)
                {
                    throw new Exception("data not found");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                //_logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);                       //returns badrequest
            }
        }
        }

}
