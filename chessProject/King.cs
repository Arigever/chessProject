using chessProject;
using System;
using System.Drawing;

public class King : Piece
{
    public King(bool isWhite, ulong startingBitBoard, string imagePath, int score)
        : base(isWhite, startingBitBoard, imagePath, score)
    {
    }

    public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
    {
        // הגדרת המהלכים החוקיים של המלך
        ulong legalMoves = 0;

        // המלך יכול לזוז 1 ריבוע לכל כיוון
        // חישוב המהלכים החוקיים
        if ((bitBoard >> 8 & opponentPieces ^ allPieces) == 0) // אם הריבוע פנוי
        {
            legalMoves |= (bitBoard >> 8);
        }
        if((bitBoard << 8 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= (bitBoard << 8);
        }
        if((bitBoard >> 1 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= (bitBoard >> 1);
        }
        if ((bitBoard << 1 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= (bitBoard << 1);
        }
        if ((bitBoard >> 9 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= bitBoard >> 9;
        }
        if ((bitBoard >> 7 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= bitBoard >> 7;
        }
        if ((bitBoard << 7 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= bitBoard << 7;
        }
        if ((bitBoard << 9 & opponentPieces ^ allPieces) == 0)
        {
            legalMoves |= bitBoard << 9;
        }
        return legalMoves;
    }
}

