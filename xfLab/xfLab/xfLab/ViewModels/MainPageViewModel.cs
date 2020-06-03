using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfLab.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using xfLab.DTOs;
    using xfLab.Models.BaseAPIModels;
    using xfLab.Services;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Account { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public DelegateCommand LoginCommand { get; set; }
        public LoginService LoginService { get; }

        public MainPageViewModel(INavigationService navigationService,
            LoginService loginService)
        {
            this.navigationService = navigationService;
            LoginService = loginService;

            LoginCommand = new DelegateCommand(async () =>
            {
                Message = "";
                ManagerResult managerResult = await LoginService.PostAsync(new LoginQueryString()
                {
                    Account = Account,
                    Password = Password,
                });
                if(managerResult.Success==false)
                {
                    Message = managerResult.Message;
                }
                else
                {
                    Message = "登入驗證程序成功";
                }
            });

#if DEBUG
            Account = "admin";
            Password = "123";
#endif
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
