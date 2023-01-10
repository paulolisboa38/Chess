﻿namespace XadrezConsole.tabuleiro
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; set; }
        public Peca (Cor cor,Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            QtdMovimentos = 0;
            Tabuleiro = tabuleiro;
        }
        public void IncrementarQtdMovimentos ()
        {
            QtdMovimentos++;
        }
        public abstract bool[,] MovimentosPossiveis ();
    }
}
