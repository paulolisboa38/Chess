﻿using XadrezConsole.tabuleiro;
namespace XadrezConsole
{
    internal class Tela
    {
        public static void ImprimirTabuleiro (Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.Peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tabuleiro.Peca(i,j));
                        Console.Write(" ");
                    }
                    //else
                    //{
                    //    Console.Write(tabuleiro.Peca(i,j) + " ");
                    //}
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirPeca (Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = consoleColor;
            }
        }
    }
}
