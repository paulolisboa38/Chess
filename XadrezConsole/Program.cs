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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaXadrez.Tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partidaXadrez.Turno);
                        Console.WriteLine("Aguardando jogada: " + partidaXadrez.JogadorAtual);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaXadrez.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partidaXadrez.Tabuleiro.Peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaXadrez.Tabuleiro,posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaXadrez.ValidarPosicaoDestino(origem,destino);
                        partidaXadrez.RealizaJogada(origem,destino);
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