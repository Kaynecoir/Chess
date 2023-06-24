using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGameManager : MonoBehaviour
{
	public ChessFigure[,] chessMap = new ChessFigure[8, 8];
	public GameObject figureWhitePawn, figureWhiteRook, figureWhiteKnight, figureWhiteBishop, figureWhiteQueen, figureWhiteKing,
					figureBlackPawn, figureBlackRook, figureBlackKnight, figureBlackBishop, figureBlackQueen, figureBlackKing;
	public GameObject figuresCollection;
	public ChessFigure selectedFig;

	private bool isWhiteMove = false;
	private List<ChessFigure> whiteChessFigures, blackChessFigures;

	private int[,] firstPosition =
	{
		{ 2, 3, 4, 5, 6, 4, 3, 2 },
		{ 1, 1, 1, 1, 1, 1, 1, 1 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{-1,-1,-1,-1,-1,-1,-1,-1 },
		{-2,-3,-4,-5,-6,-4,-3,-2 }
	};
	//	TEST MAP
	//{
	//	{ 0, 0, 0, 0, 0, 0, 0, 2 },
	//	{ 0, 1, 0,-4, 0, 0, 1, 0 },
	//	{ 0, 0, 0, 0, 0, 0, 0, 0 },
	//	{ 0, 0,-3, 0, 0, 0, 0, 0 },
	//	{ 5, 0, 0, 0, 0, 0, 3, 0 },
	//	{ 0, 0, 0, 0,-1, 0, 0, 0 },
	//	{ 0,-1, 0, 0, 0, 0, 4, 0 },
	//	{-2, 0, 0,-5, 0, 0, 0, 0 }
	//};

	private void Awake()
	{
		whiteChessFigures = new List<ChessFigure>();
		blackChessFigures = new List<ChessFigure>();
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if(firstPosition[j,i] != 0)
				{
					GameObject fig = null;
					switch(firstPosition[j,i])
					{
						case -1:
							fig = figureBlackPawn;
							break;
						case -2:
							fig = figureBlackRook;
							break;
						case -3:
							fig = figureBlackKnight;
							break;
						case -4:
							fig = figureBlackBishop;
							break;
						case -5:
							fig = figureBlackQueen;
							break;
						case -6:
							fig = figureBlackKing;
							break;
						case 1:
							fig = figureWhitePawn;
							break;
						case 2:
							fig = figureWhiteRook;
							break;
						case 3:
							fig = figureWhiteKnight;
							break;
						case 4:
							fig = figureWhiteBishop;
							break;
						case 5:
							fig = figureWhiteQueen;
							break;
						case 6:
							fig = figureWhiteKing;
							break;
					}
					GameObject go = Instantiate(fig, new Vector3(i - 3.5f, j - 3.5f, 0), Quaternion.identity, figuresCollection.transform);
					ChessFigure chf = go.GetComponent<ChessFigure>();
					chf.position = new Vector2Int(i, j);
					chessMap[i, j] = chf;
					if (chf.value > 0) whiteChessFigures.Add(chf);
					else if (chf.value < 0) blackChessFigures.Add(chf);
				}
			}
		}

		NextMove();
	}

	public void NextMove()
	{
		isWhiteMove = !isWhiteMove;

		if (isWhiteMove) Debug.Log("white is move");
		else Debug.Log("Black is move");

		foreach(ChessFigure chf in whiteChessFigures)
		{
			Debug.Log(chf.value.ToString() + chf.position);
			chf.isAbleMove = isWhiteMove;
		}
		foreach(ChessFigure chf in blackChessFigures)
		{
			Debug.Log(chf.value.ToString() + chf.position);
			chf.isAbleMove = !isWhiteMove;
		}
	}

	public void SelectFigur(ChessFigure chf)
	{
		Debug.Log("Selekted: " + chf.value.ToString() + chf.position);
		selectedFig = chf;
	}
}
