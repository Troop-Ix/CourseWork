using DormitoryObjects;
using DormitoryObjects.Services;
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
    public partial class FloorsPlans : UserControl
    {
        RoomService _roomService;
        FloorLayout _currentFloorLayout;
        List<Room> _roomsForMap = new List<Room>();
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
        private void FloorPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_currentFloorLayout == null || _currentFloorLayout.Rooms == null) return;

            Graphics g = e.Graphics;

            foreach (var room in _roomsForMap)
            {
                var coord = _currentFloorLayout.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
                if (coord == null) continue;

                Brush brush = GetRoomStatusBrush(room);

                g.FillRectangle(brush, coord.X, coord.Y, coord.Width, coord.Height);
                g.DrawRectangle(Pens.Black, coord.X, coord.Y, coord.Width, coord.Height);

                g.DrawString(room.Number.ToString(), this.Font, Brushes.Black, coord.X + 5, coord.Y + 5);

            }
        }
        private Brush GetRoomStatusBrush(Room room)
        {
            int currentStudents = room.Students?.Count ?? 0;

            if (currentStudents >= room.Capacity)
                return Brushes.Red;

            if (currentStudents > 0)
                return Brushes.Yellow;

            return Brushes.LimeGreen;
        }
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
