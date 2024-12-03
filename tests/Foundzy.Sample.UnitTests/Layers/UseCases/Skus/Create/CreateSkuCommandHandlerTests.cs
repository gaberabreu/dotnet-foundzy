using Foundzy.Sample.Layers.Core.SkuAggregate;
using Foundzy.Sample.Layers.Core.SkuAggregate.Events;
using Foundzy.Sample.Layers.UseCases.Skus.Create;
using MediatR;
using Moq;

namespace Foundzy.Sample.UnitTests.Layers.UseCases.Skus.Create;

public class CreateSkuCommandHandlerTests
{
    private readonly Mock<IRepository<Sku>> _repository;
    private readonly Mock<IMediator> _mediator;
    private readonly CreateSkuCommandHandler _handler;

    public CreateSkuCommandHandlerTests()
    {
        _repository = new Mock<IRepository<Sku>>();
        _mediator = new Mock<IMediator>();
        _handler = new(_repository.Object, _mediator.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddSkuProperly()
    {
        // Arrange
        var command = new CreateSkuCommand("Name");

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _repository.Verify(e => e.AddAsync(It.IsAny<Sku>(), It.IsAny<CancellationToken>()), Times.Once);
        _mediator.Verify(e => e.Publish(It.IsAny<SkuCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
