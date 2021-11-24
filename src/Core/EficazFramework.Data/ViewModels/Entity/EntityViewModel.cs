
namespace EficazFrameworkCore.ViewModels
{
    public class EntityViewModel<T> : ViewModelBase<T> where T : Entity.EntityBase
    {
        public EntityViewModel() : base()
        {
            this.Repository = new Repositories.EntityRepository<T>();
        }
    }
}