using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{/*
    [TestFixture]
    public class HolderServiceTests
    {
        private IHolderIdService _holderIdService;

        [SetUp]
        public void Before()
        {
            var accIdServiceMock = new Mock<IHolderIdService>();
            accIdServiceMock.SetupProperty(acc => acc.PrimaryNumber, 0);
            accIdServiceMock.Setup(acc => acc.GenerateHolderId()).Returns(1);
            _holderIdService = accIdServiceMock.Object;
        }

        #region Constructor tests

        [Test]
        public void TestConstructor_ValidValues_Service()
        {
            var repositoryMock = new Mock<IRepository<DTOHolder>>();
            repositoryMock.Setup(repo => repo.Items).Returns(new List<DTOHolder>());

            var holderService = new HolderService(_holderIdService, repositoryMock.Object);
        }

        [Test]
        public void TestConstructor_NullGenerator_ArgumentNullException()
        {
            var repositoryMock = new Mock<IRepository<DTOHolder>>();
            repositoryMock.Setup(repo => repo.Items).Returns(new List<DTOHolder>());

            Assert.Throws<ArgumentNullException>(() => new HolderService(null, repositoryMock.Object));
        }

        [Test]
        public void TestConstructor_NullRepository_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HolderService(_holderIdService, null));
        }

        #endregion

        [Test]
        public void TestAddHolder_ValidNameAndSurname_Holder()
        {
            var repositoryMock = new Mock<IRepository<DTOHolder>>();
            repositoryMock.Setup(repo => repo.Items).Returns(new List<DTOHolder>());
            repositoryMock.Setup(repo => repo.Add(It.IsAny<DTOHolder>()));
            var holderService = new HolderService(_holderIdService, repositoryMock.Object);

            holderService.AddHolder("Ruslan", "Bahirau");
        }
    }*/
}
