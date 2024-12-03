using FluentAssertions;
using Foundzy.Sample.Layers.Core.SkuAggregate;
using Foundzy.Sample.Layers.UseCases.Skus.Create;
using Foundzy.Sample.Layers.Web.Controllers;
using Foundzy.Sample.Layers.Web.Requests;
using MediatR;
using Moq;

namespace Foundzy.Sample.UnitTests.Layers.Web.Controllers;

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
    public async Task Create_ShouldDispatchCommandProperly()
    {
        // Arrange
        var request = new CreateSkuRequest()
        {
            Name = "Name"
        };

        var sku = new Sku(request.Name);

        _mediator.Setup(e => e.Send(It.IsAny<CreateSkuCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(sku);

        // Act
        var result = await _controller.Create(request);

        // Assert
        result.Value.Should().Be(sku);

        _mediator.Verify(e => e.Send(It.IsAny<CreateSkuCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
