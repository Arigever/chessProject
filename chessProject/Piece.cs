using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace chessProject
{
    public abstract class Piece
    {
        protected bool isWhite;
        protected ulong bitBoard;
        protected string pieceImage;
        protected int score; //כמה החייל שנאכל שווה

        public Piece(bool isWhite, ulong bitBoard, string pieceImage, int score)
        {
            this.isWhite = isWhite;
            this.bitBoard = bitBoard;
            this.pieceImage = pieceImage;
            this.score = score;
        }
        public bool GetIsWhite() { return this.isWhite; }
        public ulong GetBitBoard() { return this.bitBoard; }
        public void SetBitBoard(ulong newPosition)
        {
            this.bitBoard = newPosition;
        }
        public string GetImage()
        {
            return this.pieceImage;
        }
        public int GetScore() { return this.score; }
        public abstract ulong GetLegalMoves(ulong allPieces, ulong opponentPieces);

    }
}