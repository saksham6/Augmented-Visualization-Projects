using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent NavmeshAgent;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NavmeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      if (player != null)
        {
            NavmeshAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy hit Lava");
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
