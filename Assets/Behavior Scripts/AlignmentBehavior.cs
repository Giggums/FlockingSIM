using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
	Vector2 m_NewPosition;
	public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
	{
		m_NewPosition = new Vector2(Random.Range(0,1f), Random.Range(0, 1f));
		//if no neighbors, maintain current alignment
		if (context.Count == 0)
			return agent.transform.up;

		//add all points together and average
		Vector2 alignmentMove = Vector2.zero;
		foreach (Transform item in context)
		{
			alignmentMove += (Vector2)item.transform.up; //+ m_NewPosition;
		}
		alignmentMove /= context.Count;

		return alignmentMove;
	}
}
