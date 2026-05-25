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
    /// <summary>
    /// Окно для назначения предмета на комнату
    /// </summary>
    public partial class SetInventoryForRoomForm : Form
    {
        SelectFloorAndNumberControl floorAndNumberControl;
        RoomService _roomService;
        InventoryService _inventoryService;
        int _itemID;
        public SetInventoryForRoomForm(RoomService roomService, InventoryService inventoryService, int itemID)
        {
            InitializeComponent();
            _inventoryService = inventoryService;
            _itemID = itemID;
            _roomService = roomService;
            floorAndNumberControl = new SelectFloorAndNumberControl(_roomService);
            LoadSelectingFloorAndNumber();
        }
        /// <summary>
        /// Загрузка пользовательского элемента управления, в котором имеются списки с номерами этажей и соответствующих им номеров комнат
        /// </summary>
        private void LoadSelectingFloorAndNumber()
        {
            floorAndNumberControl.Dock = DockStyle.Fill;

            panel1.Controls.Clear();

            panel1.Controls.Add(floorAndNumberControl);
        }
        /// <summary>
        /// Назначение предмета в выбранную комнату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Set_Click(object sender, EventArgs e)
        {
            int selectedFloor = floorAndNumberControl.SelectedFloor();
            int selectedNumber = floorAndNumberControl.SelectedNumber();
            var room = await _roomService.GetRoomByFloorAndNumber(selectedFloor, selectedNumber);
            if(room != null)
            {
                try
                {
                    await _inventoryService.SetInventoryForRoom(_itemID, room.RoomID);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось изменить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заданная комната не найдена");
            }
        } 
    }
}
