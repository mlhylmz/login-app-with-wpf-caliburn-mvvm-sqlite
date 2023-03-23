using Caliburn.Micro;
using LoginApp.Models;
using LoginApp.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace LoginApp;

public class Bootstrapper : BootstrapperBase
{
    private readonly SimpleContainer _container = new();

    public Bootstrapper()
    {
        Initialize();
    }

    protected override void Configure()
    {
        // Singleton bir kere çağırılır, Singleton her istekte çağırılır.

        // View - ViewModel - Class    Container İşlemleri
        _container.Singleton<LoginPageViewModel>();
        _container.Singleton<UserPageViewModel>();
        _container.Singleton<LoadingViewModel>();
        _container.PerRequest<SignUpPageViewModel>();

        _container.Singleton<ShellViewModel>();
        _container.Singleton<UserDataContext>();

        // Interface  Container İşlemleri
        _container.Singleton<IWindowManager, WindowManager>();
        _container.Singleton<IEventAggregator, EventAggregator>();

        var facade = new DatabaseFacade(new UserDataContext());
        facade.EnsureCreated();

    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        base.OnStartup(sender, e);
        var windowManager = new WindowManager();
        windowManager.ShowWindowAsync(_container.GetInstance<LoginPageViewModel>());
    }

    protected override object GetInstance(Type service, string key)
    {
        return _container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return _container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        _container.BuildUp(instance);
    }
}