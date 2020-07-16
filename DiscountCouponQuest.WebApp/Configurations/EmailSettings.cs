namespace DiscountCouponQuest.WebApp.Configurations
{
    /// <summary>
    /// Email настройки
    /// </summary>
    public class EmailSettings
    {
        public string SMTPRef { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string FromEmailAddress { get; set; }
        public string Password { get; set; }
        public bool Disconnect { get; set; }
    }
}
