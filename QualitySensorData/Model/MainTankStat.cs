using System.ComponentModel.DataAnnotations;

namespace QualitySensorData.Model
{
    public class MainTankStat
    {
        [Key]
        [Required]
        public DateTime date { get; set; }
        public float waterLevel { get; set; }
        public int refillCount { get; set; }
        public float consumptionTotal { get; set; }

        public float totalSensorCount { get; set; }
    }
}

/*
 * 
 *   Main Tank: 

 date 

  water level 

  refill 

  Total consumption 

  total sensor count 
 * 
 */
