using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class LevelButton : MonoBehaviour
{

    public int level;
    public int cust;
    

    private Button button;
    public Text custText;

    private Menu menu;

    private void Awake()
    {
        button = GetComponent<Button>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
       if(GameManager.Instance.level >= level)
       {
            button.interactable = false;
       } 
        
        menu = FindObjectOfType<Menu>();

        custText.text = cust.ToString(); 

    }

    public void  BuyLavel()
    {
        if (GameManager.Instance.totalPoints < cust || (GameManager.Instance.level + 1) != level)
            return;

        button.interactable = false;
        GameManager.Instance.level = level;
        GameManager.Instance.totalPoints -= cust;

        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("TotalPoints", GameManager.Instance.totalPoints);

        menu.UpdateTotalpoints();

    }



}
