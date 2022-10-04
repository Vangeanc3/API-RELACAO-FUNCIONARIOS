using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Gerencia
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Departamento { get; set; }
        [JsonIgnore]
        public virtual Gerente? Gerente { get; set; }
    }
}