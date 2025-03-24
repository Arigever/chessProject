using chessProject;
using System;
using System.Drawing;

public class Knight : Piece
{
    public Knight(bool isWhite, ulong startingBitBoard, string imagePath, int score)
        : base(isWhite, startingBitBoard, imagePath, score)
    {
    }

    public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
    {
        ulong legalMoves = 0;
        ulong knightPosition = bitBoard;

        // מסכות לקצוות הלוח
        ulong notA = 0xFEFEFEFEFEFEFEFE;
        ulong notAB = 0xFCFCFCFCFCFCFCFC;
        ulong notH = 0x7F7F7F7F7F7F7F7F;
        ulong notGH = 0x3F3F3F3F3F3F3F3F;

        // כל המהלכים האפשריים של הפרש
        legalMoves |= (knightPosition << 17) & notH;    // 2 למעלה, 1 ימינה
        legalMoves |= (knightPosition << 15) & notA;    // 2 למעלה, 1 שמאלה
        legalMoves |= (knightPosition << 10) & notGH;   // 1 למעלה, 2 ימינה
        legalMoves |= (knightPosition << 6) & notAB;    // 1 למעלה, 2 שמאלה
        legalMoves |= (knightPosition >> 17) & notA;    // 2 למטה, 1 שמאלה
        legalMoves |= (knightPosition >> 15) & notH;    // 2 למטה, 1 ימינה
        legalMoves |= (knightPosition >> 10) & notAB;   // 1 למטה, 2 שמאלה
        legalMoves |= (knightPosition >> 6) & notGH;    // 1 למטה, 2 ימינה

        // הסרת מהלכים שמתנגשים עם כלים של אותו שחקן
        legalMoves &= ~(allPieces ^ opponentPieces);

        return legalMoves;
    }

}

