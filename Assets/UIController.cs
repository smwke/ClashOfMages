using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public Image currentHealthbar;
    public Text ratioText;

    public Unit target;

    float health,maxHealth;

	// Use this for initialization
	void Start () {
        target = GetComponent<Unit>();
	    maxHealth = target.Health;
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        health = target.Health;
        float ratio = health / maxHealth;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + "%";

	}
}
