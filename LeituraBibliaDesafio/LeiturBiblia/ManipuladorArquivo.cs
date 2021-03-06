﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeiturBiblia
{
    class ManipuladorArquivo
    {
        private static string EnderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "Biblia.txt";               

        public static void LerBiblia(string livro, string capitulo, string versiculo)
        {
            string frase;
            bool acheiLivro = false;
            bool acheiCapitulo = false;
            bool acheiVersiculo = false;

            if (File.Exists(EnderecoArquivo))
            {
                using (StreamReader leitor = File.OpenText(EnderecoArquivo))
                {
                    while (leitor.Peek() >= 0)
                    {
                        frase = leitor.ReadLine();
                        if (frase != "")
                        {
                            if (frase == livro)
                            {
                                Console.WriteLine("Livro: {0}", frase);
                                Console.ReadKey();
                                acheiLivro = true;
                            }
                            if (frase == capitulo && acheiLivro)
                            {
                                Console.WriteLine("Capitulo: {0}", frase);
                                Console.ReadKey();
                                acheiCapitulo = true;
                            }
                            if (frase.Contains(versiculo) && acheiLivro && acheiCapitulo)
                            {
                                Console.WriteLine("Versiculo: {0}", frase);
                                Console.ReadKey();
                                acheiVersiculo = true;
                                break;
                            }
                        }
                    }
                    if (!acheiCapitulo || !acheiLivro || !acheiVersiculo)
                    {
                        Console.WriteLine("Não foi possivel achar o versiculo desejado!\n\n");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
