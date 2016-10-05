using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
    public float timer = 10;
    public GameObject firego;
    private float time = 0;
    private float lifetime = 2;
	// Use this for initialization
	void Start () {
	
	}
	
    void extinguish()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if(time > timer)
        {
            GameObject.Instantiate(firego, new Vector3(Random.value * 8 - 4, Random.value * 2-.5f, Random.value * 8 - 4) +transform.position, transform.rotation);
            time = 0;
            lifetime--;
        }
        if(lifetime == 0)
        {
            extinguish();
        }
	}
}
