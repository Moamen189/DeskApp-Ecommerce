namespace Ecommerce.DAL.Entities
{
    public class Customer : BaseEntity
    {
      
        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }

        public Order Order { get; set; }
    }
}