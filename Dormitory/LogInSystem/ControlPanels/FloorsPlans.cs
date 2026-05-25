using DormitoryObjects;
using DormitoryObjects.DTO;
using DormitoryObjects.Services;
using LogInSystem.Fabrics;
using LogInSystem.HelpingForms;
using LogInSystem.XMLClassesForDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LogInSystem
{
    /// <summary>
    /// Пользовательский элемент управления для отображения плана комнат по этажам
    /// </summary>
    public partial class FloorsPlans : UserControl
    {
        RoomService _roomService;
        FloorLayout _currentFloorLayout;
        List<RoomDTO> _roomsForMap = new List<RoomDTO>();
        LayoutManager _layoutManager = new LayoutManager();
        public FloorsPlans(RoomService roomService)
        {
            InitializeComponent();
            _roomService = roomService;

            FloorPanel.Paint += FloorPanel_Paint;
            FloorPanel.MouseDoubleClick += FloorPanel_MouseDoubleClick;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        /// <summary>
        /// Загрузка данных по расположению и размеру комнат из XML-файла
        /// </summary>
        private async void LoadInitialization()
        {
            try
            {
                _layoutManager.LoadAll(@"I:\courses\course2\C#\курсовая\Project\Dormitory\LogInSystem\BuildingLayout.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки XML-файла: {ex.Message}");
                return;
            }

            var floors = await _roomService.GetFloors();
            FloorsList.DataSource = floors.ToList();

            if (floors.Any())
            {
                FloorsList.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Покраска комнат в зависимости от заполненности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloorPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_currentFloorLayout == null || _currentFloorLayout.Rooms == null) return;

            Graphics g = e.Graphics;

            foreach (var room in _roomsForMap)
            {
                var coord = _currentFloorLayout.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
                if (coord == null) continue;

                Brush brush = RoomStyler.GetBrushByStatus(room); 

                g.FillRectangle(brush, coord.X, coord.Y, coord.Width, coord.Height);
                g.DrawRectangle(Pens.Black, coord.X, coord.Y, coord.Width, coord.Height);

                g.DrawString(room.Number.ToString(), this.Font, Brushes.Black, coord.X + 5, coord.Y + 5);

            }
        }
        /// <summary>
        /// Вызов окна с информацией по комнате, по которой был произведен двойно щелчок мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloorPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_currentFloorLayout == null || _roomsForMap == null) return;

            foreach (var room in _roomsForMap)
            {
                var coord = _currentFloorLayout.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
                if (coord == null) continue;

                Rectangle roomRect = new Rectangle(coord.X, coord.Y, coord.Width, coord.Height);

                if (roomRect.Contains(e.Location))
                {
                    ShowRoomInfo roomInfo = new ShowRoomInfo(room);
                    roomInfo.ShowDialog();
                    break;
                }
            }
        }
        /// <summary>
        /// Изменение отображения плана этажа в зависимости от выбранного этажа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FloorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FloorsList.SelectedItem == null) return;

            int selectedFloor = (int)FloorsList.SelectedItem;

            try
            {
                _currentFloorLayout = _layoutManager.GetRoomsForFloor(selectedFloor);

                var rooms = await _roomService.GetRoomsFromFloor(selectedFloor);
                _roomsForMap = rooms.ToList();

                FloorPanel.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки этажа {selectedFloor}: {ex.Message}");
            }
        }
    }
}
