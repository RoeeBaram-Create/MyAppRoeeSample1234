using AutoMapper;
using FunProject.Domain.Mapper;

namespace FunProject.Infrastructure.Mapper
{
    public class MapperAdapter : IMapperAdapter
    {
        private readonly IMapper _mapper;

        public MapperAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
