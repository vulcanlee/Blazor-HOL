using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xfLab.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using xfLab.Models;
    using xfLab.Models.BaseAPIModels;
    using xfLab.Services;

    public class PersonPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public ObservableCollection<PersonData> People { get; set; } = new ObservableCollection<PersonData>();
        public PersonService PersonService { get; }
        ManagerResult managerResult;
        public PersonPageViewModel(INavigationService navigationService,
            PersonService personService)
        {
            this.navigationService = navigationService;
            PersonService = personService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            managerResult = await PersonService.GetAsync();
            if (managerResult.Success == true)
            {
                People.Clear();
                foreach (var item in PersonService.Items)
                {
                    People.Add(item);
                }
            }
        }

        public  void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
