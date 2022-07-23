using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entities
{
    [Table("Products", Schema = "dbo")]
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public long BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand BrandValue { get; set; }
    }
}