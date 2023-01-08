using XadrezConsole.tabuleiro;
namespace XadrezConsole
{
    internal class Program
    {
        static void Main (string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8,8);
 
            Tela.ImprimirTabuleiro(tabuleiro);

        }
    }
}