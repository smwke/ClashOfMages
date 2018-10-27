using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
    public Behaviour[] componentsToDisable;
	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            foreach(var c in componentsToDisable)
            {
                c.enabled = false;
            }
        }
        else
        {
            //PlayerManager.instance.player = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
