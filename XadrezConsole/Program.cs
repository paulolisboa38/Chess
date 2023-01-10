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
                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);
                        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro,posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem,destino);
                        partida.RealizaJogada(origem,destino);
                    }
                    catch (TabuleiroException v)
                    {
                        Console.WriteLine(v.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException t)
            {
                Console.WriteLine(t.Message);
            }
        }
    }
}