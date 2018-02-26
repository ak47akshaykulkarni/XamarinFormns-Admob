using Xamarin.Forms;
using XFAdmob.Dependencies;
using XFAdmob.Droid.Dependencies;
using Android.Gms.Ads;

[assembly:Dependency(typeof(AdMobImplementation))]
namespace XFAdmob.Droid.Dependencies
{
    public class AdMobImplementation : IAdMob
    {
        InterstitialAd interstitialAd;
        public AdMobImplementation()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context) { AdUnitId = Constants.AndroidInterstitialAdUnitId};
            LoadInterstitialAd();
        }
        private void LoadInterstitialAd()
        {
            interstitialAd.LoadAd(new AdRequest.Builder().Build());
        }

        public void ShowInterstitialAd()
        {
            if (interstitialAd.IsLoaded)
                interstitialAd.Show();

            LoadInterstitialAd();
        }
    }
}