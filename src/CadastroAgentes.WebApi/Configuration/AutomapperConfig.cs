using AutoMapper;
using CadastroAgentes.Business.Models;
using CadastroAgentes.WebApi.ViewModels;

namespace CadastroAgentes.WebApi.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Status, StatusViewModel>().ReverseMap();
        }
    }
}
