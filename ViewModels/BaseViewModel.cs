using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssayMe.Core.Localization;
using AssayMe.Core.Models.Enums;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AssayMe.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel(IMvxNavigationService navigation)
        {
            NavigationService = navigation;

            NewScanCommand = new MvxAsyncCommand(DoNewScanCommand);
            GoHomeCommand = new MvxAsyncCommand(DoHomeCommand);
            UserCommand = new MvxAsyncCommand(DoUserCommand);
            MenuCommand = new MvxAsyncCommand(DoMenuCommand);
            CloseCommand = new MvxAsyncCommand(DoCloseCommand);

            UserName = "Harry Flip";
        }

        #region commands
        public IMvxAsyncCommand NewScanCommand { get; private set; }
        public IMvxAsyncCommand GoHomeCommand { get; private set; }
        public IMvxAsyncCommand UserCommand { get; private set; }
        public IMvxAsyncCommand MenuCommand { get; private set; }
        public IMvxAsyncCommand CloseCommand { get; private set; }
        public IMvxAsyncCommand HomeCommand { get; private set; }
        #endregion

        #region public properties
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        /// <summary>
        /// Gets the internationalized string at the given <paramref name="index"/>, which is the key of the resource.
        /// </summary>
        /// <param name="index">Index key of the string from the resources of internationalized strings.</param>
        public string this[string index] => AppResources.ResourceManager.GetString(index);
        #endregion

        #region virtuals
        public virtual MenuStyle Menu => MenuStyle.Menu;
        #endregion

        #region private methods
        private async Task DoNewScanCommand()
        {
        }
        protected virtual async Task DoHomeCommand()
        {
            await Navigate<HomeViewModel>(NavigationType.ClearBackstack);
        }
        private async Task DoUserCommand()
        {
            
        }
        private async Task DoMenuCommand()
        {
            
        }
        protected virtual async Task DoCloseCommand()
        {
            await NavigationService.Close(this);
        }
        #endregion

        #region navigation
        public virtual async Task Navigate<TViewModel>(NavigationType type = NavigationType.None)
           where TViewModel : IMvxViewModel
        {
            IMvxBundle presentationBundle = null;
            presentationBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationMode", type.ToString() } });
            await NavigationService.Navigate<TViewModel>(presentationBundle: presentationBundle);
        }
        public Task Navigate<TViewModel, TParameter>(TParameter param, NavigationType type = NavigationType.None)
            where TViewModel : IMvxViewModel<TParameter>
            where TParameter : notnull
        {
            IMvxBundle presentationBundle = null;
            presentationBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationMode", type.ToString() } });
            return NavigationService.Navigate<TViewModel, TParameter>(param: param, presentationBundle: presentationBundle);
        }
        public Task<TResultModel> Navigate<TViewModel, TParameter, TResultModel>(TParameter param, NavigationType type = NavigationType.None)
            where TViewModel : IMvxViewModel<TParameter, TResultModel>
            where TParameter : notnull
            where TResultModel : notnull
        {
            IMvxBundle presentationBundle = null;
            presentationBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationMode", type.ToString() } });
            return NavigationService.Navigate<TViewModel, TParameter, TResultModel>(param: param, presentationBundle: presentationBundle);
        }
        #endregion

        #region services
        protected IMvxNavigationService NavigationService { get; private set; }
        #endregion
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
        where TParameter : notnull
        {
        protected BaseViewModel(IMvxNavigationService navigation) : base(navigation)
        {
        }

        public abstract void Prepare(TParameter parameter);
    }
}
