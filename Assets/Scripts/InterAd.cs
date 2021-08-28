using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    private InterstitialAd _interAd;

    //���� ������� �������� �� ���� (�� �������� ADMob)
    //��� ����� ������������ �������� ��������
    private const string _interstitialID = "ca-app-pub-3940256099942544/8691691433";

    private void OnEnable()
    {
        AdRequest request = new AdRequest.Builder().Build();
        _interAd = new InterstitialAd(_interstitialID);
        _interAd.LoadAd(request);
    }

    //����� �������
    public void ShowAdversting()
    {
        AdRequest request = new AdRequest.Builder().Build();
        _interAd = new InterstitialAd(_interstitialID);
        _interAd.LoadAd(request);

        if (_interAd.IsLoaded())
        {
            _interAd.Show();
        }
    }
}
