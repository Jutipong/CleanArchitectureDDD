﻿namespace Application.Customer.Queries.Search;
public record SearchCustomerQuery(Guid id, string Name) : IQuery<CustomerEntities>;