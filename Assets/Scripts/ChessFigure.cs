using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessFigure : MonoBehaviour
{
	public Vector2Int position;
	public GameObject iconAbleMove;
	public int value;
	public bool selected, isAbleMove = true;

	protected UGameManager GameManager;

	private void Awake()
	{
		GameManager = GameObject.Find("GameManager").GetComponent<UGameManager>();
	}

	public virtual bool TryMove(Vector2Int targetPos)
	{
		if (targetPos.x < 0 || targetPos.x > 7 ||
			targetPos.y < 0 || targetPos.y > 7) return false;
		if (targetPos == position) return false;
		if (!isAbleMove) return false;
		return true;
	}

	public virtual void Move(Vector2Int targetPos)
	{
		GameManager.chessMap[targetPos.x, targetPos.y] = this;
		GameManager.chessMap[position.x, position.y] = null;
		GameManager.NextMove();
		position = targetPos;
	}

	public virtual bool TryKick(Vector2Int targetPos)
	{
		if (GameManager.chessMap[targetPos.x, targetPos.y] == null) return false;
		if (this.value > 0 && GameManager.chessMap[targetPos.x, targetPos.y].value >= 0) return false;
		if (this.value < 0 && GameManager.chessMap[targetPos.x, targetPos.y].value <= 0) return false;
		return true;
	}
}
