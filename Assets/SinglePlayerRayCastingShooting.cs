using UnityEngine;

public class SinglePlayerRayCastingShooting : MonoBehaviour {

    [SerializeField] Camera FPSCamera;
    [SerializeField] int Damage = 20;
    [SerializeField] int Range = 100;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }   
	}
    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, Range))
        {
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                if (health.health <= Damage)
                {
                    Health myHealth = GetComponent<Health>();
                    myHealth.kills++;
                }
                health.health -= Damage;
                health.healthBar.value = health.health;
            }
        }
    }
}
