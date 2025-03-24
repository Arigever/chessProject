using chessProject;
using System;
using System.Drawing;

public class Rook : Piece
{
    public Rook(bool isWhite, ulong startingBitBoard, string imagePath, int score)
        : base(isWhite, startingBitBoard, imagePath, score)
    {
    }

    public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
    {
        ulong legalMoves = 0;
        ulong rookPosition = bitBoard;

        // מהלכים אנכיים למעלה
        for (int i = 8; i < 64; i += 8)
        {
            ulong move = rookPosition << i;
            legalMoves |= move;
            if ((move & allPieces) != 0) break;
        }

        // מהלכים אנכיים למטה
        for (int i = 8; i < 64; i += 8)
        {
            ulong move = rookPosition >> i;
            legalMoves |= move;
            if ((move & allPieces) != 0) break;
        }

        // מהלכים אופקיים שמאלה
        for (int i = 1; i < 8; i++)
        {
            if ((rookPosition & (1UL << (i * 8 - 1))) != 0) break;
            ulong move = rookPosition << i;
            legalMoves |= move;
            if ((move & allPieces) != 0) break;
        }

        // מהלכים אופקיים ימינה
        for (int i = 1; i < 8; i++)
        {
            if ((rookPosition & (1UL << (i * 8))) != 0) break;
            ulong move = rookPosition >> i;
            legalMoves |= move;
            if ((move & allPieces) != 0) break;
        }

        // הסרת מהלכים שמתנגשים עם כלים של אותו שחקן
        legalMoves &= ~(allPieces ^ opponentPieces);

        return legalMoves;
    }

}

