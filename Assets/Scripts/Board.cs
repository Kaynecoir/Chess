using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
	List<ChessFigure> whiteFigures, blackFigures;
	int[,] startBoard =
	{
		{ -2, -3, -4, -5, -6, -4, -3, -2 },
		{ -1, -1, -1, -1, -1, -1, -1, -1 },
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  1,  1,  1,  1,  1,  1,  1,  1 },
		{  2,  3,  4,  5,  6,  4,  3,  2 },
	};
	int[,] testBoard =
{
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0, -1,  0,  0,  0,},
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0,  0, -1,  0,  0,},
		{  0,  0,  1,  0,  0,  0,  0,  0,},
		{  0,  0,  0,  0,  0,  0,  1,  0,},
		{  0,  0,  0,  0,  0,  0,  0,  0,},
	};
	ChessFigure[,] _board = new ChessFigure[8, 8];

	public Board(int[,] intBoard)
	{
		whiteFigures = new List<ChessFigure>();
		blackFigures = new List<ChessFigure>();
		for (int y = 0; y < 8; y++)
		{
			for (int x = y % 2; x < 8; x += 2)
			{
				if (intBoard[y, x] > 0)
				{
					_board[y, x] = new ChessFigure();
					whiteFigures.Add(_board[y, x]);
				}
				else if (intBoard[y, x] < 0)
				{
					_board[y, x] = new ChessFigure();
					blackFigures.Add(_board[y, x]);
				}
			}
		}
		Debug.Log(whiteFigures.Count);
		Debug.Log(blackFigures.Count);
	}
}
