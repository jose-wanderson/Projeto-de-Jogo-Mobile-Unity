using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int totalPoints;
    public int maxScore;

    public int level;

    public int speedPersonagem;

    public Level[] levels;
    public SpeedPerson[] speedPerson;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            DontDestroyOnLoad(gameObject);
        }

        totalPoints = PlayerPrefs.GetInt("TotalPoints"); 
        maxScore = PlayerPrefs.GetInt("MaxScore");
        
        speedPersonagem = PlayerPrefs.GetInt("SpeedPersonagem");
        level = PlayerPrefs.GetInt("Level");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
