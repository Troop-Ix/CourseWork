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
    public partial class AdministratorForm : Form
    {
        // log: Administrator
        // pass: zUmz2hm4
        IDbFactory _factory;
        InventoryService _inventoryService;
        InventoryTypesService _inventoryTypesService;
        InventoryStatesService _inventoryStatesService;

        StudentsService _studentsService;

        RoomService _roomService;

        PaymentService _paymentService;
        PaymentItemService _paymentItemService;

        BenefitTypeService _benefitTypeService;
        StudentBenefitService _studentBenefitService;

        InventoryControl _inventoryControl;
        StudentControl _studentControl;
        RoomControl _roomControl;
        PaymentControl _paymentControl;
        BenefitControl _benefitControl;
        FloorsPlans _floorsPlans;
        public AdministratorForm(IDbFactory factory, User user)
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
            _studentBenefitService = new StudentBenefitService(_factory);

            FIO.Text = $"{user.Surname} {user.Name} {user.Middlename}";
            Role.Text = user.Type;


            this.Load += LoadTabs;
        }
        private void LoadTabs(object sender, EventArgs e)
        {
            _inventoryControl = new InventoryControl(_inventoryService, _inventoryTypesService, _inventoryStatesService);
            _inventoryControl.Dock = DockStyle.Fill;
            Inventorypanel.Controls.Clear();
            Inventorypanel.Controls.Add(_inventoryControl);

            _studentControl = new StudentControl(_studentsService);
            _studentControl.Dock = DockStyle.Fill;
            Studentpanel.Controls.Clear();
            Studentpanel.Controls.Add(_studentControl);

            _roomControl = new RoomControl(_roomService);
            _roomControl.Dock = DockStyle.Fill;
            RoomPanel.Controls.Clear();
            RoomPanel.Controls.Add(_roomControl);

            _paymentControl = new PaymentControl(_paymentService, _paymentItemService);
            _paymentControl.Dock = DockStyle.Fill;
            Paymentpanel.Controls.Clear();
            Paymentpanel.Controls.Add(_paymentControl);

            _benefitControl = new BenefitControl(_benefitTypeService);
            _benefitControl.Dock = DockStyle.Fill;
            Benefitpanel.Controls.Clear();
            Benefitpanel.Controls.Add(_benefitControl);

            _floorsPlans = new FloorsPlans(_roomService);
            _floorsPlans.Dock = DockStyle.Fill;
            Planpanel.Controls.Clear();
            Planpanel.Controls.Add(_floorsPlans);
        }

        private async void AddItem_Click(object sender, EventArgs e)
        {
            if (_inventoryControl != null)
            {
                    using (var addItem = new AddItemForm(_inventoryService, _inventoryTypesService))
                    {
                        try
                        {
                            addItem.ShowDialog();
                            await _inventoryControl.LoadInventory();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                        }
                    }
            }
        }

        private async void RemoveItem_Click(object sender, EventArgs e)
        {
            if (_inventoryControl != null)
            {
                var itemID = _inventoryControl.GetSelectedItemID();
                if (!itemID.HasValue)
                {
                    MessageBox.Show("Выберите предмет в списке");
                    return;
                }
                else
                {
                    await _inventoryService.RemoveInventory(itemID.Value);
                    await _inventoryControl.LoadInventory();
                }

            }
        }

        private async void ChangeStateOfItem_Click(object sender, EventArgs e)
        {
            if (_inventoryControl != null)
            {
                var itemID = _inventoryControl.GetSelectedItemID();
                if (!itemID.HasValue)
                {
                    MessageBox.Show("Выберите предмет в списке");
                    return;
                }
                else
                {
                    using (var changeItem = new ChangeItemConditionForm(itemID.Value, _inventoryService, _inventoryStatesService))
                    {
                        try
                        {
                            changeItem.ShowDialog();
                            await _inventoryControl.LoadInventory();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void GetDebtors_Click(object sender, EventArgs e)
        {
            if(_studentControl!= null)
            {
                using (var showDebtors = new ShowDebtorsForm(_studentsService))
                {
                    try
                    {
                        showDebtors.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                    }
                }
            }
        }
    }
}
