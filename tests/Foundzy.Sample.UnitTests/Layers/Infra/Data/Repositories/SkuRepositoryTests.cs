﻿using FluentAssertions;
using Foundzy.Sample.Layers.Domain.SkuAggregate;
using Foundzy.Sample.Layers.Infra.Data.Repositories;

namespace Foundzy.Sample.UnitTests.Layers.Infra.Data.Repositories;

public class SkuRepositoryTests
{
    private readonly SkuRepository _repository = new();

    [Fact]
    public async Task Add_ShouldAddProperly()
    {
        // Arrange
        var sku = new Sku("Name");

        // Act
        await _repository.Add(sku);

        // Assert
        _repository.Skus.Should().HaveCount(1);
        _repository.Skus.Should().Contain(sku);
    }
}