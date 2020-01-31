using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public Rigidbody rb;
    public float xThrust;
    public float yThrust;
    public float speed;
    public GameObject pongBall;
    public bool paused;
    public bool thrust;

    void Start()
    {
        paused = true;
        thrust = false;
        StartCoroutine(Delay());
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (paused == true)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        } 
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            if (thrust == true)
            {
                rb.AddForce(xThrust, yThrust, 0, ForceMode.Impulse);
                yThrust = Random.Range(-15f, 15f);
                thrust = false;
                StopCoroutine(Delay());
            }
        }
        rb.velocity = speed * (rb.velocity.normalized);
    }

    void OnCollisionEnter(Collision collider)
    {
        GameObject theManager = GameObject.Find("Manager");
        GameManager managerScript = theManager.GetComponent<GameManager>();
        if (collider.collider.gameObject.name == "RightPlayerWall")
        {
            Instantiate(pongBall, new Vector3(0, 5, 0), Quaternion.identity);
            managerScript.playerOnePoints++;
            Destroy(gameObject);
        }
        if (collider.collider.gameObject.name == "LeftPlayerWall")
        {
            Instantiate(pongBall, new Vector3(0, 5, 0), Quaternion.identity);
            managerScript.playerTwoPoints++;
            Destroy(gameObject);
        }
    }

    private IEnumerator Delay()
    {
        paused = true;
        yield return new WaitForSeconds(2f);
        thrust = true;
        paused = false;
    }
}
