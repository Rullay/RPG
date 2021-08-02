using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterEnemy : MonoBehaviour
{
    private GameObject PlayerObject;
    private NavMeshAgent NMA;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameManager.Instance.PlayerTransform.gameObject;
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
