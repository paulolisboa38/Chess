﻿using XadrezConsole.tabuleiro;
namespace XadrezConsole.xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
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
        public void RealizaJogada (Posicao origem,Posicao destino)
        {
            ExecutaMovimento(origem,destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem (Posicao pos)
        {
            if (Tabuleiro.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        private void MudaJogador ()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
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
