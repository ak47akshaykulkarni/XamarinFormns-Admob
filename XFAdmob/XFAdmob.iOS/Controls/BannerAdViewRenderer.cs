using CoreGraphics;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFAdmob.Controls;
using XFAdmob.iOS.Controls;

[assembly:ExportRenderer(typeof(BannerAdView),typeof(BannerAdViewRenderer))]
namespace XFAdmob.iOS.Controls
{
    class BannerAdViewRenderer : ViewRenderer<BannerAdView, BannerView>
    {
        string AdUnitId = Constants.iOSBannerAdUnitId;
        BannerView adView;
        BannerView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;

            adView = new BannerView(AdSizeCons.SmartBannerPortrait, new CGPoint(0, UIScreen.MainScreen.Bounds.Size.Height - AdSizeCons.Banner.Size.Height))
            {
                AdUnitID = AdUnitId,
                RootViewController = new UIViewController()
            };
            
            adView.LoadRequest(GetRequest());
            return adView;
        }

        Request GetRequest()
        {
            var request = Request.GetDefaultRequest();
            return request;
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
}