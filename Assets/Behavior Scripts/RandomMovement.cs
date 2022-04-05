using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Randomness")]
public class RandomMovement : FlockBehavior
{
    [SerializeField] [Range(0f, 5f)] float lerpTime;

	public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
	{
		//if no neighbors, maintain current alignment
		if (context.Count == 0)
			return agent.transform.up;

		//add all points together and average
		Vector2 alignmentMove = Vector2.zero;
		foreach (Transform item in context)
		{
			alignmentMove += (Vector2)item.transform.up*Random.Range(-100,100);
		}
		alignmentMove /= context.Count;

		return alignmentMove;
	}

}
