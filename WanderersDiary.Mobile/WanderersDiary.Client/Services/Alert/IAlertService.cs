using System;
using System.Collections.Generic;
using System.Text;

namespace WanderersDiary.Client.Services.Alert
{
    public interface IAlertService
    {
        void ShortAlert(string message);
        void LongAlert(string message);
    }
}
