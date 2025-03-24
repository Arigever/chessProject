using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace chessProject
{
    public class Board
    {
        private Pawn whitePawns, blackPawns;
        private Rook whiteRooks, blackRooks;
        private Knight whiteKnights, blackKnights;
        private Bishop whiteBishops, blackBishops;
        private Queen whiteQueens, blackQueens;
        private King whiteKing, blackKing;
        private string currentPlayer; //white, black.
        private string gameState; //check, checkmate, playing, draw.
        public Board()
        {
            CreatingBoard(); //the board in the beginning.
            currentPlayer = "White"; //white always starting.
            gameState = "playing";
        }
        public Pawn GetWhitePawns() { return whitePawns; }
        public Pawn GetBlackPawns() { return blackPawns; }
        public Rook GetWhiteRooks() { return whiteRooks; }
        public Rook GetBlackRooks() { return blackRooks; }
        public Knight GetWhiteKnights() { return whiteKnights; }
        public Knight GetBlackKnights() { return blackKnights; }
        public Bishop GetWhiteBishops() { return whiteBishops; }
        public Bishop GetBlackBishops() { return blackBishops; }
        public Queen GetWhiteQueen() { return whiteQueens; }
        public Queen GetBlackQueen() { return blackQueens; }
        public King GetWhiteKing() { return whiteKing; }
        public King GetBlackKing() { return blackKing; }
        private void CreatingBoard()
        {
            whitePawns = new Pawn(true, 0x00FF000000000000, "PawnW.png", 1);
            blackPawns = new Pawn(false, 0x000000000000FF00, "PawnB.png", 1);
            whiteRooks = new Rook(true, 0x8100000000000000, "RookW.png", 5);
            blackRooks = new Rook(false, 0x0000000000000081, "RookB.png", 5);
            whiteKnights = new Knight(true, 0x4200000000000000, "KnightW.png", 3);
            blackKnights = new Knight(false, 0x0000000000000042, "KnightB.png", 3);
            whiteBishops = new Bishop(true, 0x2400000000000000, "BishopW.png", 3);
            blackBishops = new Bishop(false, 0x0000000000000024, "BishopB.png", 3);
            whiteQueens = new Queen(true, 0x0800000000000000, "QueenW.png", 9);
            blackQueens = new Queen(false, 0x0000000000000008, "QueenB.png", 9);
            whiteKing = new King(true, 0x1000000000000000, "KingW.png", 100);
            blackKing = new King(false, 0x0000000000000010, "KingB.png", 100);
        }

        public ulong GetAllPieces()
        {
            return whitePawns.GetBitBoard() | blackPawns.GetBitBoard() |
                   whiteRooks.GetBitBoard() | blackRooks.GetBitBoard() |
                   whiteKnights.GetBitBoard() | blackKnights.GetBitBoard() |
                   whiteBishops.GetBitBoard() | blackBishops.GetBitBoard() |
                   whiteQueens.GetBitBoard() | blackQueens.GetBitBoard() |
                   whiteKing.GetBitBoard() | blackKing.GetBitBoard();
        }
        public void playerTurns()
        {
            currentPlayer = currentPlayer == "White" ? "Black" : "White"; //switch player's turn.
        }

        public void AddPiece(ref ulong bitboard, int index)
        {
            bitboard |= (1UL << index); //turns on the the appropriate bit.
        }

        public void RemovePiece(ref ulong bitboard, int index)
        {
            bitboard &= ~(1UL << index);  //turns off the the appropriate bit.
        }

        //Check if there's a game tool in the index.
        public bool IsPiecePresent(ulong bitboard, int index)
        {
            return (bitboard & (1UL << index)) != 0;
        }

        public void MovePiece(ref ulong bitboard, int fromIndex, int toIndex)
        {
            RemovePiece(ref bitboard, fromIndex);
            AddPiece(ref bitboard, toIndex);
        }

    }
}