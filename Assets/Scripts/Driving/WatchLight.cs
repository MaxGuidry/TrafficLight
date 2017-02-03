using UnityEngine;
using System.Collections;

public class WatchLight : MonoBehaviour
{
    [SerializeField]
    private float maxVelo;
    public Lights test;
    private Rigidbody rb;
    [SerializeField]
    private Vector3 velocity;
    private Vector3 acceleration;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = new Vector3(0, 0, 0);
        maxVelo = 200;
    }
    public float dot;
    // Update is called once per frame
    void Update()
    {

        dot = Vector3.Dot(velocity.normalized, transform.forward.normalized);
        if (test.currentState == test.greenState)
        {
            acceleration = rb.transform.forward.normalized * 20f;
            Accelerate();
        }
        if (test.currentState == test.redState)
        {
            acceleration = rb.transform.forward.normalized * -50f;
            Stop();
        }
        if (test.currentState == test.yellowState)
        {
            acceleration = rb.transform.forward.normalized * -5f;
            SlowDown();
        }

    }

    public void Accelerate()
    {
        velocity += acceleration * Time.deltaTime;
        if (velocity.magnitude > maxVelo)
        {
            velocity = velocity.normalized * maxVelo;
        }
        rb.transform.position += velocity * Time.deltaTime;
    }

    public void SlowDown()
    {
        velocity += acceleration * Time.deltaTime;
        if(Vector3.Dot(velocity.normalized, transform.forward.normalized) == -1)
        {
            velocity =velocity* 0;
        }
        rb.transform.position+=velocity*Time.deltaTime;
    }
    public void Stop()
    {
        velocity += acceleration * Time.deltaTime;
        if (Vector3.Dot(velocity.normalized, transform.forward.normalized)== -1)
        {
            velocity = velocity * 0;
            
        }
        rb.transform.position+=velocity * Time.deltaTime;
    }
}
