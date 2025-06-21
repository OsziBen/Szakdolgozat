using BackgammonApp.Interfaces.Repositories;

namespace BackgammonApp.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public string FetchAdminMessage()
        {
            return "Admin only";
        }
    }
}
