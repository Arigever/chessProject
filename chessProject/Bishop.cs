using chessProject;
using System;
using System.Drawing;

public class Bishop : Piece
{
    public Bishop(bool isWhite, ulong startingBitBoard, string imagePath, int score)
        : base(isWhite, startingBitBoard, imagePath, score)
    {
    }

    public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
    {
        ulong legalMoves = 0;
        ulong bishopPosition = bitBoard;

        // מסכות לקצוות הלוח
        ulong notA = 0xFEFEFEFEFEFEFEFE;
        ulong notH = 0x7F7F7F7F7F7F7F7F;

        // אלכסון ימין-למעלה
        for (int i = 7; i < 64; i += 7)
        {
            ulong move = bishopPosition << i;
            if ((bishopPosition & notA) == 0) break;
            legalMoves |= move & notA;
            if ((move & allPieces) != 0) break;
            bishopPosition <<= 7;
        }

        bishopPosition = bitBoard;
        // אלכסון שמאל-למעלה
        for (int i = 9; i < 64; i += 9)
        {
            ulong move = bishopPosition << i;
            if ((bishopPosition & notH) == 0) break;
            legalMoves |= move & notH;
            if ((move & allPieces) != 0) break;
            bishopPosition <<= 9;
        }

        bishopPosition = bitBoard;
        // אלכסון ימין-למטה
        for (int i = 9; i < 64; i += 9)
        {
            ulong move = bishopPosition >> i;
            if ((bishopPosition & notA) == 0) break;
            legalMoves |= move & notA;
            if ((move & allPieces) != 0) break;
            bishopPosition >>= 9;
        }

        bishopPosition = bitBoard;
        // אלכסון שמאל-למטה
        for (int i = 7; i < 64; i += 7)
        {
            ulong move = bishopPosition >> i;
            if ((bishopPosition & notH) == 0) break;
            legalMoves |= move & notH;
            if ((move & allPieces) != 0) break;
            bishopPosition >>= 7;
        }

        // הסרת מהלכים שמתנגשים עם כלים של אותו שחקן
        legalMoves &= ~(allPieces ^ opponentPieces);

        return legalMoves;
    }

}

