using DormitoryObjects.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInSystem.HelpingControl
{
    public partial class SelectFloorAndNumberControl : UserControl
    {
        RoomService _roomService;
        public SelectFloorAndNumberControl(RoomService roomService)
        {
            InitializeComponent();
            _roomService = roomService;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        private async void LoadInitialization()
        {
            var floors = await _roomService.GetFloors();
            FloorsList.DataSource = floors.ToList();
            if (floors.Any())
            {
                FloorsList.SelectedIndex = 0;
            }
        }

        public int SelectedFloor()
        {
            if (FloorsList.SelectedItem == null)
            {
                return -1;
            }
            return (int)FloorsList.SelectedItem;
        }
        public int SelectedNumber()
        {
            if(NumbersList.SelectedItem==null)
            {
                return -1;
            }
            return (int)NumbersList.SelectedItem;
        }

        private async void FloorsList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedFloor = (int)FloorsList.SelectedItem;
            var numbers = await _roomService.GetNumbersFromFloor(selectedFloor);
            NumbersList.DataSource = numbers.ToList();
            if (numbers.Any())
            {
                NumbersList.SelectedIndex = 0;
            }
            else
            {
                NumbersList.DataSource = null;
            }
        }
    }
}
