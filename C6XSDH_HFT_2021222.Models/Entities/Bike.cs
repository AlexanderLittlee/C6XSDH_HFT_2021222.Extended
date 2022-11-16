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
    [Table("bikes")]
    public class Bike : IBike
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required][MaxLength(100)]
        public string Model { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        
        public int Price { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        
        [NotMapped][JsonIgnore]
        public virtual Brand Brand { get; set; }


    }
}
