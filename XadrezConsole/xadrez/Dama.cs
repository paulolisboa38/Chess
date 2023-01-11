using XadrezConsole.tabuleiro;
namespace XadrezConsole.xadrez
{
    internal class Dama : Peca
    {
        public Dama (Cor cor,Tabuleiro tabuleiro)
            : base(cor,tabuleiro)
        {
        }
        private bool PodeMover (Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis ()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas,Tabuleiro.Colunas];
            Posicao pos = new Posicao(0,0);
            //acima
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            //abaixo
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //direita
            pos.DefinirValores(Posicao.Linha,Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            //esquerda
            pos.DefinirValores(Posicao.Linha,Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }
            //no
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna - 1);
            }
            //ne
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna + 1);
            }
            //se
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna + 1);
            }
            //so
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna - 1);
            }
            return matriz;
        }
        public override string? ToString ()
        {
            return "D";
        }
    }
}