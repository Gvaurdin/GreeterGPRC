using GreeterServiceApp;
using Grpc.Core;

namespace GreeterServiceApp.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Здарова " + request.Name
            });
        }
        public override Task<RegisterReply> RegisterUser(RegisterRequest request, ServerCallContext context)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            return Task.FromResult(new RegisterReply
            {
                Message = $"Поздравляем {request.FirstName}, вы зарегистрированы!",
                User = user
            });
        }
    }
}
