using DormitoryObjects;
using DormitoryObjects.Fabrics;
using DormitoryObjects.Repositories;
using DormitoryObjects.Services;
using LogInSystem.HelpingForms;
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
    public partial class CommandantForm : Form
    {
        // log: Commandant
        // pass: CsoBoV0T
        IDbFactory _factory;
        InventoryService _inventoryService;
        InventoryTypesService _inventoryTypesService;
        InventoryStatesService _inventoryStatesService;

        StudentsService _studentsService;

        RoomService _roomService;

        PaymentService _paymentService;
        PaymentItemService _paymentItemService;

        BenefitTypeService _benefitTypeService;

        InventoryControl _inventoryControl;
        StudentControl _studentControl;
        RoomControl _roomControl;
        PaymentControl _paymentControl;
        BenefitControl _benefitControl;
        FloorsPlans _floorsPlans;
        public CommandantForm(IDbFactory factory, User user)
        {
            InitializeComponent();
            _factory = factory;

            _inventoryService = new InventoryService(_factory);
            _inventoryStatesService = new InventoryStatesService(_factory);
            _inventoryTypesService = new InventoryTypesService(_factory);

            _studentsService = new StudentsService(_factory);

            _roomService = new RoomService(_factory);

            _paymentService = new PaymentService(_factory);
            _paymentItemService = new PaymentItemService(_factory);

            _benefitTypeService = new BenefitTypeService(_factory);

            FIO.Text = $"{user.Surname} {user.Name} {user.Middlename}";
            Role.Text = user.Type;

            this.Load += LoadInventoryPanel;
            this.Load += LoadStudentsPanel;
            this.Load += LoadPaymentsPanel;
            this.Load += LoadRoomsyPanel;
            this.Load += LoadBenefitTypesPanel;
            this.Load += LoadFloorsPlansPanel;
        }
        private void LoadInventoryPanel(object sender, EventArgs e)
        {
            _inventoryControl = new InventoryControl(_inventoryService, _inventoryTypesService, _inventoryStatesService);

            _inventoryControl.Dock = DockStyle.Fill;

            panel1.Controls.Clear();

            panel1.Controls.Add(_inventoryControl);
        }
        private void LoadStudentsPanel(object sender, EventArgs e)
        {
            _studentControl = new StudentControl(_studentsService);

            _studentControl.Dock = DockStyle.Fill;

            panel2.Controls.Clear();

            panel2.Controls.Add(_studentControl);
        }
        private void LoadRoomsyPanel(object sender, EventArgs e)
        {
            _roomControl = new RoomControl(_roomService);

            _roomControl.Dock = DockStyle.Fill;

            panel3.Controls.Clear();

            panel3.Controls.Add(_roomControl);
        }
        private void LoadPaymentsPanel(object sender, EventArgs e)
        {
            _paymentControl = new PaymentControl(_paymentService, _paymentItemService);

            _paymentControl.Dock = DockStyle.Fill;

            panel4.Controls.Clear();

            panel4.Controls.Add(_paymentControl);
        }
        private void LoadBenefitTypesPanel(object sender, EventArgs e)
        {
            _benefitControl = new BenefitControl(_benefitTypeService);

            _benefitControl.Dock = DockStyle.Fill;

            panel5.Controls.Clear();

            panel5.Controls.Add(_benefitControl);
        }
        private void LoadFloorsPlansPanel(object sender, EventArgs e)
        {
            _floorsPlans = new FloorsPlans(_roomService);

            _floorsPlans.Dock = DockStyle.Fill;

            panel8.Controls.Clear();

            panel8.Controls.Add(_floorsPlans);
        }

        private async void RemoveItemFromRoom_Click(object sender, EventArgs e)
        {
                if (_inventoryControl != null)
                {
                    var item =  _inventoryControl.GetSelectedItem();
                    if (item!=null)
                    {
                        await _inventoryService.RemoveInventoryFromRoom(item.ItemID);
                        await _inventoryControl.LoadInventory();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось изменить данные.");
                    }
                }
        }

        private async void SetItemForRoom_Click(object sender, EventArgs e)
        {
            if (_inventoryControl != null)
            {
                var item = _inventoryControl.GetSelectedItem();
                if (item != null)
                {
                    SetInventoryForRoomForm setItem = new SetInventoryForRoomForm(_roomService, _inventoryService, item.ItemID);
                    setItem.ShowDialog();
                    await _inventoryControl.LoadInventory();
                }
                else
                {
                    MessageBox.Show("Не удалось изменить данные.");
                }
            }
        }
    }
}
