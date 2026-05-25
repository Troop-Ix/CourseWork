using DormitoryObjects;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryObjects.DTO;

namespace LogInSystem.Fabrics
{
    /// <summary>
    /// Класс фабрика для получения цвета в зависимости от заполненности комнаты
    /// </summary>
    public static class RoomStyler
    {
        /// <summary>
        /// Возвращение цвета в зависимости от заполненности заданной комнаты
        /// </summary>
        /// <param name="room">Комната, в которой проверяется её заполненность</param>
        /// <returns>Цвет для окраски комнаты</returns>
        public static Brush GetBrushByStatus(RoomDTO room)
        {
            int currentStudents = room.Students?.Count ?? 0;

            if (currentStudents >= room.Capacity)
                return Brushes.Red;

            if (currentStudents > 0)
                return Brushes.Yellow;

            return Brushes.LimeGreen;
        }
    }
}
