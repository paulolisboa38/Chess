using System.Collections.Generic;
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
        public bool Xeque { get; private set; }

        public PartidaXadrez ()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public Peca ExecutaMovimento (Posicao origem,Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca,destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void DesfazMovimento (Posicao origem,Posicao destino,Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarQtdMovimentos();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada,destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p,origem);
        }
        public void RealizaJogada (Posicao origem,Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem,destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem,destino,pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
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
            if (!Tabuleiro.Peca(origem).MovimentoPossivel(destino))
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
        private Cor Adversaria (Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca Rei (Cor cor)
        {
            foreach (Peca item in PecasEmJogo(cor))
            {
                if (item is Rei)
                {
                    return item;
                }
            }
            return null;
        }
        public bool EstaEmXeque (Cor cor)
        {
            Peca r = Rei(cor);
            if (r == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca item in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = item.MovimentosPossiveis();
                if (mat[r.Posicao.Linha,r.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool TesteXequeMate (Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca item in PecasEmJogo(cor))
            {
                bool[,] mat = item.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (mat[i,j])
                        {
                            Posicao origem = item.Posicao;
                            Posicao destino = new Posicao(i,j);
                            Peca pecaCapturada = ExecutaMovimento(origem,destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem,destino,pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void ColocarNovaPeca (char coluna,int linha,Peca peca)
        {
            Tabuleiro.ColocarPeca(peca,new PosicaoXadrez(coluna,linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas ()
        {
            ColocarNovaPeca('a',1,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('b',1,new Cavalo(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('c',1,new Bispo(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('d',1,new Dama(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('e',1,new Rei(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('f',1,new Bispo(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('g',1,new Cavalo(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('h',1,new Torre(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('a',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('b',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('c',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('d',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('e',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('f',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('g',2,new Peao(Cor.Branca,Tabuleiro));
            ColocarNovaPeca('h',2,new Peao(Cor.Branca,Tabuleiro));

            ColocarNovaPeca('a',8,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('b',8,new Cavalo(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('c',8,new Bispo(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('d',8,new Dama(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('e',8,new Rei(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('f',8,new Bispo(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('g',8,new Cavalo(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('h',8,new Torre(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('a',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('b',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('c',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('d',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('e',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('f',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('g',7,new Peao(Cor.Preta,Tabuleiro));
            ColocarNovaPeca('h',7,new Peao(Cor.Preta,Tabuleiro));
        }
    }
}
