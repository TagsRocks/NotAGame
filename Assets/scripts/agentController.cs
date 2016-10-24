using UnityEngine;
using System.Collections;

public class agentController : MonoBehaviour {
    private Transform goal;
    private NavMeshAgent agent;
    private GameObject[] exits, rooms;
    public bool evacuating = false;
    private bool got, infire;
    public Material[] materials = new Material[3]; 


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        exits = GameObject.FindGameObjectsWithTag("exit_goal");
        rooms = GameObject.FindGameObjectsWithTag("room_goal");
        findNewRoomGoal();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "fire") 
            if(infire){
                Destroy(this.gameObject);
            } else {
                infire = true;
            }
        if (col.tag == "agent" && col.GetComponent<agentController>().evacuating) {
            this.evacuating = true;
            got = true;
            findExitGoal();
            ChangeMat(3);
        }
    }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {   
        
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("fire")) {
			infire = false;
		}
    }

    void findNewRoomGoal()
    {
        goal = rooms[Random.Range(0, rooms.Length)].transform;
        agent.destination = goal.position;
    }

    void findExitGoal()
    {
        float min = 100000, tmp;
        Vector3 point = new Vector3(0,0,0);
        for (int i = 0; i < exits.Length; i++)
        {
            tmp = (transform.position - exits[i].transform.position).magnitude;
            if (tmp < min)
            {
                min = tmp;
                point = exits[i].transform.position;
            }
        }
        agent.destination = point;
    }


    bool isNear()
    {
        return (transform.position - goal.transform.position).magnitude <= 3f;
    }
    // Update is called once per frame

    void ChangeMat(int m){
       // this.GetComponent<SkinnedMeshRenderer>().material = materials[m];
        this.GetComponentInChildren<SkinnedMeshRenderer>().material = materials[m];
        
    }   
 void Update () {
        
        if (evacuating)
        {
           
            if(!got){
                findExitGoal();
                 ChangeMat(2);
            }
        }
        else
        {
            if (isNear())
            {
                findNewRoomGoal();
            }
        }
	}
}
