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
                PartidaXadrez partidaXadrez = new PartidaXadrez();
                while (!partidaXadrez.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaXadrez.Tabuleiro);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    bool[,] posicoesPossiveis = partidaXadrez.Tabuleiro.Peca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partidaXadrez.Tabuleiro,posicoesPossiveis);
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partidaXadrez.ExecutaMovimento(origem,destino);
                }
            }
            catch (TabuleiroException t)
            {
                Console.WriteLine(t.Message);
            }
        }
    }
}