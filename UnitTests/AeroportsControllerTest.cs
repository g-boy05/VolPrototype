using ArtzaTechnologies.Controllers;
using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AeroportsControllerTest
    {
        [Fact]
        public async Task Index_ReturnsAviewResult_WithAListOfVolsDto()
        {
            var mockService = new Mock<IAeroportService>();
            mockService.Setup(service => service.GetAeroports()).Returns(await Task.FromResult(GetAeroportsAsyncTest()));
            var controller = new AeroportsController(mockService.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var dtos = Assert.IsAssignableFrom<ICollection<Aeroport>>(viewResult.ViewData.Model);

            Assert.Equal(3,dtos.Count);
        }

        #region privateMethods

        private Task<ICollection<Aeroport>> GetAeroportsAsyncTest()
        {
            ICollection<Aeroport> aeroports=new Collection<Aeroport>
            {
                new Aeroport(),
                new Aeroport(),
                new Aeroport()
            };
            return Task.FromResult(aeroports);
        }
        

        #endregion
    }
}
