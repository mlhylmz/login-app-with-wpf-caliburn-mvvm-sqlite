using Caliburn.Micro;
using LoginApp.Models;
using System.Windows;

namespace LoginApp.ViewModels;

public class SignUpPageViewModel : Screen
{
    // Tanımlama
    private readonly UserDataContext _userDataContext;
    private int _boxAgeText;
    private string _boxNameText;
    private Encrypt _encrypt = new Encrypt();

    // Kayıt Parametreleri
    private string _boxNicknameText;
    private string _boxPasswordText;
    private string _boxSurNameText;
    private UserModel _userModel = new UserModel();

    public SignUpPageViewModel(UserDataContext userDataContext)
    {
        _userDataContext = userDataContext;
    }

    // NOTIFY
    public string BoxNickNameText
    {
        get => _boxNicknameText;
        set
        {
            _boxNicknameText = value;
            NotifyOfPropertyChange(() => BoxNickNameText);
        }
    }

    public string BoxPasswordText
    {
        get => _boxPasswordText;
        set
        {
            _boxPasswordText = value;
            NotifyOfPropertyChange(() => BoxPasswordText);
        }
    }

    public string BoxNameText
    {
        get => _boxNameText;
        set
        {
            _boxNameText = value;
            NotifyOfPropertyChange(() => BoxNameText);
        }
    }

    public string BoxSurNameText
    {
        get => _boxSurNameText;
        set
        {
            _boxSurNameText = value;
            NotifyOfPropertyChange(() => BoxSurNameText);
        }
    }

    public int BoxAgeText
    {
        get => _boxAgeText;
        set
        {
            _boxAgeText = value;
            NotifyOfPropertyChange(() => BoxAgeText);
        }
    }

    public async void CancelButton()
    {
        _boxNicknameText = "";
        _boxNameText = "";
        _boxPasswordText = "";
        _boxSurNameText = "";
        _boxAgeText = 0;
        await TryCloseAsync();
    }

    public async void SignUpButton()
    {
        var isSucces = false;
        if (!string.IsNullOrWhiteSpace(_boxNicknameText) && !string.IsNullOrWhiteSpace(_boxPasswordText))
        {
            _userModel.NickName = _boxNicknameText;
            _userModel.UserName = _boxNameText;
            _userModel.SurName = _boxSurNameText;
            _userModel.Age = _boxAgeText;
            _userModel.Password = _encrypt.ComputeSha256Hash(_boxPasswordText);

            isSucces = await _userDataContext.AddUser(_userModel);

            if (isSucces)
            {
                _boxNicknameText = "";
                _boxNameText = "";
                _boxPasswordText = "";
                _boxSurNameText = "";
                _boxAgeText = 0;
                await TryCloseAsync();
            }
                
            else
                MessageBox.Show("Database failed. Please fill in all required fields.");
        }
        else
        {
            MessageBox.Show("Please fill in all required fields.");
        }

    }
}