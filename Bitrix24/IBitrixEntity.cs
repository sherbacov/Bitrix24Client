using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrix24
{
    public interface IBitrixEntity
    {
        /// <summary>
        /// Преобразует поля объекта в словарь
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> ToDictionary();

        /// <summary>
        /// Отдаёт кусок метода для урла
        /// </summary>
        /// <returns></returns>
        string GetMethod();
    }
}
