using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    [Table("Teacher", Schema = "dbo")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Teacher ID")]
        public int TeacherId { get; set; } 

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name ="Teacher Name")]
        public string TeacherName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Teacher Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime TeacherDoB { get; set;}
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Teacher Date of Hiring")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}")]
        public DateTime TeacherDoH { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Teacher Salary")]
        public decimal TeacherSalary { get; set;}

        [ForeignKey("Department")]
        [Required]
        //[NotMapped]
        public int TeacherDepartmentId { get; set; }

        [Display(Name = "Department Name")]
        [NotMapped]
        public string? TeacherDepartmentName { get; set; }

        public virtual Department? Department { get; set; }
    }
}
