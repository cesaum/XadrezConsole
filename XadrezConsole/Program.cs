using System;
using tabuleiro;
using xadrez;
namespace XadrezConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Oringem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }

                Tela.imprimirTabuleiro(partida.tab);


            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message); 
            }
           
        }
    }
}