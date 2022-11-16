using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Models.Entities
{
    [Table("brands")]
    public class Brand : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required][MaxLength(30)]
        public string BrandName { get; set; }
        [NotMapped]
        public virtual ICollection<Purchase> Purchases { get; set; }
        [NotMapped]
        
        public virtual ICollection<Bike> Bikes { get; set; }

        public Brand()
        {
            Bikes = new HashSet<Bike>();
            Purchases = new HashSet<Purchase>();
        }
    }
}
