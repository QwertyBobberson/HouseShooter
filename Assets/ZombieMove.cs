using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour {
    NavMeshAgent walkSpace;
	bool StopZombies;

    // Use this for initialization
    void Start ()
    {
        walkSpace = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (!StopZombies)
		{
			walkSpace.SetDestination(ZombieSpawner.Player.transform.position);
		}


		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			walkSpace.SetDestination(new Vector3(0, 0, 0));
			StopZombies = !StopZombies;
		}
    
    }
}
