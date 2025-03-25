using TicketHub.Api.Data;

namespace TicketHub.Api.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //TODO: AuthenticateAsync and GenerateToken
    }
}
