using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Client.Navigation
{
    public static class NavigationExtensions
    {
        public static async Task<INavigationResult> TryNavigateAsync(this INavigationService navigation, NavigationTrail trail)
        {
            return await navigation.TryNavigateAsync(trail.Path, trail.Parameters, trail.IsModal);
        }

        public static async Task<INavigationResult> TryNavigateAsync(this INavigationService navigation, 
            string path, 
            NavigationParameters parameters = null, 
            bool? isModal = null)
        {
            INavigationResult result = await navigation.NavigateAsync(path, parameters, isModal);

            if(!result.Success)
            {
                NavigationParameters errorParameters = new NavigationParameters();
                errorParameters.Add(NavigationParametersNames.Common.ErrorPageParameters.Error, result.Exception.Message);

                await navigation.NavigateAsync(NavigationNames.Common.Error, errorParameters, true);
            }

            return result;
        }

        public static string ToAbsolutePath(this string path) => $"/{path}";
    }
}
