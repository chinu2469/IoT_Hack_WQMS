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
        public int pH { get; set; }
        public int turbidity { get; set; }
        public int conductivity { get; set; }
        public int co2 { get; set; }
        public int humidity { get; set; }
        public int temp { get; set; }
        public float clorin { get; set; }
    }
}

