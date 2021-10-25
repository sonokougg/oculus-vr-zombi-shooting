using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    Zombi zombi;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        zombi = GetComponent<Zombi>();
	}
	
	// Update is called once per frame
	void Update () {
        if(zombi.CanWalk)
        {
            // ゾンビがプレイヤーの方に向かっていく
            agent.destination = player.transform.position;
        }
	}
}
