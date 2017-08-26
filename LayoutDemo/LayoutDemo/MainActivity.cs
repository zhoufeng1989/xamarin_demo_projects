using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace LayoutDemo
{
    [Activity(Label = "LayoutDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button layoutWeightButton, layoutWeight2Button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            layoutWeightButton = FindViewById<Button>(Resource.Id.layoutWeightButton);
            layoutWeight2Button = FindViewById<Button>(Resource.Id.layoutWeight2Button);

            layoutWeightButton.Click += (sender, e) => {
                StartActivity(typeof(LayoutWeightActivity));
            };

            layoutWeight2Button.Click += (sender, e) => {
                StartActivity(typeof(LayoutWeight2Activity));
            };
        }
    }
}

