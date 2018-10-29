using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spell : MonoBehaviour {

    int id;
    public int manaCost;
    public float coolDown;
    public string spellName;

    public ParticleSystem spellVisual;

    private void Start()
    {
        spellVisual = GetComponent<ParticleSystem>();
    }
    public void CastSpell()
    { 
        spellVisual.Play();
    }

}
