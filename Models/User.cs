using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PinkCross.Models

{
    public class User
    {
        [Required(ErrorMessage = "Please enter your Username ID")]
        public string Username_id { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        public int ID { get; set; }
    }
}
