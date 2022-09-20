namespace Domain.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }

        public BrandDTO Brand { get; set; }

        //public List<ImageOfProduct> Images { get; set; }*/
    }
}