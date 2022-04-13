using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AssayMe.Core.Models.Enums;
using AssayMe.Core.ViewModels;
using AssayMe.Droid.Activity;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;

namespace AssayMe.Droid.Views
{
    public abstract class BaseFragment : MvxFragment 
    {
        public MvxActivity ParentActivity => (MvxActivity)Activity;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

                var view = this.BindingInflate(FragmentId, null);
            _menu = view.FindViewById<ImageView>(Resource.Id.iv_menuLogo);
            return view;
        }

        protected abstract int FragmentId { get; }
        protected ImageView _menu;
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel :  BaseViewModel
    {
        #region overrides
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            if(ViewModel.Menu == MenuStyle.Menu )
            {
                _menu?.SetImageResource(Resource.Drawable.ic_menu_selector);
            }
            if (ViewModel.Menu == MenuStyle.Back)
            {
                _menu?.SetImageResource(Resource.Drawable.ic_last_page);
            }
        }
        public override void OnResume()
        {
            base.OnResume();
            if (_menu != null)
                _menu.Click += Menu_Click;
        }
        public override void OnPause()
        {
            base.OnPause();
            if (_menu != null)
                _menu.Click -= Menu_Click;

        }
        #endregion

        #region private methods
        private void Menu_Click(object sender, EventArgs e)
        {
            if (ViewModel.Menu == MenuStyle.Menu)
            {
                ((MainActivity)Activity).Drawer.OpenDrawer((int)GravityFlags.Left);
            }
            if (ViewModel.Menu == MenuStyle.Back)
            {
                ViewModel.CloseCommand.Execute();
            }
        }
        #endregion

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}