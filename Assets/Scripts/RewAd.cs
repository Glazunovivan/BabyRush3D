using System;
using UnityEngine;
using GoogleMobileAds.Api;

//Видео-реклама, реклама с вознаграждением
public class RewAd : MonoBehaviour
{
    private RewardedAd _rewardedAd;

    //ключ рекламы поменять на свой (из аккаунта ADMob)
    //для теста использовать ТЕСТОВЫЕ значения
    private const string _rewardID = "ca-app-pub-3940256099942544/5224354917";

    private void Start()
    {
        _rewardedAd = new RewardedAd(_rewardID);
        _rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        CreateAndLoadRewardedAd();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }

    private void CreateAndLoadRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(request);
    }

    //Показ рекламы
    public void ShowAdversting()
    {
        if (_rewardedAd.IsLoaded())
        {
            _rewardedAd.Show();
        }
    }
}
