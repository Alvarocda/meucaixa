﻿using Android.App;
using Android.Support.Design.Widget;
using meucaixa.Droid.DependencyService;
using meucaixa.Interfaces;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(SnackbarService))]
namespace meucaixa.Droid.DependencyService
{
    public class SnackbarService : ISnackbar
    {
        public void MostraSnackbarLongo(string mensagem)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View view = activity.FindViewById(Android.Resource.Id.Content);
            Snackbar.Make(view, mensagem, Snackbar.LengthLong).Show();
        }
        public void MostraSnackbarCurto(string mensagem)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View view = activity.FindViewById(Android.Resource.Id.Content);
            Snackbar.Make(view, mensagem, Snackbar.LengthLong).Show();
        }
    }
}