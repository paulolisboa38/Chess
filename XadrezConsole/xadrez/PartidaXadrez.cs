﻿using System.Collections.Generic;
using XadrezConsole.tabuleiro;
namespace XadrezConsole.xadrez
{
    internal class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaXadrez ()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public void ExecutaMovimento (Posicao origem,Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca,destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
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
        public void ValidarPosicaoDestino (Posicao origem,Posicao destino)
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
        public HashSet<Peca> PecasCapturadas (Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in Capturadas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo (Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in Pecas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ColocarNovaPeca (char coluna,int linha,Peca peca)
        {
            Tabuleiro.ColocarPeca(peca,new PosicaoXadrez(coluna,linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas ()
        {
            ColocarNovaPeca('c',1,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('c',2,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('d',2,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('e',2,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('e',1,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('d',1,new Rei(Cor.Branca,Tabuleiro));

            ColocarNovaPeca('c',7,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('c',8,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('d',7,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('e',7,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('e',8,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('d',8,new Rei(Cor.Preta,Tabuleiro));
        }
    }
}
