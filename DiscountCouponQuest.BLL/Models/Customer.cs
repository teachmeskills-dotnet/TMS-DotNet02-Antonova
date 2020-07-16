namespace DiscountCouponQuest.BLL.Models
{
    public class Customer
    {
        public Customer(string id)
        {
            UserId = id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public string UserId { get; set; }
    }
}
