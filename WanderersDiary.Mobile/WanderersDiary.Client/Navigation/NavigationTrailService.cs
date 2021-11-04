using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Navigation
{
    public interface INavigationTrailService
    {
        NvaigationTrail GetOnStartTrail();
    }

    public class NavigationTrailService : INavigationTrailService
    {
        public NvaigationTrail GetOnStartTrail()
        {
            return new NvaigationTrail { Path = NavigationNames.Auth.SignIn };
        }
    }

    public class NvaigationTrail
    {
        public string Path { get; set; }

        public NavigationParameters Parameters { get; set; }

        public bool? IsModal { get; set; }
    }
}
