using AutoMapper;

namespace BulgarianCreators.Web.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression config);
    }
}
