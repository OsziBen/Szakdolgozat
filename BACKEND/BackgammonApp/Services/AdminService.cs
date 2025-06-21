using BackgammonApp.Interfaces.Repositories;
using BackgammonApp.Interfaces.Services;

namespace BackgammonApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public string GetAdminMessage()
        {
            return _adminRepository.FetchAdminMessage();
        }
    }
}
