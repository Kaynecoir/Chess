using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurePawn : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (this.TryKick(targetPos)) return true;

		// Усовие для белых
		if (targetPos.y == position.y + 1 && value > 0)
			// Движение вперёд
			if (targetPos.x == position.x && GameManager.chessMap[targetPos.x, targetPos.y] == null) return true;

		if (targetPos.y == position.y + 2 && targetPos.x == position.x && value > 0)
			if (GameManager.chessMap[position.x, position.y + 1] == null && GameManager.chessMap[position.x, position.y + 2] == null)
				if (isFirstMove)
					return true;

		// Усовие для чёрных
		if (targetPos.y == position.y - 1 && value < 0)
			// Движение вперёд
			if (targetPos.x == position.x && GameManager.chessMap[targetPos.x, targetPos.y] == null) return true;

		if (targetPos.y == position.y - 2 && targetPos.x == position.x && value < 0)
			if (GameManager.chessMap[position.x, position.y - 1] == null && GameManager.chessMap[position.x, position.y - 2] == null)
				if (isFirstMove)
					return true;

		return false;
	}

	public override bool TryKick(Vector2Int targetPos)
	{
		if(!base.TryKick(targetPos)) return false;

		// Атака по искоси
		if (targetPos.y == position.y + 1 && value > 0)
			if (Mathf.Abs(targetPos.x - position.x) == 1 && GameManager.chessMap[targetPos.x, targetPos.y] != null && GameManager.chessMap[targetPos.x, targetPos.y].value < 0)
				return true;
		if (targetPos.y == position.y - 1 && value < 0)
			if (Mathf.Abs(targetPos.x - position.x) == 1 && GameManager.chessMap[targetPos.x, targetPos.y] != null && GameManager.chessMap[targetPos.x, targetPos.y].value > 0)
				return true;
		return false;
	}
	public override void Move(Vector2Int targetPos)
	{
		base.Move(targetPos);
	}
}
