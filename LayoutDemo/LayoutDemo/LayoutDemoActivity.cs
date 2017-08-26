
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

namespace LayoutDemo {

	[Activity(Label = "LayoutDemo", MainLauncher = true)]
    public class MainActivity : Activity {

        Button layoutWeightButton, layoutWeight2Button, gridLayoutButton;

        protected override void OnCreate(Bundle savedInstanceState) {

			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			layoutWeightButton = FindViewById<Button>(Resource.Id.layoutWeightButton);
			layoutWeight2Button = FindViewById<Button>(Resource.Id.layoutWeight2Button);
            gridLayoutButton = FindViewById<Button>(Resource.Id.gridLayoutButton);

			layoutWeightButton.Click += (sender, e) => {
				StartActivity(typeof(LayoutWeightActivity));
			};

			layoutWeight2Button.Click += (sender, e) => {
				StartActivity(typeof(LayoutWeight2Activity));
			};

            gridLayoutButton.Click += (sender, e) => {
                StartActivity(typeof(GridLayoutActivity));
            };
		}
	}


	[Activity]
    public class BackButtonActivity : Activity {

        public Button backButton;
        virtual public int LayoutId { get; set;}

        protected override void OnCreate(Bundle savedInstanceState) {

            base.OnCreate(savedInstanceState);

            Console.WriteLine("layout id is " + LayoutId);
            SetContentView(LayoutId);

			backButton = FindViewById<Button>(Resource.Id.backButton);
			backButton.Click += (sender, e) => {
				StartActivity(typeof(MainActivity));
			};
		}
    }


    [Activity(Label = "LayoutWeightActivity")]
    public class LayoutWeightActivity : BackButtonActivity {

        public override int LayoutId { get { return Resource.Layout.LayoutWeight; } }

    }


    [Activity(Label = "LayoutWeight2Activity")]
    public class LayoutWeight2Activity : BackButtonActivity {

		public override int LayoutId { get { return Resource.Layout.LayoutWeight2; } }

	}


    [Activity(Label = "GridLayoutActivity")]
    public class GridLayoutActivity : BackButtonActivity {

        public override int LayoutId { get { return Resource.Layout.GridLayout; } }

	}
}