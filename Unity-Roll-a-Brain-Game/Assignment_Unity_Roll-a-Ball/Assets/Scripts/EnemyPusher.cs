using UnityEngine;
using UnityEngine.AI;

public class EnemyPusher : MonoBehaviour
{
    public Transform targetTransform;
    public float speed = 15f;
    public float activationRadius = 8f;
    private Rigidbody rb;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( targetTransform != null)
           {
                rb.linearVelocity= Vector3.zero;
                Vector3 direction = (targetTransform.position - transform.position);
                float distance = direction.magnitude;

                    if (distance < activationRadius)

                
                        {
                            direction = direction.normalized;
                            rb.linearVelocity = new Vector3(direction.x * speed, rb.linearVelocity.y, direction.z * speed);
                        }
                    else
                        {
                            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0);
                        }
            }
    }
}