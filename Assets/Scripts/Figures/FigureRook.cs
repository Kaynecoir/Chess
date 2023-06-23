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
			Debug.Log("1");
			if (targetPos.y > position.y)	for (int i = position.y + 1; i < targetPos.y; i++)	if (GameManager.chessMap[position.x, i] != null) return false;
			if (targetPos.y < position.y)	for (int i = position.y - 1; i > targetPos.y; i--)	if (GameManager.chessMap[position.x, i] != null) return false;
		}
		if (targetPos.y == position.y)
		{
			if (targetPos.x > position.x) for (int i = position.x + 1; i < targetPos.x; i++) if (GameManager.chessMap[i, position.y] != null) return false;
			if (targetPos.x < position.x) for (int i = position.x - 1; i > targetPos.x; i--) if (GameManager.chessMap[i, position.y] != null) return false;
		}
		Debug.Log("e");

		return true;
	}
}
