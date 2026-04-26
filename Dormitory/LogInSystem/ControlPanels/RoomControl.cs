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

namespace LogInSystem
{
    public partial class RoomControl : UserControl
    {
        RoomService _roomService;
        public RoomControl(RoomService roomService)
        {
            InitializeComponent();
            _roomService = roomService;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            this.Load += RoomControl_Load;
        }
        private async void RoomControl_Load(object sender, EventArgs e)
        {
            await LoadRooms();
        }
        private async Task LoadRooms()
        {
            try
            {
                int availablePlaces = (int)AvailablePlaces.Value;
                var rooms = await _roomService.GetFilteredRooms(availablePlaces);
                dataGridView1.DataSource = rooms.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

       
        private async void AvailablePlaces_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                int availablePlaces = (int)AvailablePlaces.Value;
                var rooms = await _roomService.GetFilteredRooms(availablePlaces);
                dataGridView1.DataSource = rooms.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
