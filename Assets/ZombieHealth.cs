using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
	//Makes variables for stats
	[SerializeField] int zomMaxHealth;
    [SerializeField] int zomHealth = 100;
    [SerializeField] Slider zomHealthBar;
    int floor;
    float y;

    private void Start()
    {
        zomHealthBar.maxValue = zomHealth;
        zomHealthBar.minValue = 0;
    }


    public void TakeDamage(int bulletDamage)
    {
        zomHealth -= bulletDamage;
        ZombieModeHealth.playerScore += bulletDamage;
        zomHealthBar.value = zomHealth;
        if (zomHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
		Transform[] children = this.gameObject.GetComponentsInChildren<Transform>();

		foreach (Transform child in children)
		{
			if (child.gameObject.GetComponent<ParticleSystem>() != null)
			{
				Destroy(child.gameObject, 0);
			}
		}

        floor = Random.Range(1, 3);
        y = Random.Range(0, 16);
        switch (floor)
        {
            case 1:
                y = 1.25f;
                break;
            case 2:
                y = 10.5f;
                break;
            case 3:
                y = 14.25f;
                break;
        }
        transform.position = new Vector3(Random.Range(-15, 15), y, Random.Range(-15, 15));
		zomHealth = zomMaxHealth;
		zomHealthBar.value = zomMaxHealth;
		
    }


}
