using Android.Gms.Ads;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace SmoothieTub.Platforms.Android.Handlers
{
    public class BannerAdViewHandler : ViewHandler<BannerAdView, AdView>
    {
        // ✅ Static empty property mapper required
        public static IPropertyMapper<BannerAdView, BannerAdViewHandler> Mapper = new PropertyMapper<BannerAdView, BannerAdViewHandler>();

        public BannerAdViewHandler() : base(Mapper) // ✅ use the empty mapper here
        {
        }

        protected override AdView CreatePlatformView()
        {
            
            var adView = new AdView(Context)
            {
                AdSize = AdSize.Banner,
                AdUnitId = "ca-app-pub-3940256099942544/9214589741" // Replace with your Ad Unit ID
                                                                    //    AdUnitId = "ca-app-pub-1996027206561749/6356542246"
            };

            var adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);

            return adView;
        }
    }
}
