using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class DisableScripts : NetworkBehaviour {

    [SerializeField] Behaviour[] scripts;

	void Start ()
    {
        if (!isLocalPlayer)
        {
            foreach (Behaviour script in scripts)
            {
                script.enabled = false;
            }
        }
		
	}
	
	
}
