using Android.App;
using Android.Widget;
using Android.OS;

namespace NumberGame {

    [Activity(Label = "NumberGame", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        Button gameStartButton;
        protected override void OnCreate(Bundle savedInstanceState) {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            gameStartButton = FindViewById<Button>(Resource.Id.gameStartButton);
            gameStartButton.Click += (sender, e) => {
                StartActivity(typeof(GameActivity));
            };
        }

    }
}

