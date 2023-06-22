using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGameManager : MonoBehaviour
{
	public ChessFigure[,] figuresMap = new ChessFigure[8, 8];
	public GameObject figureWhitePawn, figureWhiteRook, figureWhiteKnight, figureWhiteBishop, figureWhiteQueen, figureWhiteKing,
					figureBlackPawn, figureBlackRook, figureBlackKnight, figureBlackBishop, figureBlackQueen, figureBlackKing;
	public GameObject figuresCollection;

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

	private void Awake()
	{
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
				}
			}
		}
	}
}
