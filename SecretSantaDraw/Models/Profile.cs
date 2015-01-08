using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SecretSantaDraw.Models
{

    public class Profile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }

        [Display(Name = "Display Name")]
        [Required]
        public string DisplayName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Not Specified")]
        [Display(Name = "Birth Date")]
        public DateTime DOB { get; set; }

        public GenderType Gender { get; set; }

        [Display(Name = "Hat Size")]
        public HatSize HatSize { get; set; }

        [Display(Name = "Shirt Size")]
        public ShirtSize ShirtSize { get; set; }

        [Display(Name = "Shoe Size")]
        public ShoeSize ShoeSize { get; set; }
        
    }

    public enum GenderType
    {
        [Display(Name = "Not Specified")]
        NotSpecified,
        Male,
        Female
    }

    public enum ShirtSize
    {
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

    public enum HatSize
    {
        [Display(Name = "Not Specified")]
        NotSpecified,
        [Display(Name = "6 3/4")]
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

    public enum ShoeSize
    {
        [Display(Name = "Not Specified")]
        NotSpecified,
        [Display(Name = "6")]
        Six,
        [Display(Name = "6.5")]
        SixAndAHalf,
        [Display(Name = "7")]
        Seven,
        [Display(Name = "7.5")]
        SevenAndAHalf,
        [Display(Name = "8")]
        Eight,
        [Display(Name = "8.5")]
        EightAndAHalf,
        [Display(Name = "9")]
        Nine,
        [Display(Name = "9.5")]
        NineAndAHalf,
        [Display(Name = "10")]
        Ten,
        [Display(Name = "10.5")]
        TenAndAHalf,
        [Display(Name = "11")]
        Eleven,
        [Display(Name = "11.5")]
        ElevenAndAHalf,
        [Display(Name = "12")]
        Twelve,
        [Display(Name = "12.5")]
        TwelveAndAHalf,
        [Display(Name = "13")]
        Thirteen
    };
}