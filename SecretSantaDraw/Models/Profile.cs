using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SecretSantaDraw.Models
{
    public enum HatSize {
        [Display(Name="Not Specified")]
        NotSpecified,
        [Display(Name="6 3/4")]
        SixAndThreeQuarters,
        [Display(Name = "6 7/8")]
        SixAndSevenEighths,
        [Display(Name = "7")]
        Seven,
        [Display(Name = "7 1/8")]
        SevenAndOneEighth,
        [Display(Name = "7 1/4")]
        SevenAndAQuarter,
        [Display(Name = "7 3/8")]
        SevenAndThreeEighths,
        [Display(Name = "7 1/2")]
        SevenAndAHalf,
        [Display(Name = "7 5/8")]
        SevenAndFiveEighths,
        [Display(Name = "7 3/4")]
        SevenAndThreeQuarters
    };

    public enum ShirtSize {
        [Display(Name = "Not Specified")]
        NotSpecified,
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
    };


    public class Profile
    {
        public int ProfileId { get; set; }

        public string DisplayName { get; set; }

        public HatSize HatSize { get; set; }

        public ShirtSize ShirtSize { get; set; }
        
    }
}