using LocalEventsUI.Models;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LocalEventsUI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<LocalEvent> Events { get; } = new ObservableCollection<LocalEvent>();
        public ObservableCollection<Menu> Menus { get; } = new ObservableCollection<Menu>();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        private async Task LoadEvents()
        {
            Events.Add(CreateEvent("Granite Cooking Class", "Food Court Avenue", "event01.png"));
            Events.Add(CreateEvent("5 Kilometer Downtown Run", "Pleasant Park", "event02.png"));
            Events.Add(CreateEvent("Granite Cooking Class", "Food Court Avenue", "event01.png"));
            Events.Add(CreateEvent("5 Kilometer Downtown Run", "Pleasant Park", "event02.png"));
        }

        private LocalEvent CreateEvent(string title, string local, string icon)
        {
            return new LocalEvent
            {
                Title = title,
                Local = local,
                Icon = icon
            };

        }

        private async Task LoadMenus()
        {
            Menus.Add(CreateMenu("ALL", "baseline_search_white_18.png"));
            Menus.Add(CreateMenu("Music", "baseline_music_note_white_18.png"));
            Menus.Add(CreateMenu("Meetup", "baseline_location_on_white_18.png"));
            Menus.Add(CreateMenu("Show", "baseline_emoji_people_white_18.png"));
            Menus.Add(CreateMenu("Sports", "baseline_sports_football_white_18.png"));
            Menus.Add(CreateMenu("TV", "baseline_tv_white_18.png"));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {

            var navMode = parameters.GetNavigationMode();

            if (navMode != NavigationMode.Back)
            {
                LoadEvents().ConfigureAwait(false);
                LoadMenus().ConfigureAwait(false);
            }

            base.OnNavigatedTo(parameters);
        }

        private Menu CreateMenu(string name, string icon)
        {
            return new Menu { Name = name, Icon = icon };
        }
    }
}
