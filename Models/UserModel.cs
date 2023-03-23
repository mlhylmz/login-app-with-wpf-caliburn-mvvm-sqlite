using System.ComponentModel.DataAnnotations;

namespace LoginApp.Models;

public class UserModel
{
    [Key] public int Id { get; set; }
    public string NickName { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }

}