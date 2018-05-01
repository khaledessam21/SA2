using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Passenger
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "you have to enter your name")]
        [StringLength(20)]
        [Display(Name = "New password")]
        public string Name { get; set; }


        [Required(ErrorMessage = "you have to enter your Username")]
        [StringLength(20)]
        public string UserName { get; set; }



        [Required(ErrorMessage = "you have to enter your Password")]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [StringLength(10)]
        public string Password { get; set; }



        [Compare("Password", ErrorMessage = "you have to enter your confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "you have to enter your Adress")]
        [StringLength(10)]

        public string Adress { get; set; }
        [Required(ErrorMessage = "you have to enter your Date of Birth")]

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "you have to enter your Email")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "you have to enter your SSN")]

        public long SSN { get; set; }
        [Required(ErrorMessage = "you have to enter your Gender")]


        public string Gender { get; set; }
        public float Wallet { get; set; }
        public bool Block { get; set; }
        public bool IsAdmin { get; set; }
    }
}