﻿using EficazFramework.Extensions;
using EficazFramework.ViewModels.Services;

namespace Blazor.Client.ViewModels;

internal sealed class Product : EficazFramework.ViewModels.ViewModel<Shared.DTOs.ProductDto>
{
    public Product(HttpClient client) 
    {
        ViewModelAction += ActionsHandler;

        this.AddRestApi(client, options =>
        {
            options.UrlGet = "/api/products";
            options.UrlPost = "/api/products";
            options.UrlPut = "/api/products";
            options.UrlDelete = "/api/products";
            options.DeleteQueryFunc = (product) => product.Id.ToString() ; // DELETE : /api/vendors/vendorID
        })
            .AddSingledEdit()
            .WithNavigationByIndex();

        Repository.Validator = Shared.Validators.VendorValidator.Default() as EficazFramework.Validation.Fluent.Validator<Shared.DTOs.ProductDto>;
    }

    //PROPERTIES
    public SingleEdit<Shared.DTOs.ProductDto> Editor { get => this.GetSingleEdit(); }
    public IndexViewNavigator<Shared.DTOs.ProductDto> Navigator { get => this.GetIndexNavigator(); }


    /// <summary>
    /// Executed on Adding, Added, Editing, Saving, Saved, Deleting or Delete Entry.
    /// </summary>
    private void ActionsHandler(object? sender, EficazFramework.Events.CRUDEventArgs<Shared.DTOs.ProductDto> e)
    {
        switch (e.Action)
        {
            case EficazFramework.Enums.CRUD.Action.EntryAdded:
                e.CurrentEntry.Id = System.Guid.NewGuid();
                break;

            default:
                break;
        }
    }


    //DISPOSE
    public override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelAction -= ActionsHandler;
    }

}