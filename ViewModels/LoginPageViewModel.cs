using Caliburn.Micro;
using LoginApp.Models;
using System.Diagnostics;
using System.Windows;

namespace LoginApp.ViewModels;

public class LoginPageViewModel : Screen
{


    // TANIMLAMA
    private readonly LoadingViewModel _loadingViewModel;
    private readonly UserPageViewModel _userPageViewModel;
    private readonly SignUpPageViewModel _signUpPageViewModel;
    private readonly UserDataContext _userDataContext;
    private readonly IWindowManager _windowManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly Encrypt _encrypt = new Encrypt();

    private string _boxNameText;
    private string _boxPasswordText;
    private int _userCheckID;

    // ATAMALAR CONSTRUCTOR
    public LoginPageViewModel(IWindowManager windowManager, UserPageViewModel userPageViewModel,
        IEventAggregator eventAggregator, LoadingViewModel loadingViewModel
        , UserDataContext userDataContext, SignUpPageViewModel signUpPageViewModel)
    {
        Trace.WriteLine("Login page ctor girdi");
        _windowManager = windowManager;
        _userPageViewModel = userPageViewModel;
        _eventAggregator = eventAggregator;
        _loadingViewModel = loadingViewModel;
        _userDataContext = userDataContext;
        _signUpPageViewModel = signUpPageViewModel;
    }

    // NOTIFY
    public string BoxNameText
    {
        get => _boxNameText;
        set
        {
            _boxNameText = value;

            NotifyOfPropertyChange(() => BoxNameText);
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


    // LOGIN BUTONA BASILDIĞINDA
    public async void LoginButton()
    {
        Trace.WriteLine(_encrypt.ComputeSha256Hash("test2"));
        // NULL VALIDATION
        if (string.IsNullOrEmpty(BoxNameText) || string.IsNullOrEmpty(BoxPasswordText))
        {
            MessageBox.Show("Please enter Name and Password !");
            return;
        }

        // USER CHECK
        _userCheckID = await _userDataContext.UserDatabaseChecker(_boxNameText, _encrypt.ComputeSha256Hash(_boxPasswordText));

        // Eğer kullanıcı varsa
        if (_userCheckID > 0)
        {
            // Loading işlemleri
            _loadingViewModel.UserExistChanger(_userCheckID);
            await _windowManager.ShowDialogAsync(_loadingViewModel);
            Trace.WriteLine(_userCheckID);

            // Event ile userID gönderme
            await _eventAggregator.PublishOnUIThreadAsync(new UserLoggedInEvent
            { ID = _userCheckID });

            await TryCloseAsync();
        }
        // Kullanıcı yoksa
        else
        {
            await _windowManager.ShowDialogAsync(_loadingViewModel);
            MessageBox.Show("Wrong Name and Password");
        }
    }

    // SIGN UP BUTONA BASILDIĞINDA
    public async void SignUpButton()
    {
        await _windowManager.ShowDialogAsync(_signUpPageViewModel);
    }
}