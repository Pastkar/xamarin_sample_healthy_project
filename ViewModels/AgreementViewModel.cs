using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssayMe.Core.Models;
using AssayMe.Core.Models.Enums;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Essentials;

namespace AssayMe.Core.ViewModels
{
    public class AgreementViewModel : BaseViewModel
    {
        public AgreementViewModel(IMvxNavigationService navigationService)
            : base(navigationService)
        {
            ConfirmCommand = new MvxAsyncCommand(DoConfirmCommand);
            GoEULACommand = new MvxAsyncCommand(DoGoEULACommand);
            GoPrivacyPolicyCommand = new MvxAsyncCommand(DoGoPrivacyPolicyCommand);
        }

        #region commands
        public IMvxCommand ConfirmCommand { get; private set; }
        public IMvxCommand GoEULACommand { get; private set; }
        public IMvxCommand GoPrivacyPolicyCommand { get; private set; }
        #endregion

        #region public properties
        private bool agreementChecked;
        public bool AgreementChecked
        {
            get => agreementChecked;
            set => SetProperty(ref agreementChecked, value);
        }
        public string PrivacyPolicyText => this["PrivacyPolicyText"];
        public List<Tuple<string, PrivacyPolicyType>> UnderLineTexts => new List<Tuple<string, PrivacyPolicyType>>()
        {
            new Tuple<string, PrivacyPolicyType>(this["EULA"], PrivacyPolicyType.EULA),
            new Tuple<string, PrivacyPolicyType>(this["PrivacyPolicy"], PrivacyPolicyType.PP)
        };
        #endregion

        #region private methods
        private async Task DoConfirmCommand()
        {
            if(AgreementChecked)
                await NavigationService.Navigate<SignInViewModel>();
        }
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
