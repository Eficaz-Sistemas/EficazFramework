using EficazFramework.Extensions;
using EficazFramework.ViewModels.Services;

namespace Blazor.Client.ViewModels;

internal sealed class Tag : EficazFramework.ViewModels.ViewModel<Shared.DTOs.TagDto>
{
    public Tag(HttpClient client) 
    {
        ViewModelAction += ActionsHandler;

        this.AddRestApi(client, options =>
        {
            options.GetOptions = new()
            {
                UrlExpr = () => "/api/tags",
                AttachFilterExpressionOnBodyAtGet = false
            };
            options.UrlPost = (entry) => "/api/tags";
            options.UrlPut = (entry) => "/api/tags";
            options.UrlDelete = (entry) => "/api/tags";
        })
            .AddSingledEdit()
            .WithNavigationByIndex();

        Repository.Validator = Shared.Validators.VendorValidator.Default() as EficazFramework.Validation.Fluent.Validator<Shared.DTOs.TagDto>;
    }

    //PROPERTIES
    public SingleEdit<Shared.DTOs.TagDto> Editor { get => this.GetSingleEdit(); }
    public IndexViewNavigator<Shared.DTOs.TagDto> Navigator { get => this.GetIndexNavigator(); }


    /// <summary>
    /// Executed on Adding, Added, Editing, Saving, Saved, Deleting or Delete Entry.
    /// </summary>
    private void ActionsHandler(object? sender, EficazFramework.Events.CRUDEventArgs<Shared.DTOs.TagDto> e)
    {
        switch (e.Action)
        {
            case EficazFramework.Enums.CRUD.Action.EntryAdded:
                e.CurrentEntry.Id = string.Empty;
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
