using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
    public float timer = 10;
    public GameObject firego;
    private float time = 0;
    private float lifetime = 2;
    public GameObject starter;
	// Use this for initialization
	void Start () {
        if((transform.position.z < -5 || transform.position.z > 45) && ( transform.position.x > -95 )){
            extinguish();
        }
        
	}
	
    void extinguish()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col){
        if (col.tag == "fire" && (col.transform.position-this.transform.position).magnitude < 5f){
             Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if(time > timer)
        {   
            GameObject nf = Instantiate(firego, new Vector3(Random.value * 8 - 4, Random.value * 2-.5f, Random.value * 8 - 4) +transform.position, transform.rotation) as GameObject;
            nf.GetComponent<fire>().starter = starter;
            time = 0;
            lifetime--;
        }
        if(lifetime == 0 || Time.time > (transform.position-starter.transform.position).magnitude*4f+25)
        {
            extinguish();
        }
	}
}
