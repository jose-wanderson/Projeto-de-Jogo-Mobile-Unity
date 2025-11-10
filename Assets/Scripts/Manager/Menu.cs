using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class Menu : MonoBehaviour
{

    public Text totalPointsText;

   

    private void Start()
    {
        UpdateTotalpoints();
        BannerAds();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
       // AdManager.instance.CallHideBanner();
    }

    public void RetornarMenu()
    {
        
        SceneManager.LoadScene(1);
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ShowRanking()
    {
        PlayGamesManager.instance.ShowRanking();
    }

    public void ShowAchievements()
    {
        PlayGamesManager.instance.ShowAchievements();
    }


    public void UpdateTotalpoints()
    {
        totalPointsText.text = "MOEDAS: " + GameManager.Instance.totalPoints;
       
    }

    public void IntertitialAds()
    {
        Interstitial.instance.LoadAndShowAd();
    }

    void BannerAds()
    {
        Banner.instance.LoadAndShowBanner();
    }


}
