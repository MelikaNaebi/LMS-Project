using LMS.Data;
using LMS.Models;

public class AuthService
{
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }

    public User Authenticate(string email, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
    }


    //private bool VerifyPassword(string hashedPassword, string inputPassword)
    //{
    //    return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
    //}
}
