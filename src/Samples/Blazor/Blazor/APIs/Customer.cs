using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Validators;

namespace Blazor.APIs;

internal static class Customer
{
    internal static WebApplication MapCustomers(this WebApplication app)
    {
        var customers = app.MapGroup("/api/customers");
        customers.MapGet("", () => TypedResults.Ok(GetCustomers()));
        customers.MapGet("/{search}", (string search) => TypedResults.Ok(SearchCustomers(search)));
        customers.MapPost("", ([FromBody] CustomerDto customer) => AddCustomer(customer));
        customers.MapPut("", ([FromBody] CustomerDto customer) => UpdateCustomer(customer));
        customers.MapDelete("/{customerID}", (string customerID) => DeleteCustomer(Guid.Parse(customerID)));
        customers.AllowAnonymous();

        return app;
    }

    //TODO: Implement Unit of Work, Repositories, etc

    private static List<Entities.Customer>? _cacheCustomers;
    private static List<Entities.Customer> GetCustomers()
    {
        var addressFaker = new Bogus.Faker<Entities.Address>();
        addressFaker
            .RuleFor(c => c.Street, r => r.Address.StreetAddress(true))
            .RuleFor(c => c.ZipCode, r => r.Address.ZipCode())
            .RuleFor(c => c.City, r => r.Address.City())
            .RuleFor(c => c.State, r => r.Address.State());

        var faker = new Bogus.Faker<Entities.Customer>();
        faker
            .RuleFor(c => c.Id, r => r.Random.Uuid())
            .RuleFor(c => c.Name, r => r.Person.FullName)
            .RuleFor(c => c.Address, addressFaker.Generate());

        _cacheCustomers ??= faker.Generate(125);
        return _cacheCustomers!;
    }

    private static List<Entities.Customer> SearchCustomers(string search) =>
        GetCustomers().Where(v => v.Name!.Contains(search, StringComparison.InvariantCultureIgnoreCase) || v.Address!.City!.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToList();

    private static IResult AddCustomer(CustomerDto customer)
    {
        if (customer == null)
            return TypedResults.UnprocessableEntity();

        try
        {
            // PK check

            if (GetCustomers().Any(v => v.Id == customer.Id))   
                return TypedResults.UnprocessableEntity(new[] { $"A customer with ID {customer.Id} already exists." } );

            // Validation
            var result = (customer as Shared.Interfaces.IValidatable).Validate();
            if (result?.Any() ?? false)
                return TypedResults.UnprocessableEntity(result);

            // Mapper work
            Entities.Customer newCustomer = new()
            {
                Id = customer.Id!.Value,
                Name = customer.Name,
                Address = new()
                {
                    Street = customer.Address.Street,
                    ZipCode = customer.Address.ZipCode,
                    City = customer.Address.City,
                    State = customer.Address.State
                }
            };

            // Insert
            _cacheCustomers!.Add(newCustomer);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString()); 
        }

        return TypedResults.Created($"/api/customers/{customer.Id}", customer);
    }

    private static IResult UpdateCustomer(CustomerDto customer)
    {
        if (customer == null)
            return TypedResults.UnprocessableEntity();

        try
        {
            // PK check
            var vendorEntity = GetCustomers().FirstOrDefault(v => v.Id == customer.Id);
            if (vendorEntity is null)
                return TypedResults.UnprocessableEntity(new[] { $"Any customer were found with ID {customer.Id}." });

            // Validation
            var result = (customer as Shared.Interfaces.IValidatable).Validate();
            if (result?.Any() ?? false)
                return TypedResults.UnprocessableEntity(result);

            // Mapper work
            vendorEntity.Name = customer.Name;
            vendorEntity.Address.Street = customer.Address.Street;
            vendorEntity.Address.ZipCode = customer.Address.ZipCode;
            vendorEntity.Address.City = customer.Address.City;
            vendorEntity.Address.State = customer.Address.State;
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString());
        }

        return TypedResults.Ok(customer);
    }

    private static IResult DeleteCustomer(Guid customerId)
    {
        try
        {
            // PK check
            var customerEntity = GetCustomers().FirstOrDefault(v => v.Id == customerId);
            if (customerEntity is null)
                return TypedResults.UnprocessableEntity(new[] { $"Any customer were found with ID {customerId}." });


            // Mapper work
            _ = (_cacheCustomers?.Remove(customerEntity));
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString());
        }

        return TypedResults.Ok(customerId);
    }

}
