using ProtoDefinitions;

namespace Application.Infrastructure.Services.ProviderService
{
    public class GrpcProviderService
    {
        private readonly MoviesApi.MoviesApiClient _moviesApiClient;
        
        public GrpcProviderService(MoviesApi.MoviesApiClient moviesApiClient)
        {
            _moviesApiClient = moviesApiClient;
        }
    }
}