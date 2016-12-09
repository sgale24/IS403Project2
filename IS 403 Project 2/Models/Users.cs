using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IS_403_Project_2.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int userID { get; set; }

        [Required(ErrorMessage = "Please Enter an Email")]
        [DisplayName("Email")]
        public string userEmail { get; set; }

        [Required(ErrorMessage = "Please Enter an Password")]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter a First Name")]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please Enter a Last Name")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }


    }
}