using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBishop : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (this.TryKick(targetPos)) return true;
		if (Mathf.Abs(targetPos.x - position.x) != Mathf.Abs(targetPos.y - position.y)) return false;


		if (targetPos.x - position.x > 0)
		{
			if (targetPos.y - position.y > 0)
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x + i <= 7 && position.y + i <= 7; i++)
					if (GameManager.chessMap[position.x + i, position.y + i] != null)
						return false;

				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x + i <= 7 && position.y - i >= 0; i++)
					if (GameManager.chessMap[position.x + i, position.y - i] != null)
						return false;
		}
		if (targetPos.x - position.x < 0)
		{
			if (targetPos.y - position.y > 0)
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x - i >= 0 && position.y + i <= 7; i++)
					if (GameManager.chessMap[position.x - i, position.y + i] != null)
						return false;

			if (targetPos.y - position.y < 0)
				for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x - i >= 0 && position.y - i >= 0; i++)
					if (GameManager.chessMap[position.x - i, position.y - i] != null)
						return false;
		}
		return true;
	}

	public override bool TryKick(Vector2Int targetPos)
	{
		if (!base.TryKick(targetPos)) return false;

		if (Mathf.Abs(targetPos.x - position.x) == Mathf.Abs(targetPos.y - position.y))
		{
			if (targetPos.x - position.x > 0)
			{
				if (targetPos.y - position.y > 0)
				{
					for (int i = 1; position.x + i < 7 && position.y + i < 7; i++)
						if (GameManager.chessMap[position.x + i, position.y + i] != null)
							return false;
				}
				if (targetPos.y - position.y < 0)
				{
					for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x + i < 7 && position.y - i > 0; i++)
						if (GameManager.chessMap[position.x + i, position.y - i] != null)
							return false;
				}
			}
			if (targetPos.x - position.x < 0)
			{
				if (targetPos.y - position.y > 0)
				{
					for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x - i > 0 && position.y + i < 7; i++)
						if (GameManager.chessMap[position.x - i, position.y + i] != null)
							return false;
				}
				if (targetPos.y - position.y < 0)
				{
					for (int i = 1; i <= Mathf.Abs(targetPos.x - position.x) && position.x - i > 0 && position.y - i > 0; i++)
						if (GameManager.chessMap[position.x - i, position.y - i] != null)
							return false;
				}
			}
			return true;
		}
		return false;
	}
}
