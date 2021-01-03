using Core.Domain.Common;
using FoodApp.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Tests.FoodApp.TestInfrastructure
{
    public class CreateRepositoryMock
    {
        public static Mock<IRepository<T>> CreateRepository<T>(T findEntity = null, ICollection<T> listEntities = null) where T : BaseEntity
        {
            listEntities ??= Array.Empty<T>();

            var repository = new Mock<IRepository<T>>();
            repository
                .Setup(m => m.FindAsync(It.IsAny<Expression<Func<T, bool>>>()))
                .ReturnsAsync(findEntity);
            repository
                .Setup(m => m.ToListAsync(It.IsAny<Expression<Func<T, bool>>>()))
                .ReturnsAsync(listEntities.ToImmutableList());
            repository
               .Setup(m => m.ToListAsync(null))
               .ReturnsAsync(listEntities.ToImmutableList());

            return repository;
        }
    }
}
