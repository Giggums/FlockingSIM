using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FieldOfView))]
public class Flock : MonoBehaviour
{
    //NEW STUFF


    //public float viewRadius;
    //[Range(0, 360)]
    //public float viewAngle;

    //public LayerMask targetMask;
    //public LayerMask obstacleMask;

  



    //public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    //{
    //    if (!angleIsGlobal)
    //    {
    //        angleInDegrees += transform.eulerAngles.z;
    //    }

    //    return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    //}


    //IEnumerator GetNearbyeObjects(float delay)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(delay);
    //        GetNearbyeObjects(delay);
    //    }
    //}
    //NEW STUFF


    //Vector3 lastPos;
    //Vector3 newPos;
    //float t;

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behaviour;

    [Range(0, 500)]
    public int startingCount = 250;
    const float AgentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius
    {
        get
        {
            return squareAvoidanceRadius;
        }
    }

    void Start()
    {
        
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);

        }

        //NEW STUFF

        //StartCoroutine("GetNearbyeObjects", .2f);


        //NEW STUFF

        //lastPos = transform.eulerAngles;
        //NewAngle();
    }

    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyeObjects(agent);

            

            Vector2 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }

        //transform.eulerAngles = Vector3.Lerp(lastPos, newPos, t);
        //t += 0.01f;
        //if (t > 1)
        //    NewAngle();
    }

    //List<Transform> GetNearbyeObjects(FlockAgent agent)
    //{

    //    Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(agent.transform.position, viewRadius);
    //    List<Transform> context = new List<Transform>();

    //    foreach (Collider2D c in targetsInViewRadius)
    //    {
    //        for (int i = 0; i < targetsInViewRadius.Length; i++)
    //        {
    //            Transform target = targetsInViewRadius[i].transform;
    //            Vector3 dirToTarget = (target.position - transform.position).normalized;
    //            if (Vector3.Angle(transform.up, dirToTarget) < viewAngle / 2)
    //            {
    //                float disToTarget = Vector3.Distance(transform.position, agent.transform.position);
    //                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget))
    //                {
                        
                        
    //                     context.Add(c.transform);
                        
    //                }
    //            }
    //        }
    //    }
    //    return context;
    //}

	List<Transform> GetNearbyeObjects(FlockAgent agent)
	{
	    List<Transform> context = new List<Transform>();
	    Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
	    foreach (Collider2D c in contextColliders)
	    {
	        if (c != agent.AgentCollider)
	        {
	            context.Add(c.transform);
	        }
	    }
	    return context;
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
