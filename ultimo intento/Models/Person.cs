using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ultimo_intento.Models
{
    [Table("People", Schema = "public")]
    public class Person
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }
    }
}
