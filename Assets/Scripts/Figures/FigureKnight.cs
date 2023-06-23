using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureKnight : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;

		if (targetPos.x == position.x - 1)
		{
			if (targetPos.y == position.y - 2) return true;
			if (targetPos.y == position.y + 2) return true;
		}
		if (targetPos.x == position.x + 1)
		{
			if (targetPos.y == position.y - 2) return true;
			if (targetPos.y == position.y + 2) return true;
		}
		if (targetPos.x == position.x - 2)
		{
			if (targetPos.y == position.y - 1) return true;
			if (targetPos.y == position.y + 1) return true;
		}
		if (targetPos.x == position.x + 2)
		{
			if (targetPos.y == position.y - 1) return true;
			if (targetPos.y == position.y + 1) return true;
		}

		return false;
	}
}
