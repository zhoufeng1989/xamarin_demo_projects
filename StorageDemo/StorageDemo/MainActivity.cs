using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Collections.Generic;


namespace StorageDemo {

    [Activity(Label = "StorageDemo", MainLauncher = true)]
    public class MainActivity : Activity {

        Dictionary<string, string> dict = new Dictionary<string, string>();
        TextView textView;
        Button readFileFromAssets, saveFileToInternal, loadFileFromInternal, saveFileToExternal, loadFileFromExternal;

        protected override void OnCreate(Bundle savedInstanceState) {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            readFileFromAssets = FindViewById<Button>(Resource.Id.readFileFromAssetsButton);
            readFileFromAssets.Click += (sender, e) => {
                ReadFileFromAssets();
            };

            saveFileToInternal = FindViewById<Button>(Resource.Id.saveFileToInternalButton);
            saveFileToInternal.Click += (sender, e) => {
                SaveFileToInternalStorage();
            };

            loadFileFromInternal = FindViewById<Button>(Resource.Id.loadFileFromInternalButton);
            loadFileFromInternal.Click += (sender, e) => {
                LoadFileFromInternalStorage();
            };

            saveFileToExternal = FindViewById<Button>(Resource.Id.saveFileToExternalButton);
            saveFileToExternal.Click += (sender, e) => {
                SaveFileToExternalStorage();
            };
            loadFileFromExternal = FindViewById<Button>(Resource.Id.loadFileFromExternalButton);
            loadFileFromExternal.Click += (sender, e) => {
                LoadFileFromExternalStorage();
            };

            textView = FindViewById<TextView>(Resource.Id.infoTextView);
        }


        public void ReadFileFromAssets() {

            string fileName = "grewords.txt";
            Stream stream = Assets.Open(fileName);
            StreamReader streamReader = new StreamReader(stream);
            dict.Clear();

            while (!streamReader.EndOfStream) {
                string line = streamReader.ReadLine();
                string[] parts = line.Split("\t".ToCharArray());
                dict.Add(parts[0], parts[1]);
            }

            textView.Text = "Read File from Assets/grepwords.txt";
        }

        public void SaveFileToInternalStorage() {

            string fileName = "mywords.txt";
            Stream stream = OpenFileOutput(fileName, Android.Content.FileCreationMode.WorldWriteable);
            StreamWriter streamWriter = new StreamWriter(stream);
            string text = "AUT\tBest University in New Zealand\n"
               + "SECMS\tA great School in AUT\n"
               + "COMP826\tA boring Mobile Programming Course\n"
               + "Abbas\tA boring boring teacher...\n";
            streamWriter.Write(text);
            streamWriter.Close();
            stream.Close();

            string filePath = Path.GetFullPath(fileName);
            textView.Text = "save file to internal storage: " + filePath;
        }


        public void LoadFileFromInternalStorage() {

            string fileName = "mywords.txt";
            Stream stream = OpenFileInput(fileName);
            StreamReader streamReader = new StreamReader(stream);

            dict.Clear();
            while(!streamReader.EndOfStream) {
                string line = streamReader.ReadLine();
                string[] parts = line.Split("\t".ToCharArray());
                dict.Add(parts[0], parts[1]);
            }
            streamReader.Close();
            stream.Close();

            Java.IO.File filePath = GetFileStreamPath(fileName);
            textView.Text = "load file from internal storage: " + filePath.Path; 
        }

        public void SaveFileToExternalStorage() {

            string fileName = "myexternalwords.txt";
            string externalDir = Environment.ExternalStorageDirectory.AbsoluteFile.ToString();
            string absoluteFileName = Path.Combine(externalDir, fileName);
            StreamWriter streamWriter = new StreamWriter(absoluteFileName);
            string fileText = "This is a file stored in external storage.\n";
            streamWriter.Write(fileText);
            streamWriter.Close();

            textView.Text = "save file to external storage: " + absoluteFileName;
        }


        public void LoadFileFromExternalStorage() {
			string fileName = "myexternalwords.txt";
			string externalDir = Environment.ExternalStorageDirectory.AbsoluteFile.ToString();
			string absoluteFileName = Path.Combine(externalDir, fileName);
            StreamReader streamReader = new StreamReader(absoluteFileName);
            string fileText = streamReader.ReadToEnd();
            streamReader.Close();

            textView.Text = "load file from external storage: " + absoluteFileName;
		}
    }
}

