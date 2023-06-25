using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureRook : ChessFigure
{
	bool firstMove = true;
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (this.TryKick(targetPos)) return true;

		if (targetPos.x != position.x && targetPos.y != position.y)
		{
			return false;
		}

		if (Mathf.Abs(targetPos.x - position.x) == 0 || Mathf.Abs(targetPos.y - position.y) == 0)
		{
			if (targetPos.x == position.x)
			{
				if (targetPos.y > position.y)
					for (int j = position.y + 1; j <= targetPos.y; j++)
						if (GameManager.chessMap[position.x, j] != null)
							return false;
				if (targetPos.y < position.y)
					for (int j = position.y - 1; j >= targetPos.y; j--)
						if (GameManager.chessMap[position.x, j] != null)
							return false;
			}
			if (targetPos.y == position.y)
			{
				if (targetPos.x > position.x)
					for (int i = position.x + 1; i <= targetPos.x; i++)
						if (GameManager.chessMap[i, position.y] != null)
							return false;

				if (targetPos.x < position.x)
					for (int i = position.x - 1; i >= targetPos.x; i--)
						if (GameManager.chessMap[i, position.y] != null)
							return false;
			}
			return true;
		}

		return true;
	}

	public override bool TryKick(Vector2Int targetPos)
	{
		if (!base.TryKick(targetPos)) return false;

		if (targetPos.x != position.x && targetPos.y != position.y) return false;

		if (Mathf.Abs(targetPos.x - position.x) == 0 || Mathf.Abs(targetPos.y - position.y) == 0)
		{
			if (targetPos.x == position.x)
			{
				if (targetPos.y > position.y)
					for (int j = position.y + 1; j < targetPos.y; j++)
						if (GameManager.chessMap[position.x, j] != null)
							return false;
				if (targetPos.y < position.y)
					for (int j = position.y - 1; j > targetPos.y; j--)
						if (GameManager.chessMap[position.x, j] != null)
							return false;
			}
			if (targetPos.y == position.y)
			{
				if (targetPos.x > position.x)
					for (int i = position.x + 1; i < targetPos.x; i++)
						if (GameManager.chessMap[i, position.y] != null)
							return false;

				if (targetPos.x < position.x)
					for (int i = position.x - 1; i > targetPos.x; i--)
						if (GameManager.chessMap[i, position.y] != null)
							return false;
			}
			return true;
		}

		return false;
	}
}
