using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] public static GameObject Player;
    [SerializeField] int maxNumZombies;
    int floor;
    float y;
    
    void Start()
    {
        Player = GameObject.Find("FPSController (1)");
        for (int numZombies = 0; numZombies <= maxNumZombies; numZombies++)
        {
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

            Instantiate(zombiePrefab, new Vector3(Random.Range(-15, 15), y, Random.Range(-15, 15)), gameObject.transform.rotation);
        }
    }
}
