using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	private void Start()
	{
		for(int i = 0; i < 8; i++)
		{
			for(int j = 0; j < 8;j++)
			{
				Gizmos.DrawCube(transform.position + new Vector3(i, j), Vector3.one);
			}
		}
	}
}
