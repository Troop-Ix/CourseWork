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
    /// <summary>
    /// Форма управления администратора
    /// </summary>
    public partial class AdministratorForm : Form
    {
        // log: Administrator
        // pass: zUmz2hm4
        IDbFactory _factory;
        RepositoryFactory _repositoryFactory;

        InventoryService _inventoryService;
        InventoryTypeService _inventoryTypesService;
        InventoryStateService _inventoryStatesService;

        StudentsService _studentsService;

        BenefitTypeService _benefitTypeService;

        InventoryControl _inventoryControl;
        StudentControl _studentControl;

        public AdministratorForm(IDbFactory factory, User user)
        {
            InitializeComponent();
            _factory = factory;
            _repositoryFactory = new RepositoryFactory();

            _inventoryService = new InventoryService(_factory, _repositoryFactory);
            _inventoryStatesService = new InventoryStateService(_factory, _repositoryFactory);
            _inventoryTypesService = new InventoryTypeService(_factory, _repositoryFactory);

            _studentsService = new StudentsService(_factory, _repositoryFactory);


            _benefitTypeService = new BenefitTypeService(_factory, _repositoryFactory);

            FIO.Text = $"{user.Surname} {user.Name} {user.Middlename}";
            Role.Text = user.Type;


            this.Load += LoadTabs;
        }
        /// <summary>
        /// Заполнение вкладок пользовательскими элементами управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadTabs(object sender, EventArgs e)
        {
            _inventoryControl = new InventoryControl(_inventoryService, _inventoryTypesService, _inventoryStatesService);
            _inventoryControl.Dock = DockStyle.Fill;
            Inventorypanel.Controls.Clear();
            Inventorypanel.Controls.Add(_inventoryControl);

            _studentControl = new StudentControl(_studentsService, _benefitTypeService);
            _studentControl.Dock = DockStyle.Fill;
            Studentpanel.Controls.Clear();
            Studentpanel.Controls.Add(_studentControl);
        }
        /// <summary>
        /// Вызов окна для добавления предмета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Удаление выбранного в пользовательском элементе управления Инвентаря предмета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Открытие окна для изменения состояния выбранного в пользовательском элементе управления Инвентаря предмета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Открытие окна с таблицей должников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDebtors_Click(object sender, EventArgs e)
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
