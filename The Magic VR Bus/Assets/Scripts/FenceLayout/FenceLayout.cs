using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Executes the script in unity editor
[ExecuteInEditMode]
public class FenceLayout : MonoBehaviour
{
	public List<Vector3> FencePoints = new List<Vector3>();
	public Transform[] FencePrefabs = new Transform[1];
	public Transform PostPrefab;
	public Vector3 FenceEndOffset = new Vector3();
	public float FenceRotation = 0.0f;
	public float FenceLength = 2.0f;
	public Vector3 FenceScale = new Vector3(1, 1, 1);
	public bool CompleteLoop = false;
	public bool ObjectMode = false;
	public Vector2 PositionVariation = new Vector2(0, 0);
	public Vector2 RotationVariation = new Vector2(-180, 180);
	public Vector2 ScaleVariation = new Vector2(1, 1);
	public bool UseShear = true;
	public bool UseRaycast = false;
	public float RaycastOffsetMax = 1.0f;
	public float RaycastOffsetMin = -1.0f;
	// Default value is set to ignore the IgnoreRaycast layer
	public int LayerMask = ~(1<<2);


	// enum to track editor mode while in unity editor
	public enum EditMode
	{
		None,
		Add,
		Delete
	};
	private EditMode m_currentEditMode = EditMode.None;
	private Vector3 m_mousePos;

	// Method draws objects to represent positions for point placements

	private void OnDrawGizmosSelected()
	{
		Vector3 lastPos = new Vector3();
		bool gotLast = false;

		int deleteIdx = m_currentEditMode == EditMode.Delete ? GetDeletePointIdx() : -1;

		for (int i = 0; i < FencePoints.Count; i++)
		{
			Vector3 p = FencePoints[i] + transform.position;

			if (m_currentEditMode == EditMode.Delete && i == deleteIdx)
			{
				Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
				Gizmos.DrawSphere(p, 0.5f);
			}
			else
			{
				Gizmos.color = m_currentEditMode == EditMode.Add ? new Color(1.0f, 1.0f, 1.0f) : new Color(0.2f, 1.0f, 0.2f);
				Gizmos.DrawSphere(p, 0.3f);
			}

			if (gotLast)
			{
				Gizmos.color = new Color(0.2f, 1.0f, 0.2f);
				Gizmos.DrawLine(lastPos, p);
			}

			lastPos = p;
			gotLast = true;
		}

		if (m_currentEditMode == EditMode.Add)
		{
			Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
			Gizmos.DrawSphere(m_mousePos, 0.3f);

			Gizmos.color = new Color(1.0f, 1.0f, 0.0f);
			if (FencePoints.Count > 0)
			{
				int addIdx = GetAddPointIdx();

				if (addIdx > 0)
				{
					Gizmos.DrawLine(m_mousePos, FencePoints[addIdx - 1] + transform.position);
				}
				if (addIdx < FencePoints.Count)
				{

					Gizmos.DrawLine(m_mousePos, FencePoints[addIdx] + transform.position);
				}
			}
		}
	}

	// Enables edit mode script to run

	public void SetEditMode(EditMode mode, Vector3 mousePos)
	{
		m_currentEditMode = mode;
		m_mousePos = mousePos;
	}

	// Creates/adds a point to the scene from mouse position

	public int GetAddPointIdx()
	{
		// Selects first 2 points on the maze
		if (FencePoints.Count == 0)
		{
			return 0;
		}
		else if (FencePoints.Count == 1)
		{
			return 1;
		}
		else
		{
			Vector3 addPos = m_mousePos - transform.position;

			// Finds the closest point
			int closestIdx = 0;
			float closestDist = float.MaxValue;
			for (int i = 0; i < FencePoints.Count; i++)
			{
				float dist = (FencePoints[i] - addPos).sqrMagnitude;

				if (dist < closestDist)
				{
					closestIdx = i;
					closestDist = dist;
				}
			}

			// Checks which side the point should join on
			if (closestIdx == 0)
			{
				if (Vector3.Dot(addPos - FencePoints[0], FencePoints[1] - FencePoints[0]) > 0)
				{
					// Selects direction of second point
					return 1;
				}
				return 0;
			}
			else if (closestIdx == FencePoints.Count - 1)
			{
				if (Vector3.Dot(addPos - FencePoints[FencePoints.Count - 1], FencePoints[FencePoints.Count - 2] - FencePoints[FencePoints.Count - 1]) > 0)
				{
					// Selects direction of previous point
					return FencePoints.Count - 1;
				}
				return FencePoints.Count;
			}
			else
			{
				Vector3 dirPrev = (FencePoints[closestIdx - 1] - FencePoints[closestIdx]).normalized;
				Vector3 dirNext = (FencePoints[closestIdx + 1] - FencePoints[closestIdx]).normalized;
				Vector3 dirThis = (addPos - FencePoints[closestIdx]).normalized;

				if (Vector3.Dot(dirThis, dirPrev) > Vector3.Dot(dirThis, dirNext))
				{
					// Selects direction of previous point
					return closestIdx;
				}
				return closestIdx + 1;
			}
		}
	}

	// Deletes closest point from selected mouse position

	public int GetDeletePointIdx()
	{
		Vector3 addPos = m_mousePos - transform.position;

		// Finds closest point to delete within parameters
		int closestIdx = -1;
		float closestDist = 10.0f;
		for (int i = 0; i < FencePoints.Count; i++)
		{
			float dist = (FencePoints[i] - addPos).sqrMagnitude;

			if (dist < closestDist)
			{
				closestIdx = i;
				closestDist = dist;
			}
		}

		return closestIdx;
	}
}
