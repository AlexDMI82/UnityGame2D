using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [SerializeField]private Health playerHealth;
    [SerializeField] private Crystals crystals;
    public Text healthStats;
    public Text scoreStats;    
    public int score = 0;

    // to access StatsManager from Crystals.cs
    public static StatsManager instance;

    private void Awake()
    {
        // to access StatsManager from Crystals.cs
        instance = this;
    }

    private void Start()
    {
        scoreStats.text = "Score: " + score.ToString();
        healthStats.text = "Health: " + playerHealth.currentHealth.ToString();     
   
    }

    private void Update()
    {
        healthStats.text = "Health: " + playerHealth.currentHealth.ToString();
    }


    public void AddPoint()
    {
        score += 10;
        scoreStats.text = "Score: " + score.ToString();
    }

}
