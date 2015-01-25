using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SecretSantaDraw.Models
{
    public class Draw
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DrawId { get; set; }

        public DateTime DrawDate { get; set; }

        public decimal SpendLimit { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
       
        public virtual Profile Owner { get; set; }
    }
}