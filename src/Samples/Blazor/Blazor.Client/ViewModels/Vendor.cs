using EficazFramework.Extensions;
using EficazFramework.ViewModels.Services;

namespace Blazor.Client.ViewModels;

internal sealed class Vendor : EficazFramework.ViewModels.ViewModel<Shared.DTOs.VendorDto>
{
    public Vendor(HttpClient client) 
    {
        ViewModelAction += ActionsHandler;

        this.AddRestApi(client, options =>
        {
            options.UrlGet = "/api/vendors";
            options.UrlPost = "/api/vendors";
            options.UrlPut = "/api/vendors";
            options.UrlDelete = "/api/vendors";
            options.DeleteQueryFunc = (vendor) => vendor.Id.ToString() ; // DELETE : /api/vendors/vendorID
        })
            .AddSingledEdit()
            .WithNavigationByIndex();

        Repository.Validator = Shared.Validators.VendorValidator.Default() as EficazFramework.Validation.Fluent.Validator<Shared.DTOs.VendorDto>;
    }

    //PROPERTIES
    public SingleEdit<Shared.DTOs.VendorDto> Editor { get => this.GetSingleEdit(); }
    public IndexViewNavigator<Shared.DTOs.VendorDto> Navigator { get => this.GetIndexNavigator(); }


    /// <summary>
    /// Executed on Adding, Added, Editing, Saving, Saved, Deleting or Delete Entry.
    /// </summary>
    private void ActionsHandler(object? sender, EficazFramework.Events.CRUDEventArgs<Shared.DTOs.VendorDto> e)
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
