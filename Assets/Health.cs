using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{   
    [SerializeField] int startingHealth;
    public int health;
    [SerializeField] public Slider healthBar;
    [SerializeField] Text statBox;
    public int kills;
    int deaths;
    float KD;
    int floor;
    int y;


    void Start()
    {
        statBox.text = null;

        health = startingHealth;
        deaths = 0;
        kills = 0;
        KD = 0.00f;



    }
    
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoHome();
        }
        */
        if (Input.GetKey(KeyCode.Tab))
        {
            statBox.text = "KD: " + KD + " Kills: " + kills + " Deaths: " + deaths;
        }
        else
        {
            statBox.text = null;
        }
            

        if (health <= 0 || Input.GetKeyDown(KeyCode.K) || transform.position.y < -10)
        {
            Die();
        }

        if (deaths > 0)
        {
            KD = kills / deaths;
        }

        else
        {
            KD = kills;
        }
            
    }

    void Die()
    {

        floor = Random.Range(1, 4);
        y = Random.Range(0, 16);
        switch (floor)
        {
            case 1:
                y = Random.Range(0, 8);
                break;
            case 2:
                y = Random.Range(8, 12);
                break;
            case 3:
                y = Random.Range(12, 16);
                break;

        }

        transform.position = new Vector3(Random.Range(-15, 17), y, Random.Range(-15, 15));
        health = startingHealth;
        deaths++;

    }
    private void GoHome()
    {
        SceneManager.LoadScene("MainScreen", LoadSceneMode.Single);
    }

}
