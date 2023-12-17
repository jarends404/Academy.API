using Academy.API.Infrastructure.Repositories.Courses;
using Academy.API.Models.Database;
using Academy.API.Models.Responses.Base;
using Academy.API.V1.Application.Commands;
using Academy.API.V1.Application.Validators;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using FluentAssertions;
using FluentValidation;
using Moq;

namespace Academy.API.UnitTest.V1.Application.Commands;

public class PostCourseCommandHandlerTest
{
    [Test]
    [InlineAutoData("Name", "Description", "2100-01-01", "2100-01-01", ResultStatus.Created)]
    [InlineAutoData("", "Description", "2100-01-01", "2100-01-01", ResultStatus.Invalid)]
    [InlineAutoData("Name", "", "2100-01-01", "2100-01-01", ResultStatus.Invalid)]
    [InlineAutoData("Name", "Description", "", "2100-01-01", ResultStatus.Invalid)]
    [InlineAutoData("Name", "Description", "2100-01-01", "", ResultStatus.Invalid)]
    [InlineAutoData("Name", "Description", "2000-01-01", "2100-01-01", ResultStatus.Invalid)]
    [InlineAutoData("Name", "Description", "2100-01-01", "2000-01-01", ResultStatus.Invalid)]
    public async Task PostCourseCommandHandler_Should_BehaveAsExpected(
        string name,
        string description,
        string startDate,
        string endDate,
        ResultStatus expectedStatus,
        [Frozen] Mock<ICourseRepository> courseRepositoryMock,
        [Frozen] Mock<IValidator<PostCourseCommand>> validatorMock)
    {
        // Arrange
        var handler = CreateHandler(courseRepositoryMock, validatorMock);

        // Act
        var result = await handler.Handle(new PostCourseCommand
        {
            Name = name,
            Description = description,
            StartDate = startDate,
            EndDate = endDate
        }, new CancellationToken());

        // Assert
        result.ResultStatus.Should().Be(expectedStatus);
    }

    private static PostCourseCommandHandler CreateHandler(
        Mock<ICourseRepository> courseRepositoryMock,
        Mock<IValidator<PostCourseCommand>> validatorMock)
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        
        courseRepositoryMock
            .Setup(repository => repository.StoreCourse(It.IsAny<Course>()))
            .Returns(Task.CompletedTask);
        validatorMock
            .Setup(validator => validator.ValidateAsync(It.IsAny<PostCourseCommand>(), It.IsAny<CancellationToken>()))
            .CallBase();
        fixture.Register<IValidator<PostCourseCommand>>(fixture.Create<PostCourseCommandValidator>);
        
        return fixture.Create<PostCourseCommandHandler>();
    }
}