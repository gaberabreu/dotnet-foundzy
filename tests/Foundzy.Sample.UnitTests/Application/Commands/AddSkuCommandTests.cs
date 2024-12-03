using Foundzy.Sample.Application.Commands;
using Foundzy.Sample.Application.Events;
using Foundzy.Sample.Domain.Entities;
using Foundzy.Sample.Domain.Interfaces;
using MediatR;
using Moq;

namespace Foundzy.Sample.UnitTests.Application.Commands;

public class AddSkuCommandHandlerTests
{
    private readonly Mock<ISkuRepository> _repository;
    private readonly Mock<IMediator> _mediator;
    private readonly AddSkuCommandHandler _handler;

    public AddSkuCommandHandlerTests()
    {
        _repository = new Mock<ISkuRepository>();
        _mediator = new Mock<IMediator>();
        _handler = new(_repository.Object, _mediator.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddSkuProperly()
    {
        // Arrange
        var command = new AddSkuCommand("Name");

        // Act
        await _handler.Handle(command);

        // Assert
        _repository.Verify(e => e.Add(It.IsAny<Sku>(), It.IsAny<CancellationToken>()), Times.Once);
        _mediator.Verify(e => e.Publish(It.IsAny<SkuAddedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
