using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureKing : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (Mathf.Abs(targetPos.x - position.x) > 1 || Mathf.Abs(targetPos.y - position.y) > 1) return false;

		return true;
	}
}
