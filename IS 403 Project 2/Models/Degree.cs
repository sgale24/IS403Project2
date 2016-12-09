using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IS_403_Project_2.Models
{
    [Table("Degrees")]
    public class Degree
    {
        [Key]
        public int degreeID { get; set; }

        [Required(ErrorMessage = "Please Enter a Degree Name")]
        [DisplayName("Degree Name")]
        public string degreeName { get; set; }

        [Required(ErrorMessage = "Please Enter a Degree Coordinator")]
        [DisplayName("Degree Coordinator")]
        public string degreeCoordinator { get; set; }

        [Required(ErrorMessage = "Please Enter Coordinator Title")]
        [DisplayName("Coordinator Title")]
        public string coordinatorTitle { get; set; }

        [Required(ErrorMessage = "Please Enter an Office Address for the Degree Coordinator")]
        [DisplayName("Office Address")]
        public string coordinatorOfficeAddress { get; set; }

        [Required(ErrorMessage = "Please Enter the PhD Education for the Coordinator")]
        [DisplayName("PhD Education")]
        public string phdEducation { get; set; }

        [Required(ErrorMessage = "Please Enter the Master's Education for the Coordinator")]
        [DisplayName("Master's Education")]
        public string mastersEducation { get; set; }

        [Required(ErrorMessage = "Please Enter the Bachelor's Education for the Coordinator")]
        [DisplayName("Bachelor's Education")]
        public string bachelorsEducation { get; set; }

        [Required(ErrorMessage = "Please Enter an URL to a .jpg photo of the Coordinator")]
        [DisplayName("Picture URL")]
        public string picture { get; set; }
    }
}