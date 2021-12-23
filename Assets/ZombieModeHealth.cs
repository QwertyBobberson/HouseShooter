using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieModeHealth : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] int health;
    [SerializeField] int zombieDamage;
    [SerializeField] Slider healthBar;
    [SerializeField] Text statBox;
    [SerializeField] Camera gameCam;
    [SerializeField] Camera endCam;
    [SerializeField] Text finalScore;
    [SerializeField] Text playerHealth;
    public static int playerScore;



    void Start()
    {
        endCam.enabled = false;
        gameCam.enabled = true;
        health = startingHealth;
        playerScore = 0;
    }
    
    void Update()
    {
        statBox.text = "Score: " + playerScore;
        if (health <= 0 || Input.GetKeyDown(KeyCode.K) || transform.position.y < -10)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Zombie 1(Clone)")
        {
            health -= zombieDamage;
            playerHealth.text = Convert.ToString(health);
            healthBar.value = health;
        }
    }

    void Die()
    {
        endCam.enabled = true;
        gameCam.enabled = false;
        finalScore.text = "Score: " + playerScore;
        Invoke("GoHome", 3);
    }

    private void GoHome()
    {
        SceneManager.LoadScene("MainScreen", LoadSceneMode.Single);
    }
}
