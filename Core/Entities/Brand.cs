using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Brands", Schema = "dbo")]
    public class Brand : EntityBase
    {
        public string Name { get; set; }
    }
}
