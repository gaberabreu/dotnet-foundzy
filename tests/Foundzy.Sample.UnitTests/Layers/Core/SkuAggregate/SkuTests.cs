﻿using FluentAssertions;
using Foundzy.Sample.Layers.Core.SkuAggregate;

namespace Foundzy.Sample.UnitTests.Layers.Core.SkuAggregate;

public class SkuTests
{
    [Fact]
    public void Ctor1_ShouldInstantiateProperly()
    {
        // Arrange
        var name = "Name";

        // Act
        var sku = new Sku(name);

        // Assert
        sku.Id.Should().NotBeEmpty();
        sku.Name.Should().Be(name);
    }

    [Fact]
    public void Ctor2_ShouldInstantiateProperly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Name";

        // Act
        var sku = new Sku(id, name);

        // Assert
        sku.Id.Should().Be(id);
        sku.Name.Should().Be(name);
    }
}
