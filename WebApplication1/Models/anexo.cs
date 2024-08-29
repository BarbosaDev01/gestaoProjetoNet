using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class anexo
    {
        [Key]
        public int IdAnexo { get; set; }
        [Required]
        public byte[] PlantaPdf { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
        [NotMapped]
        public byte[] Orcamento { get; set; }
        [NotMapped]
        public byte[] OutrosAnexos { get; set; }
        [NotMapped]
        public byte[] AssinaturaPdf { get; set; }
        [Required]
        public int IdProjeto { get; set; }
        public projeto projeto { get; set; }
    }
}
