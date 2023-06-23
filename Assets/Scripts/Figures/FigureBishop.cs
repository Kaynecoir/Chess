using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBishop : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (Mathf.Abs(targetPos.x - position.x) != Mathf.Abs(targetPos.y - position.y)) return false;

		Debug.Log("Distanct on X and Y is ok");
		if (targetPos.x - position.x > 0)
		{
			Debug.Log("X>");
			if (targetPos.y - position.y > 0)
			{
				Debug.Log("Y>");
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x + i <= 7 && position.y + i <= 7; i++)
				{
					if (GameManager.chessMap[position.x + i, position.y + i] != null)
					{
						Debug.Log("Pos " + (position.x + i) + ", " + (position.y + i) + GameManager.chessMap[position.x + i, position.y + i].value);
						return false;
					}
					Debug.Log("Pos " + (position.x + i) + ", " + (position.y + i) + " is empty");
				}
			}
			if (targetPos.y - position.y < 0)
			{
				Debug.Log("Y<");
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x + i <= 7 && position.y - i >= 0; i++)
				{
					if (GameManager.chessMap[position.x + i, position.y - i] != null)
					{
						Debug.Log("Pos " + (position.x + i) + ", " + (position.y - i) + GameManager.chessMap[position.x + i, position.y - i].value);
						return false;
					}
					Debug.Log("Pos " + (position.x + i) + ", " + (position.y - i) + " is empty");
				}
			}
		}
		if (targetPos.x - position.x < 0)
		{
			Debug.Log("X<");
			if (targetPos.y - position.y > 0)
			{
				Debug.Log("Y>");
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x - i >= 0 && position.y + i <= 7; i++)
				{
					if (GameManager.chessMap[position.x - i, position.y + i] != null)
					{
						Debug.Log("Pos " + (position.x - i) + ", " + (position.y + i) + GameManager.chessMap[position.x - i, position.y + i].value);
						return false;
					}
					Debug.Log("Pos " + (position.x - i) + ", " + (position.y + i) + " is empty");
				}
			}
			if (targetPos.y - position.y < 0)
			{
				Debug.Log("Y<");
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x - i >= 0 && position.y - i >= 0; i++)
				{
					if (GameManager.chessMap[position.x - i, position.y - i] != null)
					{
						Debug.Log("Pos " + (position.x - i) + ", " + (position.y - i) + GameManager.chessMap[position.x - i, position.y - i].value);
						return false;
					}
					Debug.Log("Pos " + (position.x - i) + ", " + (position.y - i) + " is empty");
				}
			}
		}

		return true;
	}

}
