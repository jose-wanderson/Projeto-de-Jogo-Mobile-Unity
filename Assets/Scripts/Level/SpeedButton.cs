using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SpeedButton : MonoBehaviour
{
    public int SpeedPersonagem;
    public int cust;
    private Button button;
    public Text custText;

    private Menu menu;

    private void Awake()
    {
        button = GetComponent<Button>();

    }


    void Start()
    {
        if (GameManager.Instance.speedPersonagem >= SpeedPersonagem)
        {
            button.interactable = false;
        }

        menu = FindObjectOfType<Menu>();

        custText.text = cust.ToString();

    }

    public void BuySpeedPersonagem()
    {
        if (GameManager.Instance.totalPoints < cust || (GameManager.Instance.speedPersonagem + 1) != SpeedPersonagem)
            return;

        button.interactable = false;
        GameManager.Instance.speedPersonagem = SpeedPersonagem;
        GameManager.Instance.totalPoints -= cust;

        PlayerPrefs.SetInt("SpeedPersonagem", SpeedPersonagem);
        PlayerPrefs.SetInt("TotalPoints", GameManager.Instance.totalPoints);

        menu.UpdateTotalpoints();

    }
}
