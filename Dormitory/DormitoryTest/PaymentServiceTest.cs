using DormitoryObjects;
using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.RepositoriesInterfaces;
using DormitoryObjects.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class PaymentServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IPaymentRepository> _paymentRepoMock;
        private readonly PaymentService _service;

        public PaymentServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _paymentRepoMock = new Mock<IPaymentRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreatePaymentRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_paymentRepoMock.Object);

            _service = new PaymentService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetPayments_ReturnsAllPayments()
        {
            // Arrange
            var payments = new List<Payment>
            {
                new Payment { PaymentID = 1, PaidAmount = 1000 },
                new Payment { PaymentID = 2, PaidAmount = 2000 }
            };
            _paymentRepoMock.Setup(r => r.GetAll()).ReturnsAsync(payments);

            // Act
            var result = await _service.GetPayments();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task AddPayment_ValidData_CallsCreate()
        {
            // Act
            await _service.AddPayment(1, 500, 1000, 1, DateTime.Now);

            // Assert
            _paymentRepoMock.Verify(r => r.Create(It.Is<Payment>(p =>
                p.StudentID == 1 &&
                p.PaidAmount == 500 &&
                p.AmountDue == 1000)), Times.Once);
        }

        [Fact]
        public async Task ChangePayment_PaymentExists_UpdatesData()
        {
            // Arrange
            var payment = new Payment { PaymentID = 1, PaidAmount = 100, LastPaymentDate = DateTime.MinValue };
            _paymentRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(payment);

            var newDate = DateTime.Now;

            // Act
            await _service.ChangePayment(1, 500, newDate);

            // Assert
            Assert.Equal(500, payment.PaidAmount);
            Assert.Equal(newDate, payment.LastPaymentDate);
            _paymentRepoMock.Verify(r => r.Update(payment, 1), Times.Once);
        }

        [Fact]
        public async Task ChangePayment_PaymentNotFound_ThrowsException()
        {
            // Arrange
            _paymentRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Payment)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _service.ChangePayment(99, 500, DateTime.Now));
            Assert.Equal("Платеж не найден в базе данных", ex.Message);
        }

        [Fact]
        public async Task RemovePayment_CallsDelete()
        {
            // Arrange
            int paymentId = 1;
            _paymentRepoMock.Setup(r => r.GetById(paymentId)).ReturnsAsync(new Payment());

            // Act
            await _service.RemovePayment(paymentId);

            // Assert
            _paymentRepoMock.Verify(r => r.Delete(paymentId), Times.Once);
        }

        [Fact]
        public async Task GetPaymentByID_ReturnsCorrectPayment()
        {
            // Arrange
            var payment = new Payment { PaymentID = 5, PaidAmount = 300 };
            _paymentRepoMock.Setup(r => r.GetById(5)).ReturnsAsync(payment);

            // Act
            var result = await _service.GetPaymentByID(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.PaymentID);
        }
    }
}