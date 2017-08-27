using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;


namespace ArrayAdapterDemo {

    [Activity(Label = "ArrayAdapterDemo", MainLauncher = true)]
    public class MainActivity : Activity {

        ListView listView;
        Spinner spinner;
        static string[] words = {
            "Android", "Google Mobile App platform",
            "iOS", "Apple Mobile App platform",
            "Windows Phone", "Microsoft Mobile App platform"
        };
        Dictionary<string, string> dict;

        protected override void OnCreate(Bundle savedInstanceState) {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            dict = new Dictionary<string, string>();
            for (int i = 0; i < words.Length; i += 2) {
                dict[words[i]] = words[i + 1];
            }

            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Resource.Layout.ListViewLayout, dict.Keys.ToArray());

			listView = FindViewById<ListView>(Resource.Id.listView2);
			listView.Adapter = arrayAdapter;
            listView.ItemClick += (sender, e) => {
				string word = e.Parent.GetItemAtPosition(e.Position).ToString();
				Toast.MakeText(this, dict[word], ToastLength.Short).Show();
			};

			spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.Adapter = arrayAdapter;
            spinner.ItemSelected += (sender, e) => {
				string word = e.Parent.GetItemAtPosition(e.Position).ToString();
				Toast.MakeText(this, dict[word], ToastLength.Short).Show();
			};
		}
    }
}