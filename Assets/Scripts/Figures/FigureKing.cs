using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureKing : ChessFigure
{
	public override bool TryMove(Vector2Int targetPos)
	{
		if (!base.TryMove(targetPos)) return false;
		if (this.TryKick(targetPos)) return true;

		// Ракировка
		if (isFirstMove)
		{
			if (value > 0)
			{
				if (targetPos.y == position.y && targetPos.x == 1)
				{
					ChessFigure chf = GameManager.chessMap[0, targetPos.y];
					if (chf != null && chf.value == 2 && chf.isFirstMove)
						if (GameManager.chessMap[1, targetPos.y] == null && GameManager.chessMap[2, targetPos.y] == null && GameManager.chessMap[3, targetPos.y] == null)
						{
							//chf.Move(new Vector2Int(2, targetPos.y));
							return true;
						}
				}

				if (targetPos.y == position.y && targetPos.x == 6)
				{
					ChessFigure chf = GameManager.chessMap[7, targetPos.y];
					if (chf != null && chf.value == 2 && chf.isFirstMove)
						if (GameManager.chessMap[5, targetPos.y] == null && GameManager.chessMap[6, targetPos.y] == null)
						{
							//chf.Move(new Vector2Int(5, targetPos.y));
							return true;
						}
				}
			}
			if (value < 0)
			{
				if (targetPos.y == position.y && targetPos.x == 1)
				{
					ChessFigure chf = GameManager.chessMap[0, targetPos.y];
					if (chf != null && chf.value == -2 && chf.isFirstMove)
						if (GameManager.chessMap[1, targetPos.y] == null && GameManager.chessMap[2, targetPos.y] == null && GameManager.chessMap[1, targetPos.y] == null)
							return true;
				}

				if (targetPos.y == position.y && targetPos.x == 6)
				{
					ChessFigure chf = GameManager.chessMap[7, targetPos.y];
					if (chf != null && chf.value == -2 && chf.isFirstMove)
						if (GameManager.chessMap[5, targetPos.y] == null && GameManager.chessMap[6, targetPos.y] == null)
							return true;
				}
			}
		}
		if (Mathf.Abs(targetPos.x - position.x) > 1 || Mathf.Abs(targetPos.y - position.y) > 1 || GameManager.chessMap[targetPos.x, targetPos.y] != null) return false;

		return true;
	}

	public override bool TryKick(Vector2Int targetPos)
	{
		if(!base.TryKick(targetPos)) return false;

		if (Mathf.Abs(targetPos.x - position.x) <= 1 && Mathf.Abs(targetPos.y - position.y) <= 1)
		{
			if(GameManager.chessMap[targetPos.x, targetPos.y] != null)
			{
				if (GameManager.chessMap[targetPos.x, targetPos.y].value < 0 && this.value > 0) 
					return true;

				if (GameManager.chessMap[targetPos.x, targetPos.y].value > 0 && this.value < 0)
					return true;
			}
		}

		return false;
	}

	public override void Move(Vector2Int targetPos)
	{
		if (targetPos.y == position.y && targetPos.x == 1)
		{
			GameManager.chessMap[0, targetPos.y].GetComponent<RectTransform>().anchoredPosition = new Vector2((2 - 3.5f) * 108, (targetPos.y - 3.5f) * 108);
			
			GameManager.chessMap[3, targetPos.y] = GameManager.chessMap[0, targetPos.y];
			GameManager.chessMap[0, targetPos.y] = null;

			GameManager.chessMap[3, targetPos.y].position = new Vector2Int(3, targetPos.y);
			GameManager.chessMap[3, targetPos.y].isFirstMove = false;
		}

		if (targetPos.y == position.y && targetPos.x == 6)
		{
			GameManager.chessMap[7, targetPos.y].GetComponent<RectTransform>().anchoredPosition = new Vector2((5 - 3.5f) * 108, (targetPos.y - 3.5f) * 108);

			GameManager.chessMap[5, targetPos.y] = GameManager.chessMap[7, targetPos.y];
			GameManager.chessMap[7, targetPos.y] = null;

			GameManager.chessMap[5, targetPos.y].position = new Vector2Int(5, targetPos.y);
			GameManager.chessMap[5, targetPos.y].isFirstMove = false;
		}

		base.Move(targetPos);
	}
}
