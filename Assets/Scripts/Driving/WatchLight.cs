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
        maxVelo = 2000;
    }
    public float dot;
    // Update is called once per frame
    void Update()
    {
      //  FindLight();
        if (test == null)
        {
            acceleration = rb.transform.forward.normalized * 20f;
            Accelerate();
        }
        else
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
        if (Vector3.Dot(velocity.normalized, transform.forward.normalized) == -1)
        {
            velocity = velocity * 0;
        }
        rb.transform.position += velocity * Time.deltaTime;
    }
    public void Stop()
    {
        velocity += acceleration * Time.deltaTime;
        if (Vector3.Dot(velocity.normalized, transform.forward.normalized) >= -1 && Vector3.Dot(velocity.normalized, transform.forward.normalized) <= -.95f)
        {
            velocity = velocity * 0;
        }
        rb.transform.position += velocity * Time.deltaTime;
    }
    public void FindLight()
    {
        //Doesnt work
        //trying to get a vector witch is rotated 45 degrees up from its forward direction
        transform.Rotate(new Vector3(transform.localRotation.x, 0, 0), 1f * Mathf.PI / 4f);
        Quaternion q = transform.localRotation;
        transform.Rotate(new Vector3(0,transform.localRotation.y, 0), -1f * Mathf.PI / 4f);
        Ray D = new Ray(transform.position,q.eulerAngles);
        RaycastHit hit;
        if (Physics.SphereCast(D, 50f, out hit) && hit.collider.CompareTag("TrafficLight") && (hit.collider.transform.position - transform.position).magnitude < 100)
        {
            test = hit.collider.gameObject.GetComponent<Lights>();
        }
        else
            test = null;
        Debug.DrawLine(transform.position, D.direction * 10);
    }
}
