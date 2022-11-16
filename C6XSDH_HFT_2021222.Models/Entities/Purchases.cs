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
    [Table("purchases")]
    public class Purchase : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set ; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        
        [NotMapped][JsonIgnore]
        public virtual Brand Brand { get; set; }
    }
}
