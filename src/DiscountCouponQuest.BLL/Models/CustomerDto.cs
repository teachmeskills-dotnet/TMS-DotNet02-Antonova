namespace DiscountCouponQuest.BLL.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int Bonus { get; set; }
        public int Cash { get; set; }

        public string UserId { get; set; }
    }
}
