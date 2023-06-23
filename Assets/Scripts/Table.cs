using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Table : MonoBehaviour
{
	public Vector2Int sizeTable;
	public Vector2 sizeCube;
	public Sprite iconBlack, iconWhite;
	public GameObject icon;
	public UGameManager GM;

	[SerializeField] private Canvas canvas;
	private void Start()
	{
		
	}
	private void OnDrawGizmosSelected()
	{
		for(float i = -sizeTable.x / 2f; i < sizeTable.x / 2f; i+=1)
		{
			for(float j = -sizeTable.y / 2f; j < sizeTable.y / 2f; j+=1)
			{
				if (GM.chessMap[Mathf.RoundToInt(i + 4f), Mathf.RoundToInt(j + 4f)] != null) 
					Gizmos.color = new Color(Mathf.Abs(GM.chessMap[Mathf.RoundToInt(i + 4f), Mathf.RoundToInt(j + 4f)].value) * 40, 0, 0);
				else if (GM.chessMap[Mathf.RoundToInt(i + 4f), Mathf.RoundToInt(j + 4f)] == null)
					Gizmos.color = Color.black;
				Gizmos.DrawCube(transform.position + new Vector3(i + 0.5f, j + 0.5f), new Vector3(sizeCube.x, sizeCube.y, 1));
			}
		}
	}
	[ContextMenu("Create Table")]
	public void CreateTable()
	{
		for (float i = -sizeTable.x / 2f; i < sizeTable.x / 2f; i += 1)
		{
			for (float j = -sizeTable.y / 2f; j < sizeTable.y / 2f; j += 1)
			{
				GameObject go = Instantiate(icon, (transform.position + new Vector3(i + 0.5f, j + 0.5f)) / canvas.scaleFactor, Quaternion.identity, transform);
				go.name = "Cell [" + (i + sizeTable.x / 2).ToString() + "][" + (j + sizeTable.y / 2).ToString() + "]";
				go.GetComponent<Drop>().position = new Vector2Int((int)i + sizeTable.x / 2, (int)j + sizeTable.y / 2);
				go.GetComponentInChildren<Image>().sprite = Mathf.RoundToInt(i + j + (sizeTable.x / 2f - sizeTable.x / 2) + (sizeTable.y / 2f - sizeTable.y / 2)) % 2 == 0 ? iconBlack : iconWhite;
			}
		}
	}
}
