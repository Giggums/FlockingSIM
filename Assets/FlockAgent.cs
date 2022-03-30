using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    //Vector3 lastPos;
    //Vector3 newPos;
    //float t;

    Flock agentFlock;
    public Flock AgentFlock 
    { 
        get 
        { 
            return agentFlock; 
        } 
    }

    Collider2D agentCollider;
    public Collider2D AgentCollider 
    { 
        get 
        { 
            return agentCollider; 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();

        //lastPos = transform.eulerAngles;
        //NewAngle();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime ;
    }

	void Update()
	{
        //transform.eulerAngles = Vector3.Lerp(lastPos, newPos, t);
        //t += 0.01f;
        //if (t > 1)
        //    NewAngle();
    }

    //void NewAngle()
    //{
    //    lastPos = newPos;
    //    newPos = new Vector2(
    //                 Random.Range(-10f, 10f),
    //                 Random.Range(0f, 360f));
    //    t = 0;
    //}

}