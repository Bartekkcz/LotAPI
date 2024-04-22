using Application.Dto;
using Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using WebAPI.Controllers;

namespace WebAPI.Tests
{
    public class PlaneControllerTests
    {
        private readonly Mock<IPlaneService> _planeServiceMock;
        private readonly PlaneController _controller;

        public PlaneControllerTests()
        {
            _planeServiceMock = new Mock<IPlaneService>();
            _controller = new PlaneController(_planeServiceMock.Object);
        }

        [Fact]
        public void Get_ReturnsOkResult_WithListOfPlanes()
        {
            // Arrange
            _planeServiceMock.Setup(service => service.GetAllPlanes())
                .Returns(new List<PlaneDto>());

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_WithId_ReturnsNotFound_WhenPlaneDoesNotExist()
        {
            // Arrange
            _planeServiceMock.Setup(service => service.GetPlaneById(It.IsAny<int>()))
                .Returns((PlaneDto)null);

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_WithId_ReturnsOkResult_WhenPlaneExists()
        {
            // Arrange
            _planeServiceMock.Setup(service => service.GetPlaneById(It.IsAny<int>()))
                .Returns(new PlaneDto());

            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Create_ReturnsCreatedResult_WithNewPlane()
        {
            // Arrange
            var newPlane = new CreatePlaneDto();
            _planeServiceMock.Setup(service => service.AddNewPlane(newPlane))
                .Returns(new PlaneDto { Id = 1 });

            // Act
            var result = _controller.Create(newPlane);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal($"api/planes/1", createdResult.Location);
        }

        [Fact]
        public void Update_ReturnsNoContentResult_WhenUpdateIsSuccessful()
        {
            // Arrange
            var updatePlane = new UpdatePlaneDto();

            // Act
            var result = _controller.Update(updatePlane);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContentResult_WhenDeletionIsSuccessful()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}