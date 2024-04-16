using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using Aula_01.menu;

namespace Aula01;

public class AtualizarLivro : Command
{
    Livro livro = new Livro();
    LivroDAO DAO = new LivroDAO();

    private ListarLivros listarLivros;
    
    public void Executar()
    {
        try
        {
            long ibsn = 0;
            do
            {
                Console.WriteLine("*Atualizar dados do livro:\n");
                Console.WriteLine("*Digite o IBSN do livro (somente numero): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo IBSN não pode estar vazio.");
                }
                else if (!long.TryParse(input, out ibsn))
                {
                    Console.WriteLine("Valor de IBSN inválido.");
                }
                else
                {
                    livro.setISBN(ibsn);
                }
            } while (ibsn == 0);

            string Titulo;
            do
            {
                Console.WriteLine("*Digite o titulo do Livro: ");
                livro.setTitulo(Console.ReadLine());

                if (string.IsNullOrEmpty(livro.getTitulo()))
                {
                    Console.WriteLine("O campo Livro não pode estar vazio.");
                }
                else if (livro.getTitulo().Length > 50)
                {
                    Console.WriteLine("O campo Livro deve ter no máximo 50 caracteres.");
                }
            } while (string.IsNullOrEmpty(livro.getTitulo()) || livro.getTitulo().Length > 50);
            
            string Autor;
            do
            {
                Console.WriteLine("*Digite o nome do Autor: ");
                livro.setAutor(Console.ReadLine());

                if (string.IsNullOrEmpty(livro.getAutor()))
                {
                    Console.WriteLine("O campo Autor não pode estar vazio.");
                }
                else if (livro.getAutor().Length > 50)
                {
                    Console.WriteLine("O campo Autor deve ter no máximo 50 caracteres.");
                }
            } while (string.IsNullOrEmpty(livro.getAutor()) || livro.getAutor().Length > 50);

            int Ano = 0;
            do
            {
                Console.WriteLine("*Digite o ano do livro (somente números): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo do ano não pode estar vazio.");
                }
                else if (input.Length != 4)
                {
                    Console.WriteLine("O ano deve ter 4 caracteres.");
                }
                else if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine("Valor de ano inválido.");
                }
                else
                {
                    livro.setAno(value);
                    Ano = value;
                }
            } while (Ano == 0);

            do
            {
                Console.WriteLine("*Digite o Genero do livro: ");
                livro.setGenero(Console.ReadLine());

                if (string.IsNullOrEmpty(livro.getGenero()))
                {
                    Console.WriteLine("O campo Genero não pode estar vazio.");
                }
                else if (livro.getGenero().Length > 100)
                {
                    Console.WriteLine("O campo Genero deve ter no máximo 100 caracteres.");
                }
            } while (string.IsNullOrEmpty(livro.getGenero()) || livro.getGenero().Length > 100);

            int Edicao = 0;
            do
            {
                Console.WriteLine("*Digite a Edicao do livro (somente números): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo do ano não pode estar vazio.");
                }
                else if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine("Edição inválido.");
                }
                else
                {
                    livro.setEdicao(value);
                    Edicao = value;
                }
            } while (Edicao == 0);

            int Quantidade = 0;
            do
            {
                Console.WriteLine("*Digite a quantidade do livro (somente números): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("O campo de Quantidade não pode estar vazio.");
                }
                else if (!int.TryParse(input, out int inputNumber) || inputNumber <= 0)
                {
                    Console.WriteLine("A Quantidade deve ser um número inteiro maior que zero.");
                }
                else if (inputNumber > 1000)
                {
                    Console.WriteLine("A Quantidade deve ser no máximo 1000.");
                }
                else
                {
                    livro.setQuantidade(inputNumber);
                    Quantidade = inputNumber;
                }
            } while (Quantidade == 0);

            DAO.UpdateLivro(livro.getISBN(), livro.getTitulo(), livro.getAutor(), livro.getAno(), livro.getGenero(), livro.getEdicao(), livro.getQuantidade());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"erro: {ex}");
        }
    }
}