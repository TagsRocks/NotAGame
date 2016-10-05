using UnityEngine;
using System.Collections;

public class agentController : MonoBehaviour {
    private Transform goal;
    private NavMeshAgent agent;
    private GameObject[] exits, rooms;
    public bool evacuating = false;
    private bool got;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        exits = GameObject.FindGameObjectsWithTag("exit_goal");
        rooms = GameObject.FindGameObjectsWithTag("room_goal");
        findNewRoomGoal();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "fire") Destroy(this.gameObject);
    }

    void findNewRoomGoal()
    {
        goal = rooms[Random.Range(0, GameObject.FindGameObjectsWithTag("agentGoal").Length)].transform;
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
    void Update () {
        if (evacuating)
        {
            if(!got)
            findExitGoal();
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
