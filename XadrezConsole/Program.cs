using XadrezConsole.tabuleiro;
using XadrezConsole.xadrez;
namespace XadrezConsole
{
    internal class Program
    {
        static void Main (string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8,8);

                tabuleiro.ColocarPeca(new Torre(Cor.Preta,tabuleiro),new Posicao(0,0));
                tabuleiro.ColocarPeca(new Torre(Cor.Preta,tabuleiro),new Posicao(1,3));
                tabuleiro.ColocarPeca(new Rei(Cor.Preta,tabuleiro),new Posicao(0,2));

                Tela.ImprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException t)
            {
                Console.WriteLine(t.Message);
            }
        }
    }
}