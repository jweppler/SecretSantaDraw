using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.WebPages;


namespace SecretSantaDraw.Models
{
    public class WishItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WishItemId { get; set; }

        //[ForeignKey("ProfileId")]
        public int ProfileId { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public DesireLevel DesireLevel { get; set; }

        public virtual Profile Profile { get; set; }
    }

    public enum DesireLevel
    {
        [Display(Name="Kinda Want")]
        Low,
        [Display(Name="Want")]
        Moderate,
        [Display(Name="Really Want")]
        High,
        [Display(Name="Must Have")]
        MustHave
    }
}