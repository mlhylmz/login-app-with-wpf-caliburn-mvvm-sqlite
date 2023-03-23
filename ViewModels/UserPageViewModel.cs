using Caliburn.Micro;
using LoginApp.Models;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace LoginApp.ViewModels;

public class UserPageViewModel : Screen, IHandle<UserLoggedInEvent>
{
    // TANIMLAMA
    private readonly IEventAggregator _eventAggregator;
    private readonly UserDataContext _userDataContext;
    private readonly IWindowManager _windowManager;
    private int _age;
    public int _id;
    private LoginPageViewModel _loginPageViewModel;

    private string _nickName;
    private string _surName;
    private UserModel _userModel;
    private string _userName;


    // CONSTRUCTOR
    public UserPageViewModel(IEventAggregator eventAggregator, IWindowManager windowManager,
        UserDataContext userDataContext)
    {
        _userDataContext = userDataContext;
        _windowManager = windowManager;
        _eventAggregator = eventAggregator;
        _eventAggregator.Subscribe(this);
        Items = new ObservableCollection<UserModel>();
    }

    public ObservableCollection<UserModel> Items { get; set; }

    //NOTIFY
    public int ID
    {
        get => _id;
        set
        {
            _id = value;
            NotifyOfPropertyChange(() => ID);
        }
    }

    public string NickName
    {
        get => _nickName;
        set
        {
            _nickName = value;
            NotifyOfPropertyChange(() => NickName);
        }
    }

    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            NotifyOfPropertyChange(() => UserName);
        }
    }

    public string SurName
    {
        get => _surName;
        set
        {
            _surName = value;
            NotifyOfPropertyChange(() => SurName);
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            NotifyOfPropertyChange(() => Age);
        }
    }

    public async Task HandleAsync(UserLoggedInEvent message, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ID = message.ID;
        _userModel = await _userDataContext.UserFinder(_id);

        // Viewde tanımmlanan listView e veri girme
        Items.Add(new UserModel
        {
            NickName = _userModel.NickName,
            UserName = _userModel.UserName,
            SurName = _userModel.SurName,
            Age = _userModel.Age
        });
    }


    // Login'e geri döner. 
    public async void UserLogoutButton()
    {
        _loginPageViewModel = IoC.Get<LoginPageViewModel>();
        _loginPageViewModel.BoxPasswordText = string.Empty;
        _loginPageViewModel.BoxNameText = string.Empty;
        Items.Clear();
        await IoC.Get<IWindowManager>().ShowWindowAsync(_loginPageViewModel);
        await TryCloseAsync();

    }
}