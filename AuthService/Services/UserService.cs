using AuthService.DTO;
using AuthService.Models;
using AuthService.Repositories;

namespace AuthService.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateUserRequestDTO request)
        {
            var userExists = await _repository.GetByEmailAsync(request.Email);

            if (userExists != null)
            {
                throw new ArgumentException("E-mail já está em uso", nameof(request.Email));
            }

            var user = new User
            {
                FirstName = request.FirstName,
                Email = request.Email,
                Password = Hash(request.Password),
                CreatedAt = DateTime.UtcNow,
                Role = request.Role,
                IsActive = true
            };

            await _repository.AddUserAsync(user);
        }

        private string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public void Update(int id, UpdateUserRequestDTO dto)
        {
            var user = _repository.GetUserById(id);

            user.FirstName = dto.FirstName;
            user.IsActive = dto.IsActive;

            _repository.UpdateUser(user);
        }

        public List<User> GetUsers()
        {
            return _repository.GetUsers();
        }

        public User GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            return user;
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            _repository.DeleteUser(id);
        }

        public void Desactivate(int id)
        {
            bool success = _repository.DesactivateUser(id);
            if (!success)
                throw new Exception("Usuário não encontrado");
        }
    }
}
