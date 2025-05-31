using BackgammonApp.Data;
using BackgammonApp.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackgammonApp.Repositories
{
    /*
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChangesAsyc();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await SaveChangesAsyc();

                return true;
            }

            return false;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> SaveChangesAsyc()
        {
            return _context.SaveChangesAsync();
        }
    }
    */
}
