using System.ComponentModel.DataAnnotations;

namespace QualitySensorData.Model
{
    public class QualitySensorDataMdl
    {
        [Key]
        [Required]
        public long ID { get; set; }
        public DateTime date { get; set; }
        //public TimeOnly time { get; set; }
        public int floor { get; set; }
        public int SensorID { get; set; }
        public float pH { get; set; }
        public float turbidity { get; set; }
        public float conductivity { get; set; }
        public float co2 { get; set; }
        public float humidity { get; set; }
        public float temp { get; set; }
        public float clorin { get; set; }
    }
}

