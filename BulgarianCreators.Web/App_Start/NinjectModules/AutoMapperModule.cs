using BulgarianCreators.Web.Mapping;
using Ninject.Modules;

namespace BulgarianCreators.Web.App_Start.NinjectModules
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMapperAdapter>().To<MapperAdapter>();
        }
    }
}