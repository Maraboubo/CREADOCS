using Xunit;
using Moq;
using ApiCreadocs.Models;
using ApiCreadocs.Repository;
using ApiCreadocs.Services;

namespace Creadocs.Tests.ServicesTests
{
    public class InterlocuteurServiceTest
    {
        [Fact]
        public void GetInterlocuteurById_ReturnsCorrectInterlocuteur()
        {
            // Arrange
            var RepositoryFictif = new Mock<InterfaceInterlocuteurRepository>();
            var interlocuteurId = 1;
            var InterlocuteurAttendu = new Interlocuteur { id_inter = interlocuteurId, nomInter = "Dupont", prenomInter = "Jean" };

            RepositoryFictif.Setup(repo => repo.GetById(interlocuteurId))
                .Returns(InterlocuteurAttendu);

            var service = new InterlocuteurService(RepositoryFictif.Object);

            // Act
            var result = service.GetInterlocuteurById(interlocuteurId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(interlocuteurId, result.id_inter);
            Assert.Equal("Dupont", result.nomInter);
            Assert.Equal("Jean", result.prenomInter);
        }

        [Fact]
        public void GetInterlocuteurById_ReturnsNullForNonexistentId()
        {
            // Arrange
            var RepositoryFictif = new Mock<InterfaceInterlocuteurRepository>();
            var IdInterInexistant = 999;

            RepositoryFictif.Setup(repo => repo.GetById(IdInterInexistant))
                .Returns((Interlocuteur)null);

            var service = new InterlocuteurService(RepositoryFictif.Object);

            // Act
            var result = service.GetInterlocuteurById(IdInterInexistant);

            // Assert
            Assert.Null(result);
        }
    }
}
