using DormitoryObjects;
using DormitoryObjects.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInSystem.HelpingForms
{
    /// <summary>
    /// Окно с информацией по выбранной комнате
    /// </summary>
    public partial class ShowRoomInfo : Form
    {
        RoomDTO _room;
        public ShowRoomInfo(RoomDTO room)
        {
            InitializeComponent();
            _room = room;

            RoomInfo();
        }
        /// <summary>
        /// Отображение информации о комнате
        /// </summary>
        private void RoomInfo()
        {
            this.Text = $"{this.Text} {_room.Number}";
            Capacity.Text = _room.Capacity.ToString();
            Area.Text = _room.Area.ToString();
            if(_room.Students.Any())
            {
                StringBuilder students= new StringBuilder();
                foreach(var student in _room.Students)
                {
                    students.AppendLine($"{student.Surname} {student.Name} {student.Middlename}");
                }
                Students.Text = students.ToString();
            }
            else
            {
                Students.Text = " - ";
            }
        }
    }
}
