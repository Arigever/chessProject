using System;
using System.Drawing;  

namespace chessProject
{
    public class Pawn : Piece
    {
        // קונסטרוקטור של Pawn
        public Pawn(bool isWhite, ulong startingBitBoard, string imagePath)
            : base(isWhite, startingBitBoard, Image.FromFile(imagePath))
        {
        }

        // החזרת המהלכים החוקיים של הרגלי
        public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
        {
            ulong legalMoves = 0;
            ulong oneSquareMove;
            ulong twoSquareMove;

            if (isWhite)
            {
                // תנועת רגלי לבן 1 ריבוע קדימה
                oneSquareMove = (bitBoard >> 8) & ~allPieces;

                // תנועת רגלי לבן 2 ריבועים קדימה אם הוא עדיין לא זז
                twoSquareMove = (bitBoard >> 16) & ~allPieces;

                // המהלכים החוקיים של רגלי לבן
                legalMoves = oneSquareMove | twoSquareMove;
            }
            else
            {
                // תנועת רגלי שחור 1 ריבוע קדימה
                oneSquareMove = (bitBoard << 8) & ~allPieces;

                // תנועת רגלי שחור 2 ריבועים קדימה אם הוא עדיין לא זז
                twoSquareMove = (bitBoard << 16) & ~allPieces;

                // המהלכים החוקיים של רגלי שחור
                legalMoves = oneSquareMove | twoSquareMove;
            }

            // כאן נוכל להוסיף גם את הלוגיקה של קרבה לאויב על מנת לתפוס אותם (אם יש אויב בצדדים)
            // לדוגמה, ניתן להוסיף את הלוגיקה של תנועה לאחור בצדדים (אם יש כלי בצדדים)

            return legalMoves;
        }
    }
}
