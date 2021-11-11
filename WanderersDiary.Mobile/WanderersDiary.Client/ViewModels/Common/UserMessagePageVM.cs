using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WanderersDiary.Client.Navigation;

namespace WanderersDiary.Client.ViewModels.Common
{
    public class UserMessagePageVM : ViewModelBase
    {
        public UserMessagePageVM(INavigationService navigationService) : base(navigationService) 
        {
            NavigateAfterCommand = new DelegateCommand(async () => await ExecuteNavigateAfter());
        }

        private async Task ExecuteNavigateAfter()
        {
            await NavigationService.TryNavigateAsync(_trail);
        }

        public DelegateCommand NavigateAfterCommand { get; set; }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            MessageTitle = parameters.GetValue<string>(
                NavigationParametersNames.Common.UserMessagePage.Title);
            Message = parameters.GetValue<string>(
                NavigationParametersNames.Common.UserMessagePage.Message);
            _trail = parameters.GetValue<NavigationTrail>(
                NavigationParametersNames.Common.UserMessagePage.TrailAfter);
        }

        private NavigationTrail _trail;

        private string _messageTitle;
        public string MessageTitle
        {
            get { return _messageTitle; }
            set { SetProperty(ref _messageTitle, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
