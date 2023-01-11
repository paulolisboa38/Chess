using System.Runtime.ConstrainedExecution;
using XadrezConsole.tabuleiro;
namespace XadrezConsole.xadrez
{
    internal class Peao : Peca
    {
        public Peao (Cor cor,Tabuleiro tabuleiro)
            : base(cor,tabuleiro)
        {
        }
        private bool ExisteInimigo (Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        private bool Livre (Posicao pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }
        public override bool[,] MovimentosPossiveis ()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas,Tabuleiro.Colunas];
            Posicao pos = new Posicao(0,0);
            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2,Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && Tabuleiro.PosicaoValida(pos)
                    && Livre(pos) && QtdMovimentos == 0)
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2,Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && Tabuleiro.PosicaoValida(pos)
                    && Livre(pos) && QtdMovimentos == 0)
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha,pos.Coluna] = true;
                }
            }
            return matriz;
        }
        public override string? ToString ()
        {
            return "P";
        }
    }
}
