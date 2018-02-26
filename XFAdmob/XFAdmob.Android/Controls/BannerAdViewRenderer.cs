using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFAdmob.Controls;
using XFAdmob.Droid.Controls;

[assembly:ExportRenderer(typeof(BannerAdView),typeof(BannerAdViewRenderer))]
namespace XFAdmob.Droid.Controls
{
#pragma warning disable CS0618 // Type or member is obsolete
    class BannerAdViewRenderer : ViewRenderer<BannerAdView, AdView>
    {
        string adUnitId = Constants.AndroidBannerAdUnitId;
        //Note you may want to adjust this, see further down.
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;
        AdView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;
            
            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest
                            .Builder()
                            .Build());
            return adView;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<BannerAdView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}