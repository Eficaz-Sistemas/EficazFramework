using EficazFramework.Extensions;
using EficazFramework.ViewModels.Services;

namespace Blazor.Client.ViewModels;

internal sealed class Customer : EficazFramework.ViewModels.ViewModel<Shared.DTOs.CustomerDto>
{
    public Customer(HttpClient client) 
    {
        ViewModelAction += ActionsHandler;

        this.AddRestApi(client, options =>
        {
            options.GetOptions = new()
            {
                UrlExpr = () => "/api/customers",
                AttachFilterExpressionOnBodyAtGet = false
            };
            options.UrlPost = (entry) => "/api/customers";
            options.UrlPut = (entry) => "/api/customers";
            options.UrlDelete = (entry) => $"/api/customers/{entry.Id}";
        })
            .AddSingledEdit()
            .WithNavigationByIndex();

        Repository.Validator = Shared.Validators.CustomerValidator.Default() as EficazFramework.Validation.Fluent.Validator<Shared.DTOs.CustomerDto>;
    }

    //PROPERTIES
    public SingleEdit<Shared.DTOs.CustomerDto> Editor { get => this.GetSingleEdit(); }
    public IndexViewNavigator<Shared.DTOs.CustomerDto> Navigator { get => this.GetIndexNavigator(); }


    /// <summary>
    /// Executed on Adding, Added, Editing, Saving, Saved, Deleting or Delete Entry.
    /// </summary>
    private void ActionsHandler(object? sender, EficazFramework.Events.CRUDEventArgs<Shared.DTOs.CustomerDto> e)
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
