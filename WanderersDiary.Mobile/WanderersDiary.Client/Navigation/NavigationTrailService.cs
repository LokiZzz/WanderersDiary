using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Navigation
{
    public interface INavigationTrailService
    {
        NavigationTrail GetOnStartTrail();
    }

    public class NavigationTrailService : INavigationTrailService
    {
        public NavigationTrail GetOnStartTrail()
        {
            return new NavigationTrail { Path = NavigationNames.Auth.SignIn };
        }
    }

    public class NavigationTrail
    {
        public string Path { get; set; }

        public NavigationParameters Parameters { get; set; }

        public bool? IsModal { get; set; }
    }
}
