using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SecretSantaDraw.Models
{
    public enum HatSize {
        //[Display(Name="6 3/4")]
        SixAndThreeQuarters,
        //[DisplayName("6 7/8")]
        SixAndSevenEighths,
        //[DisplayName("7")]
        Seven,
        //[DisplayName("7 1/8")]
        SevenAndOneEighth,
        //[DisplayName("7 1/4")]
        SevenAndAQuarter,
        //[DisplayName("7 3/8")]
        SevenAndThreeEighths,
        //[DisplayName("7 1/2")]
        SevenAndAHalf,
        //[DisplayName("7 5/8")]
        SevenAndFiveEighths,
        //[DisplayName("7 3/4")]
        SevenAndThreeQuarters
    };

    public enum ShirtSize {
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