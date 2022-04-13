using AssayMe.Core.Localization;
using AssayMe.Core.Models;
using AssayMe.Core.Models.Enums;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AssayMe.Core.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            GoEULACommand = new MvxAsyncCommand(DoGoEULACommand);
            GoPrivacyPolicyCommand = new MvxAsyncCommand(DoGoPrivacyPolicyCommand);
        }

        #region commands
        public IMvxCommand GoEULACommand { get; private set; }
        public IMvxCommand GoPrivacyPolicyCommand { get; private set; }
        #endregion

        #region overrides
        public override MenuStyle Menu => MenuStyle.Back;
        #endregion

        #region public properties
        public string PrivacyPolicyText => this["AboutUs"];
        public List<Tuple<string, PrivacyPolicyType>> UnderLineTexts => new List<Tuple<string, PrivacyPolicyType>>()
        {
            new Tuple<string, PrivacyPolicyType>(this["EULA"], PrivacyPolicyType.EULA),
            new Tuple<string, PrivacyPolicyType>(this["PrivacyPolicy"], PrivacyPolicyType.PP)
        };
        #endregion

        #region private methods
        private async Task DoGoEULACommand()
        {
            try
            {
                await Browser.OpenAsync(StringConstants.AppSite, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
        private async Task DoGoPrivacyPolicyCommand()
        {
            try
            {
                await Browser.OpenAsync(StringConstants.AppSite, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
        #endregion
    }
}
