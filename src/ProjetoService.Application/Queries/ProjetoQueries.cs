using AutoMapper;
using ProjetoService.Application.Interfaces;
using ProjetoService.Application.Responses.ApiResponse;
using ProjetoService.Domain.Interfaces;

namespace ProjetoService.Application.Queries
{
    public class ProjetoQueries : ResponseHandler, IProjetoQueries
    {
        private readonly IProjetoRepository _repository;
        private readonly IMapper _mapper;

        public ProjetoQueries(IProjetoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> GetAll()
        {
            Response.Data = await _repository.GetAll();
            return Response;
        }
    }
}
