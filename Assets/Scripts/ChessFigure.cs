using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessFigure : MonoBehaviour
{
	public Vector2Int position;
	public int value;

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
		return true;
	}

	public virtual void Move(Vector2Int targetPos)
	{
		GameManager.figuresMap[targetPos.x, targetPos.y] = this;
		GameManager.figuresMap[position.x, position.y] = null;
		position = targetPos;
	}
}
