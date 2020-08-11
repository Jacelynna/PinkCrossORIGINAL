using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PinkCross.Models
{
    public class DonationRecord
    {
        public int ID { get; set; }

        [Required(ErrorMessage = " Please enter the date of donation")]
        [Display(Name = "Date of Donation")]
        public DateTime DateOfDonation { get; set; }

        [Required(ErrorMessage = " Please enter the mode of donation ")]
        [Display(Name = "Mode of Donation")]
        public string ModeOfDonation { get; set; }

        [Required(ErrorMessage = " Please enter the donation amount")]
        [Display(Name = " Amount Donated")]
        public decimal DonationAmount { get; set; }

        [Required(ErrorMessage = " Please enter the purpose of donation")]
        [Display(Name = "Purpose of Donation")]
        public string PurposeOfDonation { get; set; }

        [Required(ErrorMessage = "Indicate as Confirmed or Not Confirmed ")]
        [Display(Name = "Donation Type")]
        public string DonorType { get; set; }

        [Required(ErrorMessage = "Please enter the comapny name ")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }

}