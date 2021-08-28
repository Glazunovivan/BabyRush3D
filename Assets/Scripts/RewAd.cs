using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

//�����-�������, ������� � ���������������
public class RewAd : MonoBehaviour
{
    public RewardedAd RewardedAd;
    //���� ������� �������� �� ���� (�� �������� ADMob)
    //��� ����� ������������ �������� ��������
    private const string _rewardID = "ca-app-pub-3940256099942544/5224354917";

    private void Start()
    {
        RewardedAd = new RewardedAd(_rewardID);
        RewardedAd.OnAdClosed += HandleRewardedAdClosed;
        CreateAndLoadRewardedAd();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }

    private void CreateAndLoadRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        RewardedAd.LoadAd(request);
    }

    //����� �������
    public void ShowAdversting()
    {
        if (RewardedAd.IsLoaded())
        {
            RewardedAd.Show();
        }
    }
}
