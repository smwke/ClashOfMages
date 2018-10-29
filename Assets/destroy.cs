using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Spell[] spells = GetComponents<Spell>();
        foreach (var slep in spells)
        {
            Destroy(slep);
        }
    }
}

