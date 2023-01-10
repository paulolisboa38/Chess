using XadrezConsole.tabuleiro;
namespace XadrezConsole.xadrez
{
    internal class Rei : Peca
    {
        public Rei (Cor cor,Tabuleiro tabuleiro)
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
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //ne - cima/direita
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //direita
            pos.DefinirValores(Posicao.Linha,Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //se direita/abaixo
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //abaixo
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //so esquerda/abaixo
            pos.DefinirValores(Posicao.Linha + 1,Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //esquerda
            pos.DefinirValores(Posicao.Linha,Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            //no
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha,pos.Coluna] = true;
            }
            return matriz;
        }
        public override string? ToString ()
        {
            return "R";
        }
    }
}
