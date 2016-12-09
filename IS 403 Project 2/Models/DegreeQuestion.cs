using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IS_403_Project_2.Models
{
    [Table("DegreeQuestions")]
    public class DegreeQuestion
    {
        [Key]
        public int degreeQuestionID { get; set; }
        public int degreeID { get; set; }
        public int userID { get; set; }

        [DisplayName("Answer")]
        public string answer { get; set; }

        [Required(ErrorMessage = "Please Enter a Question")]
        [DisplayName("Question")]
        public string question { get; set; }

        

    }
}