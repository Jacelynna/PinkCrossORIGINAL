﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PinkCross.Pages
{   
    public class RegisterDonorProfileModel : PageModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = " Name ")]
        public string DonorName { get; set; }

        [RegularExpression(@"([stfg]|[STFG])\d{7}([a-z]|[A-Z])", ErrorMessage = "Invalid NRIC format")]
        [Required]
        [Display(Name = " NRIC ")]
        public string Donornric { get; set; }

        [Required]
        [Display(Name = " Company Name ")]
        public string CompanyName { get; set; }

        [Required]
        [RegularExpression(@"[89]\d{7}", ErrorMessage = "Invalid Mobile Number")]
        [Display(Name = " Contact Number ")]
        public string DonorNumber { get; set; }

        [Display(Name = " Address  ")]
        public string DonorAddress { get; set; }

    }
}