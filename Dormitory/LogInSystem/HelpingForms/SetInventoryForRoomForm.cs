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

namespace LogInSystem.HelpingForms
{
    public partial class SetInventoryForRoomForm : Form
    {
        RoomService _roomService;
        InventoryService _inventoryService;
        int _itemID;
        public SetInventoryForRoomForm(RoomService roomService, InventoryService inventoryService, int itemID)
        {
            InitializeComponent();
            _roomService = roomService;
            _inventoryService = inventoryService;
            _itemID = itemID;
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

        private async void Set_Click(object sender, EventArgs e)
        {
            int selectedFloor = (int)FloorsList.SelectedItem;
            int selectedNumber = (int)NumbersList.SelectedItem;
            var room = await _roomService.GetRoomByFloorAndNumber(selectedFloor, selectedNumber);
            if(room != null)
            {
                await _inventoryService.SetInventoryForRoom(_itemID, room.RoomID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Заданная комната не найдена");
            }
        }

        private async void FloorsList_SelectedIndexChanged(object sender, EventArgs e)
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
