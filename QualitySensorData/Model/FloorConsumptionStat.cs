using System.ComponentModel.DataAnnotations;

namespace QualitySensorData.Model
{
    public class FloorConsumptionStat
    {
        [Key]
        [Required]
        public int floor { get; set; }

        public DateTime date { get; set; }
        public float consumptionOnFoor { get; set; }

        public float consumptionPercent {get; set; }
    }
}
/*
   date 

  floor consuption 

  Consuption Percent 
 */