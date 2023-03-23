using Caliburn.Micro;
using System.Threading.Tasks;

namespace LoginApp.ViewModels;

public class LoadingViewModel : Screen
{
    private int _userExist;
    protected override async void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);

        // Wait for 2 seconds
        await Task.Delay(2000);

        if (_userExist > 0)// Eğer kullanıcı bulunduysa
        {
            // Show user page
            var userPageViewModel = IoC.Get<UserPageViewModel>();
            await IoC.Get<IWindowManager>().ShowWindowAsync(userPageViewModel);

            // Close loading screen
            await TryCloseAsync();
        }
        else// Kullanıcı yoksa
        {
            await TryCloseAsync();
        }

    }

    public void UserExistChanger(int userExists)
    {
        _userExist = userExists;
    }
}