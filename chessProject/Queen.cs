using chessProject;
using System;
using System.Drawing;

public class Queen : Piece
{
    public Queen(bool isWhite, ulong startingBitBoard, string imagePath, int score)
        : base(isWhite, startingBitBoard, imagePath, score)
    {
    }

    public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
    {
        ulong legalMoves = 0;
        ulong queenPosition = bitBoard;

        // מסכות לקצוות הלוח
        ulong notA = 0xFEFEFEFEFEFEFEFE;
        ulong notH = 0x7F7F7F7F7F7F7F7F;

        // תנועות אנכיות ואופקיות (כמו רוק)
        for (int direction = 0; direction < 4; direction++)
        {
            ulong rayAttacks = 0;
            int shift = direction == 0 ? 8 : direction == 1 ? -8 : direction == 2 ? 1 : -1;
            ulong currentPosition = queenPosition;

            for (int i = 0; i < 8; i++)
            {
                if ((direction == 2 && (currentPosition & notH) == 0) ||
                    (direction == 3 && (currentPosition & notA) == 0))
                    break;

                currentPosition = direction <= 1 ? currentPosition << Math.Abs(shift) : currentPosition >> Math.Abs(shift);
                rayAttacks |= currentPosition;
                if ((currentPosition & allPieces) != 0) break;
            }
            legalMoves |= rayAttacks;
        }

        // תנועות אלכסוניות (כמו רץ)
        for (int direction = 0; direction < 4; direction++)
        {
            ulong rayAttacks = 0;
            int shift = direction == 0 ? 7 : direction == 1 ? 9 : direction == 2 ? -7 : -9;
            ulong currentPosition = queenPosition;

            for (int i = 0; i < 8; i++)
            {
                if ((direction == 0 && (currentPosition & notA) == 0) ||
                    (direction == 1 && (currentPosition & notH) == 0) ||
                    (direction == 2 && (currentPosition & notH) == 0) ||
                    (direction == 3 && (currentPosition & notA) == 0))
                    break;

                currentPosition = shift > 0 ? currentPosition << shift : currentPosition >> Math.Abs(shift);
                rayAttacks |= currentPosition;
                if ((currentPosition & allPieces) != 0) break;
            }
            legalMoves |= rayAttacks;
        }

        // הסרת מהלכים שמתנגשים עם כלים של אותו שחקן
        legalMoves &= ~(allPieces ^ opponentPieces);

        return legalMoves;
    }

}

