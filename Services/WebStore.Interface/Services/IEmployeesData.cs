using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModel;

namespace WebStore.Infrastucture.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с сотрудниками
    /// </summary>
    public interface IEmployeesData
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();

        /// <summary>
        /// Получение сотрудника по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeView GetById(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="model"></param>
        void AddNew(EmployeeView model);

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
