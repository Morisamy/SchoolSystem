﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    [Table("Department",Schema ="dbo")]
    public class Department
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Department ID")]
        public int DepartmentId { get; set; }
        [Required]
        [Column(TypeName ="varchar(150)")]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        public bool DepartmentIsDeleted { get; set; }
    }
}
