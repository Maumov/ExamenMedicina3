using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsHandler : MonoBehaviour
{
    private BannerView bannerView;

    public bool IsTesting = true;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        Invoke("LateStart", 1f);
    }

    void LateStart() {
        if(IsTesting) {
#if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        } else {
#if UNITY_ANDROID
            string appId = "ca-app-pub-8811099624560932~7297972766";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-8811099624560932~9230001530";
#else
            string appId = "unexpected_platform";
#endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-8811099624560932/8325373155";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-8811099624560932/9038429846";
#else
            string adUnitId = "unexpected_platform";
#endif

            // Create a 320x50 banner at the top of the screen.
            bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        }

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}
