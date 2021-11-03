using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WanderersDiary.Client.Navigation
{
    public static class NavigationExtensions
    {
        public static async Task<INavigationResult> TryNavigateAsync(this INavigationService navigation, 
            string path, 
            NavigationParameters parameters, 
            bool? IsModal)
        {
            INavigationResult result = await navigation.NavigateAsync(path, parameters, IsModal);

            if(!result.Success)
            {
                NavigationParameters errorParameters = new NavigationParameters();
                errorParameters.Add(NavigationParametersNames.Common.ErrorPageParameters.Error, result.Exception.Message);

                await navigation.NavigateAsync(NavigationNames.Common.Error, errorParameters, true);
            }

            return result;
        }
    }
}
