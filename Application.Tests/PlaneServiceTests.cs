using Application.Dto;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;

public class PlaneServiceTests
{
    private readonly Mock<IPlaneRepository> _planeRepositoryMock;
    private readonly IMapper _mapper;
    private readonly PlaneService _service;

    public IMapper CreateTestMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Plane, PlaneDto>();
            cfg.CreateMap<CreatePlaneDto, Plane>();
            cfg.CreateMap<UpdatePlaneDto, Plane>();

            cfg.CreateMap<RegisterUserDto, User>();
            cfg.CreateMap<User, RegisterUserDto>();

            cfg.CreateMap<RegisterUserDto, UserDto>();
            cfg.CreateMap<UserDto, RegisterUserDto>();

            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<Role, RoleDto>();
        });
        return config.CreateMapper();
    }
    public PlaneServiceTests()
    {
        _planeRepositoryMock = new Mock<IPlaneRepository>();
        _mapper = CreateTestMapper();
        _service = new PlaneService(_planeRepositoryMock.Object, _mapper);
    }


    [Fact]
    public void GetAllPlanes_ReturnsAllPlanes()
    {
        // Arrange
        var planes = new List<Plane> { new Plane(), new Plane() };
        _planeRepositoryMock.Setup(repo => repo.GetALL())
            .Returns(planes);

        // Act
        var result = _service.GetAllPlanes();

        // Assert
        var mappedResult = _mapper.Map<IEnumerable<PlaneDto>>(planes);
        result.Should().BeEquivalentTo(mappedResult);
    }

    [Fact]
    public void GetPlaneById_ReturnsPlaneWithGivenId()
    {
        // Arrange
        var plane = new Plane { Id = 1 };
        _planeRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>()))
            .Returns(plane);

        // Act
        var result = _service.GetPlaneById(1);

        // Assert
        var mappedResult = _mapper.Map<PlaneDto>(plane);
        result.Should().BeEquivalentTo(mappedResult);
    }

    [Fact]
    public void AddNewPlane_WithValidFlightNumber_ReturnsPlaneDto()
    {
        // Arrange
        var newPlane = new CreatePlaneDto
        {
            FlightNumber = "LO123",
            DepartureDate = DateTime.Now.AddDays(2),
            DeparturePlace = "Warszawa",
            ArrivalPlace = "Kraków",
            PlaneType = "Boeing 737"
        };
        var plane = _mapper.Map<Plane>(newPlane);
        _planeRepositoryMock.Setup(repo => repo.Add(plane));

        // Act
        var result = _service.AddNewPlane(newPlane);

        // Assert
        var expected = _mapper.Map<PlaneDto>(plane);
        result.Should().BeEquivalentTo(expected);
    }


    [Fact]
    public void UpdatePlane_WithValidUpdate_ReturnsNothing()
    {
        // Arrange
        var updatePlane = new UpdatePlaneDto { Id = 1, PlaneType = "Boeing 737" };
        var existingPlane = new Plane();
        _planeRepositoryMock.Setup(repo => repo.GetById(updatePlane.Id)).Returns(existingPlane);

        // Act
        _service.UpdatePlane(updatePlane);

        // Assert
        _planeRepositoryMock.Verify(repo => repo.Update(It.Is<Plane>(p => p == existingPlane)), Times.Once);
    }

    [Fact]
    public void DeletePlane_WithValidId_ReturnsNothing()
    {
        // Arrange
        var id = 1;
        var plane = new Plane();
        _planeRepositoryMock.Setup(repo => repo.GetById(id)).Returns(plane);
        _planeRepositoryMock.Setup(repo => repo.Delete(plane));

        // Act
        _service.DeletePlane(id);

        // Assert
        _planeRepositoryMock.Verify(repo => repo.Delete(plane), Times.Once);
    }
}