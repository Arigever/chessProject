using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace chessProject
{
    public partial class gamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateChessBoard();
            }
        }

        private void GenerateChessBoard()
        {
            List<string> board = new List<string>(new string[64]); // לוח 8x8, 64 משבצות
            Board c1 = new Board();

            // מיפוי כל אחד מהביטבורדים והצבת הכלים על הלוח
            SetPiecesOnBoard(c1.GetWhitePawns(), board);
            SetPiecesOnBoard(c1.GetBlackPawns(), board);
            SetPiecesOnBoard(c1.GetWhiteRooks(), board);
            SetPiecesOnBoard(c1.GetBlackRooks(), board);
            SetPiecesOnBoard(c1.GetWhiteKnights(), board);
            SetPiecesOnBoard(c1.GetBlackKnights(), board);
            SetPiecesOnBoard(c1.GetWhiteBishops(), board);
            SetPiecesOnBoard(c1.GetBlackBishops(), board);
            SetPiecesOnBoard(c1.GetWhiteQueen(), board);
            SetPiecesOnBoard(c1.GetBlackQueen(), board);
            SetPiecesOnBoard(c1.GetWhiteKing(), board);
            SetPiecesOnBoard(c1.GetBlackKing(), board);

            ChessBoardRepeater.DataSource = board;
            ChessBoardRepeater.DataBind();
        }

        // פונקציה שמביאה את הכלים לפי האובייקט וממפה אותם ללוח
        private void SetPiecesOnBoard(Piece piece, List<string> board)
        {
            ulong bitboard = piece.GetBitBoard(); // ביטבורד של הכלי
            string pieceImage = piece.GetImage(); // תמונה של הכלי

            for (int i = 0; i < 64; i++)
            {
                if ((bitboard & (1UL << i)) != 0) // אם יש כלי במיקום הזה
                {
                    board[i] = pieceImage; // מגדירים את התמונה המתאימה
                }
            }
        }
    }
}
