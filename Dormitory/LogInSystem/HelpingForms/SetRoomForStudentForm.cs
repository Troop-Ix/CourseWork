using DormitoryObjects.Services;
using LogInSystem.HelpingControl;
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
    public partial class SetRoomForStudentForm : Form
    {
        SelectFloorAndNumberControl floorAndNumberControl;
        RoomService _roomService;
        StudentsService _studentsService;
        int _studentID;
        public SetRoomForStudentForm(RoomService roomService, StudentsService studentsService, int studentID)
        {
            InitializeComponent();
            _studentsService=studentsService;
            _studentID=studentID;
            _roomService = roomService;
            floorAndNumberControl = new SelectFloorAndNumberControl(_roomService);
            LoadSelectingFloorAndNumber();
        }
        private void LoadSelectingFloorAndNumber()
        {
            floorAndNumberControl.Dock = DockStyle.Fill;

            panel1.Controls.Clear();

            panel1.Controls.Add(floorAndNumberControl);
        }

        private async void Set_Click(object sender, EventArgs e)
        {
            int selectedFloor = floorAndNumberControl.SelectedFloor();
            int selectedNumber = floorAndNumberControl.SelectedNumber();
            var room = await _roomService.GetRoomByFloorAndNumber(selectedFloor, selectedNumber);
            if (room != null)
            {
                await _studentsService.SetRoomForStudent(_studentID, room.RoomID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Заданная комната не найдена");
            }
        }
    }
}
