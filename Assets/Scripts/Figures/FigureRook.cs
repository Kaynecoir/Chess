using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureRook : ChessFigure
{
	bool firstMove = true;
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;

		if (targetPos.x == position.x)
		{
			//Debug.Log("Moving for Y line");
			if (targetPos.y > position.y)
			{
				//Debug.Log("Moving for Y+");
				for (int j = position.y + 1; j <= targetPos.y; j++)
				{
					if (GameManager.chessMap[position.x, j] != null)
					{
						//Debug.Log("Pos " + position.x + ", " + j + GameManager.chessMap[position.x, j].value);
						return false;
					}
					//Debug.Log("Pos " + position.x + ", " + j + " is empty");
				}
			}

			if (targetPos.y < position.y)
			{
				//Debug.Log("Moving for Y-");
				for (int j = position.y - 1; j >= targetPos.y; j--)
				{
					if (GameManager.chessMap[position.x, j] != null)
					{
						//Debug.Log("Pos " + position.x + ", " + j + GameManager.chessMap[position.x, j].value);
						return false;
					}
					//Debug.Log("Pos " + position.x + ", " + j + " is empty");
				}
			}
		}
		if (targetPos.y == position.y)
		{
			//Debug.Log("Moving for X line");
			if (targetPos.x > position.x)
			{
				//Debug.Log("Moving for X+");
				for (int i = position.x + 1; i <= targetPos.x; i++)
				{
					if (GameManager.chessMap[i, position.y] != null)
					{
						//Debug.Log("Pos " + i + ", " + position.y + " is " + GameManager.chessMap[i, position.y].value);
						return false;
					}
					//Debug.Log("Pos " + i + ", " + position.y + " is empty");
				}
			}
			if (targetPos.x < position.x)
			{
				//Debug.Log("Moving for X-");
				for (int i = position.x - 1; i >= targetPos.x; i--)
				{
					if (GameManager.chessMap[i, position.y] != null)
					{
						//Debug.Log("Pos " + i + ", " + position.y + " is " + GameManager.chessMap[i, position.y].value);
						return false;
					}
					//Debug.Log("Pos " + i + ", " + position.y + " is empty");
				}
			}
		}
		if (targetPos.x != position.x && targetPos.y != position.y)
		{
			//Debug.Log("Uncorrect target pos");
			return false;
		}

		return true;
	}
}
