using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessFigure : MonoBehaviour
{
	public Vector2Int position;
	public Image iconFigure;
	public int value;
	public bool selected, isAbleMove = true;

	protected UGameManager GameManager;

	private void Awake()
	{
		GameManager = GameObject.Find("GameManager").GetComponent<UGameManager>();
		iconFigure = GetComponent<Image>();
	}

	public void SetAbleMove(bool value)
	{
		isAbleMove = value;
		iconFigure.raycastTarget = value;
	}

	public virtual bool TryMove(Vector2Int targetPos)
	{
		if (!isAbleMove) return false;
		if (targetPos == position) return false;
		if (targetPos.x < 0 || targetPos.x > 7 ||
			targetPos.y < 0 || targetPos.y > 7) return false;

		return true;
	}

	public virtual void Move(Vector2Int targetPos)
	{
		if (TryKick(targetPos)) Kick(targetPos);

		GameManager.chessMap[targetPos.x, targetPos.y] = this;
		GameManager.chessMap[position.x, position.y] = null;
		GameManager.NextMove();

		position = targetPos;
	}

	public virtual bool TryKick(Vector2Int targetPos)
	{
		//Debug.Log("Try Kick " + targetPos);
		if (GameManager.chessMap[targetPos.x, targetPos.y] == null) return false;
		Debug.Log("Target Pos isn't empty");
		if (this.value > 0 && GameManager.chessMap[targetPos.x, targetPos.y].value >= 0) return false;
		if (this.value < 0 && GameManager.chessMap[targetPos.x, targetPos.y].value <= 0) return false;
		Debug.Log("On Target Pos is Enemy " + targetPos);
		return true;
	}

	public virtual void Kick(Vector2Int targetPos)
	{
		Debug.Log("Kick " + GameManager.chessMap[targetPos.x, targetPos.y].value);
		if (GameManager.chessMap[targetPos.x, targetPos.y].value > 0) GameManager.whiteChessFigures.Remove(GameManager.chessMap[targetPos.x, targetPos.y]);
		if (GameManager.chessMap[targetPos.x, targetPos.y].value < 0) GameManager.blackChessFigures.Remove(GameManager.chessMap[targetPos.x, targetPos.y]);
		Destroy(GameManager.chessMap[targetPos.x, targetPos.y].gameObject);
		//GameManager.chessMap[targetPos.x, targetPos.y] = null;
	}
}
