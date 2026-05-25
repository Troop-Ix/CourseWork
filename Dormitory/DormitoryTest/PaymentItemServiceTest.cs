using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.RepositoriesInterfaces;
using DormitoryObjects.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class PaymentItemServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IPaymentItemRepository> _paymentRepoMock;
        private readonly PaymentItemService _service;

        public PaymentItemServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _paymentRepoMock = new Mock<IPaymentItemRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreatePaymentItemRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_paymentRepoMock.Object);

            _service = new PaymentItemService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetPaymentItems_ReturnsAllItems()
        {
            // Arrange
            var items = new List<PaymentItem>
            {
                new PaymentItem { PaymentItemID = 1, Name = "Коммунальные услуги" },
                new PaymentItem { PaymentItemID = 2, Name = "Доп. услуги" }
            };
            _paymentRepoMock.Setup(r => r.GetAll()).ReturnsAsync(items);

            // Act
            var result = await _service.GetPaymentItems();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Коммунальные услуги", result.First().Name);
        }

        [Fact]
        public async Task GetPaymentItemsID_ReturnsOnlyIdentifiers()
        {
            // Arrange
            var items = new List<PaymentItem>
            {
                new PaymentItem { PaymentItemID = 301 },
                new PaymentItem { PaymentItemID = 302 }
            };
            _paymentRepoMock.Setup(r => r.GetAll()).ReturnsAsync(items);

            // Act
            var result = await _service.GetPaymentItemsID();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(301, result);
            Assert.Contains(302, result);
        }

        [Fact]
        public async Task GetPaymentItemById_ReturnsCorrectItem()
        {
            // Arrange
            int id = 10;
            var item = new PaymentItem { PaymentItemID = id, Name = "Плата за проживание" };
            _paymentRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(item);

            // Act
            var result = await _service.GetPaymentItemById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.PaymentItemID);
            Assert.Equal("Плата за проживание", result.Name);
        }
    }
}