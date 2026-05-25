using DormitoryObjects;
using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using DormitoryObjects.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class UserServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IUserAdvancedRepository> _userRepoMock;
        private readonly UserService _service;

        public UserServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _userRepoMock = new Mock<IUserAdvancedRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreateUserAdvancedRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_userRepoMock.Object);

            _service = new UserService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetUserByLogin_ReturnsCorrectUser()
        {
            // Arrange
            string login = "admin";
            var expectedUser = new User { UserID = 1, Login = login };
            _userRepoMock.Setup(r => r.GetByLogin(login)).ReturnsAsync(expectedUser);

            // Act
            var result = await _service.GetUserByLogin(login);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(login, result.Login);
            _userRepoMock.Verify(r => r.GetByLogin(login), Times.Once);
        }

        [Fact]
        public async Task GetUserById_ReturnsCorrectUser()
        {
            // Arrange
            int id = 10;
            var expectedUser = new User { UserID = id, Login = "test user" };
            _userRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(expectedUser);

            // Act
            var result = await _service.GetUserById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.UserID);
            _userRepoMock.Verify(r => r.GetById(id), Times.Once);
        }
    }
}