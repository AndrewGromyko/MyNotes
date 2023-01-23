using AutoMapper;

namespace MyNotes.Domain.Interfaces.Services
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
