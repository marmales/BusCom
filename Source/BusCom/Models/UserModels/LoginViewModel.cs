using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusCom.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please fill out username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please fill out password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}