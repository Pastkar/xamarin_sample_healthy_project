using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AssayMe.Core.ViewModels;
using AssayMe.Droid.Helpers;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AssayMe.Droid.Views
{
    [MvxFragmentPresentation(typeof(AndroidActivityViewModel), Resource.Id.content_frame, true)]
    [Register("assayMe.droid.views.AgreementView")]
    public class AgreementView : BaseFragment<AgreementViewModel>
    {
        protected override int FragmentId => Resource.Layout.fragment_agreement;

        #region overrides
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            tv_privacy_policy = view.FindViewById<TextView>(Resource.Id.tv_privacy_policy);
            InitPrivacyPolicy();
        }
        #endregion

        #region private methods
        private void InitPrivacyPolicy()
        {
            ISpannable word = new SpannableString(ViewModel.PrivacyPolicyText);
            word.SetSpan(new ForegroundColorSpan(Color.Black), 0, word.Length(), SpanTypes.ExclusiveExclusive);

            foreach (var item in ViewModel.UnderLineTexts)
            {
                var currentValue = item.Item1;
                var startCoordinate = ViewModel.PrivacyPolicyText.IndexOf(currentValue);
                var endCoordinate = startCoordinate + currentValue.Length;
                var click = new PrivacyPolicySpan(item.Item2 == Core.Models.Enums.PrivacyPolicyType.PP ?
                    ViewModel.GoPrivacyPolicyCommand : ViewModel.GoEULACommand,Color.Black);
                word.SetSpan(click, startCoordinate, endCoordinate, SpanTypes.ExclusiveInclusive);
            }
            tv_privacy_policy.SetHighlightColor(Color.Transparent);
            tv_privacy_policy.SetText(word, TextView.BufferType.Normal);
            tv_privacy_policy.MovementMethod = LinkMovementMethod.Instance;
        }
        #endregion

        #region private properties
        TextView tv_privacy_policy;
        #endregion
    }
   
}