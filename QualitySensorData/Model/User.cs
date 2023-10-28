using System.ComponentModel.DataAnnotations;

namespace QualitySensorData.Model
{
    public class User
    {
        [Key]
        [Required]
        public int empId { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? mobileNo { get; set; }
        public string? password { get; set; }
        public string? floor { get; set; }
        public long rewardPoint { get; set; }
        public string? department { get; set; }
        public string? role { get; set; }

    }
}
