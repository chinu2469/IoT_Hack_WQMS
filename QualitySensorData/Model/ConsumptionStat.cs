using System.ComponentModel.DataAnnotations;

namespace QualitySensorData.Model
{
    public class ConsumptionStat
    {
        [Key]
        [Required]
        public long sensorid { get; set; }
        public DateTime date { get; set; }
        //public TimeOnly time { get; set; }
        public int sfloor { get; set; }
        public int consuption { get; set; }

        public string? utilityName { get; set; }
    }


}
/*  datestring 

  Consuption 

  sensorid 

  Sfloor  

  utility area

 */
