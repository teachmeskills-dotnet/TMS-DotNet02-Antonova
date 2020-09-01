namespace DiscountCouponQuest.BLL.Models
{
    public class CustomerProfileDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Изображение
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Бонусы
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// Денежный счет
        /// </summary>
        public int Cash { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
    }
}
