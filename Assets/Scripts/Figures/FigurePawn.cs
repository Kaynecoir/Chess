using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurePawn : ChessFigure
{
	bool firstMove = true;
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;


		Debug.Log("Figure pos: " + position);
		Debug.Log("Target pos: " + targetPos);
		// Усовие для белых
		if (targetPos.y == position.y + 1 && value > 0)
		{
			Debug.Log("White trymove 3");
			// Движение вперёд
			if (targetPos.x == position.x && GameManager.chessMap[targetPos.x, targetPos.y] == null) return true;
			// Атака по искоси
			if ((targetPos.x == position.x + 1 || targetPos.x == position.x - 1) && GameManager.chessMap[targetPos.x, targetPos.y] != null && GameManager.chessMap[targetPos.x, targetPos.y].value < 0) return true;
		}
		if (targetPos.y == position.y + 2 && targetPos.x == position.x && value > 0)
		{
			Debug.Log("Try move to 2 step");
			if (GameManager.chessMap[position.x, position.y + 1] == null && GameManager.chessMap[position.x, position.y + 2] == null)
			{
				Debug.Log("Forward is clear");
				if (firstMove)
				{
					Debug.Log("Is first move");
					return true;
				}
			}
		}

		// Усовие для чёрных
		if (targetPos.y == position.y - 1 && value < 0)
		{
			Debug.Log("Black trymove");
			// Движение вперёд
			if (targetPos.x == position.x && GameManager.chessMap[targetPos.x, targetPos.y] == null) return true;
			// Атака по искоси
			if ((targetPos.x == position.x + 1 || targetPos.x == position.x - 1) && GameManager.chessMap[targetPos.x, targetPos.y] != null && GameManager.chessMap[targetPos.x, targetPos.y].value < 0) return true;
		}
		if (targetPos.y == position.y - 2 && targetPos.x == position.x && value < 0)
		{
			Debug.Log("Try move to 2 step");
			if (GameManager.chessMap[position.x, position.y - 1] == null && GameManager.chessMap[position.x, position.y - 2] == null)
			{
				Debug.Log("Forward is clear");
				if (firstMove)
				{
					Debug.Log("Is first move");
					return true;
				}
			}
		}

		return false;
	}

	public override void Move(Vector2Int targetPos)
	{
		firstMove = false;
		base.Move(targetPos);
	}
}
