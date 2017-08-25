using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace ClickButtonDemo
{
    [Activity(Label = "ClickButtonDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button firstButton, secondButton;
        int firstClickCount = 0, secondClickCount = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            firstButton = FindViewById<Button>(Resource.Id.firstButton);
            secondButton = FindViewById<Button>(Resource.Id.secondButton);

            firstButton.Click += (sender, e) => {
                firstClickCount += 1;
                firstButton.Text = string.Format("Click {0} times", firstClickCount);
            };
        }

        [Java.Interop.Export("secondButtonClick")]
        public void SecondButtonClick(View view) {
            secondClickCount += 1;
            secondButton.Text = string.Format("Click {0} times", secondClickCount);
        }
    }
}

