﻿using System.Linq.Expressions;
using CleanCodeArchitecture.Domain.Core.Entities;

namespace CleanCodeArchitecture.Domain.Core.Specifications;

public interface ISpecification<T> where T : BaseEntity?
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    Expression<Func<T, object>> GroupBy { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}