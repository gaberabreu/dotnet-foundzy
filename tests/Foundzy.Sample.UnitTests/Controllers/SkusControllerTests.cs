using FluentAssertions;
using Foundzy.Sample.Application.Commands;
using Foundzy.Sample.Controllers;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Requests;
using MediatR;
using Moq;

namespace Foundzy.Sample.UnitTests.Controllers;

public class SkusControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly SkusController _controller;

    public SkusControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _controller = new(_mediator.Object);
    }

    [Fact]
    public async Task Add_ShouldDispatchCommandProperly()
    {
        // Arrange
        var request = new AddSkuRequest()
        {
            Name = "Name"
        };

        var sku = new Sku(request.Name);

        _mediator.Setup(e => e.Send(It.IsAny<AddSkuCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(sku);

        // Act
        var result = await _controller.Add(request);

        // Assert
        result.Value.Should().Be(sku);

        _mediator.Verify(e => e.Send(It.IsAny<AddSkuCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
