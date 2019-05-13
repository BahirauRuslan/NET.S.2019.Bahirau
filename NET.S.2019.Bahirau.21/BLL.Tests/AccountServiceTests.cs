using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private IAccountIdService _accountIdService;

        [SetUp]
        public void Before()
        {
            var accIdServiceMock = new Mock<IAccountIdService>();
            accIdServiceMock.SetupProperty(acc => acc.PrimaryNumber, 0);
            accIdServiceMock.Setup(acc => acc.GenerateAccountId()).Returns(1);
            _accountIdService = accIdServiceMock.Object;
        }

        #region Constructor tests

        [Test]
        public void TestConstructor_ValidValues_Service()
        {
            var repositoryMock = new Mock<IRepository<DTOAccount>>();
            repositoryMock.Setup(repo => repo.Items).Returns(new List<DTOAccount>());

            var accountService = new AccountService(_accountIdService, repositoryMock.Object);
        }

        [Test]
        public void TestConstructor_NullGenerator_ArgumentNullException()
        {
            var repositoryMock = new Mock<IRepository<DTOAccount>>();
            repositoryMock.Setup(repo => repo.Items).Returns(new List<DTOAccount>());

            Assert.Throws<ArgumentNullException>(() => new AccountService(null, repositoryMock.Object));
        }

        [Test]
        public void TestConstructor_NullRepository_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AccountService(_accountIdService, null));
        }

        #endregion

        [Test]
        public void TestAddAccount_HolderAndBaseType_Account()
        {
            var repositoryMock = new Mock<IRepository<DTOAccount>>();
            repositoryMock.Setup(repo => repo.Items).Returns(new List<DTOAccount>());
            repositoryMock.Setup(repo => repo.Add(It.IsAny<DTOAccount>()));
            var accountService = new AccountService(_accountIdService, repositoryMock.Object);
            accountService.AddAccount(new Holder(), "Base");
        }
    }
}
