using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LoginApp.Models;

public class UserDataContext : DbContext
{
    //UserModel den Users oluşturma
    public DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Database oluşturma. Varsa oluşturmaz.
        optionsBuilder.UseSqlite("Data Source = DataFile.db");
    }

    // Name ve Pass a göre user db de var mı?
    public async Task<int> UserDatabaseChecker(string name, string password)
    {
        var _user = await Users.FirstOrDefaultAsync(UserModel =>
            UserModel.NickName == name && UserModel.Password == password);
        var _userID = 0;
        if (_user != null)
            _userID = _user.Id;

        else
            _userID = 0;

        return _userID;
    }

    // ID'ye göre User geri döndürme
    public async Task<UserModel> UserFinder(int id)
    {
        var _user = await Users.FirstOrDefaultAsync(UserModel => UserModel.Id == id);

        return _user;
    }

    // Kullanıcı Kayıt
    public async Task<bool> AddUser(UserModel user)
    {
        try
        {
            Users.Add(user);
            await SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Trace.WriteLine(e);
            return false;
        }
    }
}