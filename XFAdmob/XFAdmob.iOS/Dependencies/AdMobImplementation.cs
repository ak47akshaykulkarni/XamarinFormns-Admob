using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XFAdmob.Dependencies;
using Google.MobileAds;
using XFAdmob.iOS.Dependencies;

[assembly:Dependency(typeof(AdMobImplementation))]
namespace XFAdmob.iOS.Dependencies
{
    class AdMobImplementation : IAdMob
    {
        Interstitial interstitial;
        public AdMobImplementation()
        {
            LoadInterstitialAd();
            interstitial.ScreenDismissed += (s, e) => LoadInterstitialAd();
        }

        private void LoadInterstitialAd()
        {
            interstitial = new Interstitial(Constants.iOSInterstitialAdUnitId);

            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
        }

        public void ShowInterstitialAd()
        {
            if (interstitial.IsReady)
            {
                var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                interstitial.PresentFromRootViewController(viewController);
            }
            else
            {
                LoadInterstitialAd();
            }
        }
    }
}