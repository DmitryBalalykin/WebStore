using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.ViewModel;

namespace WebStore.Interface.Services
{
    public interface ICartService
    {
        /// <summary>
        /// Уменьшить кол-во на единицу
        /// </summary>
        /// <param name="id"></param>
        void DecrementFromCart(int id);
        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        void RemoveFromCart(int id);
        /// <summary>
        /// Удалить все товары из корзины
        /// </summary>
        void RemoveAll();
        /// <summary>
        /// Увеличить кол-во на единицу
        /// </summary>
        /// <param name="id"></param>
        void AddToCart(int id);

        /// <summary>
        /// Для конвертации viewModel и Моделью доменной
        /// </summary>
        /// <returns></returns>
        CartViewModel TransformCart();
    }
}
