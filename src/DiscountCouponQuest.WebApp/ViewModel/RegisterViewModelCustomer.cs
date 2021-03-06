﻿namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>

    public class RegisterViewModelCustomer : RegisterViewModelBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

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
    }
}
