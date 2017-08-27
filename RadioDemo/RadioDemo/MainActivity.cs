using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace RadioDemo
{
    [Activity(Label = "RadioDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ImageView imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            imageView = FindViewById<ImageView>(Resource.Id.tmntImage);
        }


        [Java.Interop.Export("radioClicked")]
        public void RadioClicked(View view) {
            if (view.Id == Resource.Id.donaRadio) {
                imageView.SetImageResource(Resource.Drawable.tmntdon);
            } else if (view.Id == Resource.Id.leoRadio) {
                imageView.SetImageResource(Resource.Drawable.tmntleo);
            } else if (view.Id == Resource.Id.mikeRadio) {
                imageView.SetImageResource(Resource.Drawable.tmntmike);
            } else if (view.Id == Resource.Id.raphRadio) {
                imageView.SetImageResource(Resource.Drawable.tmntraph);
            }
        }
    }
}

