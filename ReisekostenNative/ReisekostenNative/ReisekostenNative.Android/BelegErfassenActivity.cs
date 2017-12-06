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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using IO.Swagger.Model;
using Android.Provider;
using Android.Content.PM;
using Java.IO;
using Android.Graphics;
using ReisekostenNative.Services;
using System.Threading.Tasks;
using Android.Database;


namespace ReisekostenNative.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MyAppTheme")]
    public class BelegErfassenActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener
    {

        EditText etDate;
        Beleg beleg;
        Bitmap bitmap;

        File photoDir;
        File photoFile;
        ImageView ivPhoto;
        string user;
        Spinner spBelegArten;

        EditText betrag;
        EditText bezeichnung;



        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            DateTime date = new DateTime(year, month + 1, dayOfMonth);
            etDate.Text= date.ToString("dd.MM.yyyy");
            beleg.Date = date;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            user = Intent.Extras.GetString("USER");
            beleg = new Beleg(0, "", DateTime.Now, "", 0, Beleg.StatusEnum.ERFASST, null, null, 0, user);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.beleg_erfassen);

            betrag = FindViewById<EditText>(Resource.Id.et_betrag);
            bezeichnung = FindViewById<EditText>(Resource.Id.et_bezeichnung);
            spBelegArten = FindViewById<Spinner>(Resource.Id.sp_art);

            etDate = FindViewById<EditText>(Resource.Id.et_date);
            etDate.Click += delegate
            {
                DateTime date = beleg.Date.Value;
                new DatePickerDialog(this, this, date.Year, date.Month, date.Day).Show();
            };
            CreateDirectoryForPictures();
            ivPhoto = FindViewById<ImageView>(Resource.Id.iv_beleg_image);
            ivPhoto.Click += delegate
            {
                takePhoto();
            };

            UIService.Instance.GetBelegarten((o) => setBelegArten(o));




        }

        private void setBelegArten(Task<List<string>> belegTask)
        {
            RunOnUiThread(() =>
            {
                ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.beleg_art_eintrag, belegTask.Result);
                spBelegArten.Adapter = adapter;
            });
        }

        private void takePhoto()
        {
            if (IsThereAnAppToTakePictures())
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                photoFile = new File(photoDir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
                intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(photoFile));
                StartActivityForResult(intent, 5);
            }
        }

        private void CreateDirectoryForPictures()
        {
            photoDir = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "BelegPhotos");
            if (!photoDir.Exists())
            {
                photoDir.Mkdirs();
            }
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.erstellen_menu, menu);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(item.ItemId == Resource.Id.action_save)
            {
                beleg.Betrag = Int64.Parse(betrag.Text);
                beleg.Description = bezeichnung.Text;
                beleg.Type = spBelegArten.SelectedItem.ToString();
                beleg.User = user;
                
                UIService.Instance.CreateBeleg(beleg, (o) => SaveDone(o));

                return true;
            }

            return false;
        }

        private void SaveDone(Task<int> o)
        {
            if(o.Result > 300)
            {
                Toast.MakeText(this, "Fehler beim Speichern", ToastLength.Long).Show();
            }
            else
            {
                Finish();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        

        

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(photoFile);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = ivPhoto.Height;
            bitmap = LoadAndResizeBitmap(photoFile.Path, width, height);
            if (bitmap != null)
            {
                ivPhoto.SetImageBitmap(bitmap);

                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 70, stream);
                beleg.Thumbnail= stream.ToArray();

                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        public Bitmap LoadAndResizeBitmap(string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }

   

}