using LocalEventsUI.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalEventsUI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<LocalEvent> Events { get; } = new ObservableCollection<LocalEvent>();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        private async Task LoadEvents()
        {
            var event01 = new LocalEvent
            {
                Title = "5 Kilometer Downtown Run",
                Local = "Pleasant Park",
                Icon = "event01.png"
            };

            var event02 = new LocalEvent
            {
                Title = "Granite Cooking Class",
                Local = "Food Court Avenue",
                Icon = "event01.png"
            };

            Events.Add(event01);
            Events.Add(event02);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {

            var navMode = parameters.GetNavigationMode();

            if (navMode != NavigationMode.Back)
                LoadEvents().ConfigureAwait(false);

            base.OnNavigatedTo(parameters);
        }
    }
}
