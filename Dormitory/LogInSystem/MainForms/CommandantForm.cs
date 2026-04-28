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
        StudentBenefitService _studentBenefitService;

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
       
        private async void RemoveItemFromRoom_Click(object sender, EventArgs e)
        {
                if (_inventoryControl != null)
                {
                var itemID = _inventoryControl.GetSelectedItemID();
                if (!itemID.HasValue)
                {
                    MessageBox.Show("Выберите студента в списке");
                    return;
                }
                else
                {
                    try
                    {
                        await _inventoryService.RemoveInventoryFromRoom(itemID.Value);
                        await _inventoryControl.LoadInventory();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                    }
                }
                }
        }

        private async void SetItemForRoom_Click(object sender, EventArgs e)
        {
            if (_inventoryControl != null)
            {
                var itemID = _inventoryControl.GetSelectedItemID();
                if (!itemID.HasValue)
                {
                    MessageBox.Show("Выберите студента в списке");
                    return;
                }
                else
                {
                    using (var setItem = new SetInventoryForRoomForm(_roomService, _inventoryService, itemID.Value))
                    {
                        try
                        {
                            setItem.ShowDialog();
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

        private async void EvictStudentFromRoom_Click(object sender, EventArgs e)
        {
            if (_studentControl != null)
            {
                var studentID = _studentControl.GetSelectedStudentID();
                if (!studentID.HasValue)
                {
                    MessageBox.Show("Выберите студента в списке");
                    return;
                }
                else
                {
                    await _studentsService.EvictStudent(studentID.Value);
                    await _studentControl.LoadStudents();
                }

            }
        }

        private async void SetRoomForStudent_Click(object sender, EventArgs e)
        {
            if (_studentControl != null)
            {
                var studentID = _studentControl.GetSelectedStudentID();
                if (!studentID.HasValue)
                {
                    MessageBox.Show("Выберите студента в списке");
                    return;
                }
                else
                {
                    using (var setStudent = new SetRoomForStudentForm(_roomService, _studentsService, studentID.Value))
                    {
                        try
                        {
                            setStudent.ShowDialog();
                            await _studentControl.LoadStudents();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                        }
                    }
                }

            }
        }

        private async void AddBenefit_Click(object sender, EventArgs e)
        {
            if (_studentControl != null)
            {
                var studentID = _studentControl.GetSelectedStudentID();

                if (!studentID.HasValue)
                {
                    MessageBox.Show("Выберите студента в списке");
                    return;
                }
                else
                {
                    using (var setBenefit = new SetBenefitForStudentForm(_benefitTypeService, _studentBenefitService, studentID.Value))
                    {
                        try
                        {
                            setBenefit.ShowDialog();
                            await _studentControl.LoadStudents();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                        }
                    }
                }
            }
        }

        private async void RemoveBenefitsFromStudent_Click(object sender, EventArgs e)
        {
            if (_studentControl == null) return;

            var studentID = _studentControl.GetSelectedStudentID();

            if (!studentID.HasValue)
            {
                MessageBox.Show("Выберите студента в списке");
                return;
            }

            try
            {
                var student = await _studentsService.GetStudentById(studentID.Value);
                if (student == null)
                {
                    MessageBox.Show("Студент не найден");
                    return;
                }
                foreach (var sb in student.StudentBenefits)
                {
                    await _studentBenefitService.RemoveBenefitFromStudent(sb.StudentBenefitID);
                }

                await _studentControl.LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
        private async void AddPayment_Click(object sender, EventArgs e)
        {
            if (_paymentControl != null)
            {
                using (var addPayment = new AddPaymentForm(_studentsService, _paymentItemService, _paymentService))
                {
                        try
                        {
                            addPayment.ShowDialog();
                            await _paymentControl.LoadPayments();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                        }
                }
            }
        }
        private void ChangePayment_Click(object sender, EventArgs e)
        {

        }

        private async void RemovePayment_Click(object sender, EventArgs e)
        {
            if (_paymentControl != null)
            {
                var paymentID = _paymentControl.GetSelectedPaymentID();

                if (!paymentID.HasValue)
                {
                    MessageBox.Show("Выберите оплату в списке");
                    return;
                }
                else
                {
                    try
                    {
                        await _paymentService.RemovePayment(paymentID.Value);
                        await _paymentControl.LoadPayments();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось удалить платеж: {ex.Message}",
                                        "Ошибка базы данных",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
