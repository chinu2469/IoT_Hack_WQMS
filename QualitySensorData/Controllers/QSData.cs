using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualitySensorData.Data;
using QualitySensorData.Model;
using System.Data;


namespace QualitySensorData.Controllers
{
        [Route("/api/[controller]")]
        [ApiController]
        public class QSData : Controller
        {
            // creting private instance of repository to acces its method in this class only
            private readonly QualitySensorDbContext _dataset;
            public QSData(QualitySensorDbContext dataset) //, ILogger<AQMSapiDbContext> logger
            {
                this._dataset = dataset;                                    //assigning instance

            }

            [HttpGet("/Getalldata")]
           
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
            [HttpPost]
            public ActionResult Postdata(QualitySensorDataMdl QSobj)
            {
                try
                {
                    if (QSobj != null)
                    {
                    QSobj.wqi = Convert.ToInt32(( ( ( (QSobj.pH - 6)/(8-6)+ (QSobj.turbidity - 1.2) / (5 - 1.2) + (QSobj.conductivity - 50) / (800 - 50) + (QSobj.co2 - 5) / (30 - 5) 
                        + (QSobj.humidity - 45) / (55 - 45) + (QSobj.temp - 10) / (30 - 10) + (QSobj.clorin - 0.2) / (4 - 0.2))/7 )*100 ));
                    _dataset.QualitySensorDataTable.Add(QSobj);
                    _dataset.SaveChanges();

                    return Ok(QSobj);                                 //uses post method from repository to post whole object
                    }
                    else
                    {
                        throw (new Exception("data is null here"));     //throws specific exeption
                    }
                }
                catch (Exception ex)
                {
                    //_logger.LogInformation(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            [HttpGet]           //last row of the table is returned by this api call so the=at we can display live data on screen
            [Route("/[controller]/LastRowdata")]                        //specify the adress to avoid confussion of multiple get methods
            public ActionResult LastRowdata()
            {
                try
                {
                    //_logger.LogInformation("-------***************************getting last row of data*************************-------");
                    return (Ok(_dataset.QualitySensorDataTable.OrderBy(x => x.ID).Last()));

                }
                catch (Exception ex)
                {
                    //_logger.LogInformation(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
        [HttpGet]           //last row of the table is returned by this api call so the=at we can display live data on screen
        [Route("/[controller]/Last15Rowdata")]                        //specify the adress to avoid confussion of multiple get methods
        public ActionResult Last15Rowdata()
        {
            try
            {
                //_logger.LogInformation("-------***************************getting last row of data*************************-------");
                IEnumerable<QualitySensorDataMdl>? data = _dataset.QualitySensorDataTable.
                    Where(x => x.date >= DateTime.Now.Date.AddDays(-15) && x.date <= DateTime.Now.Date).OrderByDescending(x => x.date).ToList();

                IEnumerable<QualitySensorDataMdl>? averagedData = data
                .GroupBy(data1 => data1.date.Date) // Grouping by date, ignoring the time
                .Select(group => new QualitySensorDataMdl
                {
                    date = group.Key,
                    pH = group.Average(x => x.pH),
                    turbidity = group.Average(x => x.turbidity),
                    conductivity = group.Average(x => x.conductivity),
                    co2 = group.Average(x => x.co2),
                    humidity = group.Average(x => x.humidity),
                    temp = group.Average(x => x.temp),
                    clorin = group.Average(x => x.clorin),
                    wqi = (int)group.Average(x => x.wqi)
                })
                .OrderBy(data1 => data1.date) // Sort the data by date
                .ToList();

                return Ok(averagedData);

            }
            catch (Exception ex)
            {
                //_logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/ByDay/{day}")]                                              //data for the day
            //[Route("/ByDay")]                    //specify the adress to avoid confussion of multiple get methods
            public ActionResult ByDay(DateTime day)
            {
                try
                {
                    IEnumerable<QualitySensorDataMdl>? data = _dataset.QualitySensorDataTable.Where(x => x.date == day).ToList();
                    if (data.Count() == 0)
                    {
                        throw new Exception("data not found");
                    }
                    return Ok(data);
                    
            
                }
                catch (Exception ex)
                {
                    //_logger.LogInformation(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            
            [HttpGet("ByMonth/{month}")]                                                //data for the month
            //[Route("/ByMonth")]                    //specify the adress to avoid confussion of multiple get methods
            public ActionResult ByMonth(string? month)
            {
                try
                {
                    //_logger.LogInformation("-------***************************getting last row of data*************************-------");
                    var lastMonth = DateTime.Now.AddMonths(-1);
                    List<QualitySensorDataMdl> dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date >= lastMonth && x.date <= DateTime.Now).ToList();
                    if (!string.IsNullOrEmpty(month))
                    {
                        switch (month)
                        {
                            case "January":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 01).ToList();
                                break;
                            case "February":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 02).ToList();
                                break;
                            case "March":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 03).ToList();
                                break;
                            case "April":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 04).ToList();
                                break;
                            case "May":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 05).ToList();
                                break;
                            case "June":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 06).ToList();
                                break;
                            case "July":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 07).ToList();
                                break;
                            case "August":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 08).ToList();
                                break;
                            case "September":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 09).ToList();
                                break;
                            case "October":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 10).ToList();
                                break;
                            case "November":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 11).ToList();
                                break;
                            case "December":
                                dataByMonth = _dataset.QualitySensorDataTable.Where(x => x.date.Month == 12).ToList();
                                break;
            
                            default:
            
                                throw new ArgumentException("Invalid month value");
                                break;
            
                        }
            
                    }

                IEnumerable<QualitySensorDataMdl>? averagedData = dataByMonth
            .GroupBy(data1 => data1.date.Date) // Grouping by date, ignoring the time
            .Select(group => new QualitySensorDataMdl
            {
                date = group.Key,
                pH = group.Average(x => x.pH),
                turbidity = group.Average(x => x.turbidity),
                conductivity = group.Average(x => x.conductivity),
                co2 = group.Average(x => x.co2),
                humidity = group.Average(x => x.humidity),
                temp = group.Average(x => x.temp),
                clorin = group.Average(x => x.clorin),
                wqi = (int)group.Average(x => x.wqi)
            })
            .OrderBy(data1 => data1.date) // Sort the data by date
            .ToList();
                
                
                return (Ok(averagedData));
            
                }
                catch (Exception ex)
                {
                    //_logger.LogInformation(ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            
            [HttpGet("/ByYear/{year}")]                                                //data for the year
            //[Route("")]                    //specify the adress to avoid confussion of multiple get methods
            public ActionResult ByYear(int year)
            {
                try
                {
                    var startDate = new DateTime(year, 1, 1);
                    var endDate = new DateTime(year, 12, 31);
                    //var dataByYear = _dbContext.aQMSdatas.Where(x => x.date >= startDate && x.date <= endDate).ToList();
                    // _logger.LogInformation("-------***************************getting last row of data*************************-------");
                    IEnumerable<QualitySensorDataMdl>? data = _dataset.QualitySensorDataTable.Where(x => x.date >= startDate && x.date <= endDate).ToList();
                    return (Ok(data));
            
                }
                catch (Exception ex)
                {
                    //_logger.LogInformation(ex.Message);
                    return BadRequest(ex.Message);
                }
            
            }


        }

}
