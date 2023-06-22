using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurePawn : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		// Усовие для белых
		if (targetPos.y - 1 == position.y && value > 0)
		{
			// Движение вперёд
			if (targetPos.x == position.x && GameManager.figuresMap[targetPos.x, targetPos.y] == null) return true;
			// Атака по искоси
			if ((targetPos.x - 1 == position.x || targetPos.x + 1 == position.x) && GameManager.figuresMap[targetPos.x, targetPos.y].value < 0) return true;
		}
		if (targetPos.y + 1 == position.y && value < 0)
		{
			if (targetPos.x == position.x && GameManager.figuresMap[targetPos.x, targetPos.y] == null) return true;
			if ((targetPos.x - 1 == position.x || targetPos.x + 1 == position.x) && GameManager.figuresMap[targetPos.x, targetPos.y].value > 0) return true;
		}

		return false;
	}
}
