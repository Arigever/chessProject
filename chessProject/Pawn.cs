using System;
using System.Drawing;

namespace chessProject
{
    public class Pawn : Piece
    {
        // קונסטרוקטור של Pawn
        public Pawn(bool isWhite, ulong startingBitBoard, string imagePath, int score)
            : base(isWhite, startingBitBoard, imagePath, score)
        {
        }

        // החזרת המהלכים החוקיים של הרגלי
        public override ulong GetLegalMoves(ulong allPieces, ulong opponentPieces)
        {
            ulong legalMoves = 0;
            ulong oneSquareMove = 0;
            ulong twoSquareMove = 0;
            ulong leftCapture = 0;
            ulong rightCapture = 0;

            if (isWhite)
            {
                // תנועת רגלי לבן 1 ריבוע קדימה
                ulong moveOne = bitBoard >> 8;
                if ((moveOne & allPieces) == 0) // אם הריבוע פנוי
                {
                    oneSquareMove = moveOne;
                }

                // תנועת רגלי לבן 2 ריבועים קדימה (רק מהשורה השנייה)
                if ((bitBoard & 0x000000000000FF00) != 0) // רגלי נמצא בשורה השנייה
                {
                    ulong moveTwo = bitBoard >> 16;
                    if ((moveOne & allPieces) == 0 && (moveTwo & allPieces) == 0) // שני הריבועים פנויים
                    {
                        twoSquareMove = moveTwo;
                    }
                }

                // תפיסה אלכסונית שמאלה
                ulong moveLeft = bitBoard >> 9;
                if ((moveLeft & opponentPieces) != 0 && (bitBoard & 0x0101010101010101) == 0) // אם יש כלי יריב ולא חוצה גבול
                {
                    leftCapture = moveLeft;
                }

                // תפיסה אלכסונית ימינה
                ulong moveRight = bitBoard >> 7;
                if ((moveRight & opponentPieces) != 0 && (bitBoard & 0x8080808080808080) == 0) // אם יש כלי יריב ולא חוצה גבול
                {
                    rightCapture = moveRight;
                }
            }
            else
            {
                // תנועת רגלי שחור 1 ריבוע קדימה
                ulong moveOne = bitBoard << 8;
                if ((moveOne & allPieces) == 0) // אם הריבוע פנוי
                {
                    oneSquareMove = moveOne;
                }

                // תנועת רגלי שחור 2 ריבועים קדימה (רק מהשורה השביעית)
                if ((bitBoard & 0x00FF000000000000) != 0) // רגלי נמצא בשורה השביעית
                {
                    ulong moveTwo = bitBoard << 16;
                    if ((moveOne & allPieces) == 0 && (moveTwo & allPieces) == 0) // שני הריבועים פנויים
                    {
                        twoSquareMove = moveTwo;
                    }
                }

                // תפיסה אלכסונית שמאלה
                ulong moveLeft = bitBoard << 7;
                if ((moveLeft & opponentPieces) != 0 && (bitBoard & 0x0101010101010101) == 0) // אם יש כלי יריב ולא חוצה גבול
                {
                    leftCapture = moveLeft;
                }

                // תפיסה אלכסונית ימינה
                ulong moveRight = bitBoard << 9;
                if ((moveRight & opponentPieces) != 0 && (bitBoard & 0x8080808080808080) == 0) // אם יש כלי יריב ולא חוצה גבול
                {
                    rightCapture = moveRight;
                }
            }

            legalMoves = oneSquareMove | twoSquareMove | leftCapture | rightCapture;
            return legalMoves;
        }


    }
}
