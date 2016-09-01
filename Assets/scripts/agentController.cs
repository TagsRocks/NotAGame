using UnityEngine;
using System.Collections;

public class agentController : MonoBehaviour {
    private Transform goal;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        findNewGoal();
    }

    void findNewGoal()
    {
        goal = GameObject.FindGameObjectsWithTag("agentGoal")[Random.Range(0, GameObject.FindGameObjectsWithTag("agentGoal").Length)].transform;
        agent.destination = goal.position;
    }


    bool isNear()
    {
        return (transform.position - goal.transform.position).magnitude <= 3f;
    }
    // Update is called once per frame
    void Update () {
	    if(isNear())
        {
            findNewGoal();
        }
	}
}
