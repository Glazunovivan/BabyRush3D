using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ads : MonoBehaviour
{
    
    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }

   
}
