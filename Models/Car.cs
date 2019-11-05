using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRMCars.Models
{
    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Please Enter Valid Flag Must be between 250 to 5 Characters"), MinLength(5)]

        public string Flag { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        [Display(Name = "First Registration")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime FirstRegistration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]

        public string VechicleType { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Year of construction")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Yearofconstruction { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Engine Type")]
        public string EngineType { get; set; }

        [Required]
        [Display(Name = "Engine Power")]
        public string Enginepower { get; set; }

        [Required]
        [Display(Name = "Drive Type")]
        public string DriveType { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Log Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime LogDate { get; set; }


    }
}