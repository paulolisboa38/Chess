﻿using XadrezConsole.tabuleiro;
namespace XadrezConsole.xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; set; }
        public PartidaXadrez ()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }
        public void ExecutaMovimento (Posicao origem,Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca,destino);
        }
        private void ColocarPecas ()
        {
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca,Tabuleiro),new PosicaoXadrez('c',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca,Tabuleiro),new PosicaoXadrez('c',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca,Tabuleiro),new PosicaoXadrez('d',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca,Tabuleiro),new PosicaoXadrez('e',2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca,Tabuleiro),new PosicaoXadrez('e',1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca,Tabuleiro),new PosicaoXadrez('d',1).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Cor.Preta,Tabuleiro),new PosicaoXadrez('c',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta,Tabuleiro),new PosicaoXadrez('c',8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta,Tabuleiro),new PosicaoXadrez('d',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta,Tabuleiro),new PosicaoXadrez('e',7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta,Tabuleiro),new PosicaoXadrez('e',8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta,Tabuleiro),new PosicaoXadrez('d',8).ToPosicao());
        }
    }
}
