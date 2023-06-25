using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureKnight : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (this.TryKick(targetPos)) return true;

		if (GameManager.chessMap[targetPos.x, targetPos.y] != null)
		{
			if (GameManager.chessMap[targetPos.x, targetPos.y].value > 0 && this.value > 0) return false;
			if (GameManager.chessMap[targetPos.x, targetPos.y].value < 0 && this.value < 0) return false;
		}

		if (Mathf.Abs(targetPos.x - position.x) == 1)
			if (Mathf.Abs(targetPos.y - position.y) == 2) 
				return true;

		if (Mathf.Abs(targetPos.y - position.y) == 1)
			if (Mathf.Abs(targetPos.x - position.x) == 2) 
				return true;

		return false;
	}

	public override bool TryKick(Vector2Int targetPos)
	{
		if (!base.TryKick(targetPos)) return false;

		if (Mathf.Abs(targetPos.x - position.x) == 1)
			if (Mathf.Abs(targetPos.y - position.y) == 2)
				return true;

		if (Mathf.Abs(targetPos.y - position.y) == 1)
			if (Mathf.Abs(targetPos.x - position.x) == 2)
				return true;

		return false;
	}
}
