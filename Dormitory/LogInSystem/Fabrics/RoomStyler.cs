using DormitoryObjects;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInSystem.Fabrics
{
    public static class RoomStyler
    {
        public static Brush GetBrushByStatus(Room room)
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
