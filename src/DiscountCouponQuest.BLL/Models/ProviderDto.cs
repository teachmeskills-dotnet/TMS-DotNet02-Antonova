namespace DiscountCouponQuest.BLL.Models
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    public class ProviderDto
    {
        public ProviderDto(string id)
        {
            UserId = id;
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; }

        public ProviderDto()
        {
        }
    }
}
