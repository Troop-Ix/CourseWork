using DormitoryObjects;
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
    public partial class ShowRoomInfo : Form
    {
        Room _room;
        public ShowRoomInfo(Room room)
        {
            InitializeComponent();
            _room = room;

            RoomInfo();
        }
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
