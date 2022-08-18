using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("ImageOfProducts", Schema = "dbo")]
    public class ImageOfProduct : EntityBase
    {
        public string Url { get; set; }

        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
