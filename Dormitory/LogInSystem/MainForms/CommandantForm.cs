using DormitoryObjects;
using DormitoryObjects.Fabrics;
using DormitoryObjects.Repositories;
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
            var ic = new InventoryControl(_inventoryService, _inventoryTypesService, _inventoryStatesService);

            ic.Dock = DockStyle.Fill;

            panel1.Controls.Clear();

            panel1.Controls.Add(ic);
        }
        private void LoadStudentsPanel(object sender, EventArgs e)
        {
            var sc = new StudentControl(_studentsService);

            sc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();

            panel2.Controls.Add(sc);
        }
        private void LoadRoomsyPanel(object sender, EventArgs e)
        {
            var rc = new RoomControl(_roomService);

            rc.Dock = DockStyle.Fill;

            panel3.Controls.Clear();

            panel3.Controls.Add(rc);
        }
        private void LoadPaymentsPanel(object sender, EventArgs e)
        {
            var pc = new PaymentControl(_paymentService, _paymentItemService);

            pc.Dock = DockStyle.Fill;

            panel4.Controls.Clear();

            panel4.Controls.Add(pc);
        }
        private void LoadBenefitTypesPanel(object sender, EventArgs e)
        {
            var bc = new BenefitControl(_benefitTypeService);

            bc.Dock = DockStyle.Fill;

            panel5.Controls.Clear();

            panel5.Controls.Add(bc);
        }
        private void LoadFloorsPlansPanel(object sender, EventArgs e)
        {
            var fp = new FloorsPlans(_roomService);

            fp.Dock = DockStyle.Fill;

            panel8.Controls.Clear();

            panel8.Controls.Add(fp);
        }

        private async void RemoveItemFromRoom_Click(object sender, EventArgs e)
        {
                var inventoryControl = panel1.Controls[0] as InventoryControl;
                if (inventoryControl != null)
                {
                    var success = await inventoryControl.RemoveItemFromRoom();
                    if (success)
                    {
                        await inventoryControl.LoadInventory();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось изменить данные.");
                    }
                }
        }
    }
}
