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

namespace RecyclerViewTest
{
    public class Photo
    {
        public int mPhotoID;

        public string mCaption;

        public int PhotoID
        {
            get { return mPhotoID; }
        }

        public string Caption
        {
            get { return mCaption; }
        }
    }

    public class PhotoAlbum
    {
        //Database here

        static Photo[] mBuiltInPhotos =
        {
            new Photo {mPhotoID = Resource.Drawable.LR_Vegito_blue, mCaption = "LR Vegito Blue"},

            new Photo {mPhotoID = Resource.Drawable.LR_Gogeta, mCaption = "LR Gogeta"}
        };

        private Photo[] mPhotos;

        Random mRandom;

        public PhotoAlbum()
        {
            mPhotos = mBuiltInPhotos;
            mRandom = new Random();
        }

        public int NumPhotos
        {
            get { return mPhotos.Length; }
        }

        public Photo this[int i]
        {
            get { return mPhotos[i]; }
        }

        public int RandomSwap()
        {
            // Save the photo at the top:
            Photo tmpPhoto = mPhotos[0];

            // Generate a next random index between 1 and 
            // Length (noninclusive):
            int rnd = mRandom.Next(1, mPhotos.Length);

            // Exchange top photo with randomly-chosen photo:
            mPhotos[0] = mPhotos[rnd];
            mPhotos[rnd] = tmpPhoto;

            // Return the index of which photo was swapped with the top:
            return rnd;
        }

        // Shuffle the order of the photos:
        public void Shuffle()
        {
            // Use the Fisher-Yates shuffle algorithm:
            for (int idx = 0; idx < mPhotos.Length; ++idx)
            {
                // Save the photo at idx:
                Photo tmpPhoto = mPhotos[idx];

                // Generate a next random index between idx (inclusive) and 
                // Length (noninclusive):
                int rnd = mRandom.Next(idx, mPhotos.Length);

                // Exchange photo at idx with randomly-chosen (later) photo:
                mPhotos[idx] = mPhotos[rnd];
                mPhotos[rnd] = tmpPhoto;
            }
        }
    }
}