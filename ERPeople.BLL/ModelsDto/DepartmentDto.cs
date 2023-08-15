﻿using System.ComponentModel.DataAnnotations;

namespace ERPeople.BLL.ModelsDto
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(100, ErrorMessage = "Department Name must be between {2} and {1} characters.", MinimumLength = 2)]
        public string? DepartmentName { get; set; }

        [StringLength(200, ErrorMessage = "Description must be at most {1} characters.")]
        public string? Description { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Manager")]
        public string? ManagerName { get; set; }
    }
}
