using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ChessPieceLogic
{
    public Rock(int x, int y, bool is_white) : base(x, y, is_white){}
    public Rock(int x, int y, bool is_white, bool has_moved) : base(x, y, is_white, has_moved) { }

    public override bool[,] GetMoves(GameState gameState, bool isRecursive)
    {
        bool[,] possibleMoves = new bool[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

        int[,] scale = { {0, 1}, {0, -1}, { 1, 0}, { -1, 0 }};

        for(int i=0; i<scale.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                bool success = ActivateCell(possibleMoves, x + j * scale[i, 0], y + j * scale[i, 1], gameState, isRecursive);
                if (!success)
                {
                    break;
                }
            }
        }

        return possibleMoves;
    }

    public override ChessPieceLogic Clone()
    {
        return new Rock(x, y, is_white, has_moved);
    }
}
