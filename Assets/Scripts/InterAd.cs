using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    //ключ рекламы поменять потом на свой
    private string interstitialUnitId = "ca-app-pub-3940256099942544/1033173712";
    // Start is called before the first frame update
    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }
    //метод для показа рекламы
    public void ShowAd()
    {
        if (interstitialAd.IsLoaded())
            interstitialAd.Show();
    }
   

    
}
