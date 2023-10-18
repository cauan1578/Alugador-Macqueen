using System;
using System.Collections.Generic;


class Program
{
    static List<Carro> carros = new List<Carro>
    {
        new Carro("ABC123", "Fiat", "Uno", 2020, 50.0),
        new Carro("DEF456", "Ford", "Focus", 2019, 70.0),
        new Carro("GHI789", "Chevrolet", "Cruze", 2021, 80.0)
    };

    static List<Locacao> locacoes = new List<Locacao>();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Seja Bem-Vindo ao Alugador Macqueen");
            Console.WriteLine("1 - Alugar Carro");
            Console.WriteLine("2 - Devolver Carro");
            Console.WriteLine("3 - Mostrar Carros Alugados");
            Console.WriteLine("4 - Gerar Relatório de Alugueis de Carros");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        AlugarCarro();
                        break;
                    case 2:
                        DevolverCarro();
                        break;
                    case 3:
                        ListarCarrosAlugados();
                        break;
                    case 4:
                        GerarRelatorio();
                        break;
                    case 5:
                        Console.WriteLine("Saindo do programa.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        } while (opcao != 5);
    }

    static void AlugarCarro()
    {
        Console.WriteLine("Carros Disponíveis para Alugar:");
        ListarCarrosDisponiveis();

        Console.Write("Selecione o número do carro que deseja alugar: ");
        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= carros.Count)
        {
            Carro carroSelecionado = carros[escolha - 1];

            if (!carroSelecionado.Alugado)
            {
                Console.Write("Digite o nome do cliente: ");
                string nomeCliente = Console.ReadLine();

                Console.Write("Digite a idade do cliente: ");
                if (int.TryParse(Console.ReadLine(), out int idade))
                {
                    Console.Write("Digite o CPF do cliente: ");
                    string cpf = Console.ReadLine();

                    Cliente cliente = new Cliente(nomeCliente, idade, cpf);

                    if (cliente.CpfValido)
                    {
                        Locacao locacao = new Locacao(cliente, carroSelecionado);
                        locacoes.Add(locacao);
                        carroSelecionado.Alugado = true;


                        carros.Remove(carroSelecionado);

                        Console.WriteLine("Carro alugado com sucesso.");
                    }

                }
                else
                {
                    Console.WriteLine("Idade inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Carro já alugado. Escolha outro carro.");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    static void DevolverCarro() // Gabriel
    {
        ListarCarrosAlugados();

        Console.Write("Digite o número do carro que deseja devolver: ");
        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= locacoes.Count)
        {
            Locacao locacao = locacoes[escolha - 1];

            if (locacao.CarroAlugado.Alugado)
            {
                locacao.CarroAlugado.Alugado = false;
                carros.Add(locacao.CarroAlugado);
                locacoes.Remove(locacao);

                Console.WriteLine("Carro devolvido com sucesso.");
            }
            else
            {
                Console.WriteLine("Este carro não está alugado. Escolha outro carro para devolver.");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }


    static void ListarCarrosAlugados()
    {
        Console.WriteLine("Carros Alugados:");
        int i = 1;
        foreach (var locacao in locacoes)
        {
            Console.WriteLine($"{i} - {locacao.CarroAlugado}");
            i++;
        }
    }

    static void GerarRelatorio()
    {
        Console.WriteLine("Relatório de Alugueis de Carros:");
        foreach (var locacao in locacoes)
        {
            Console.WriteLine(locacao);
        }
    }

    static void ListarCarrosDisponiveis()
    {
        for (int i = 0; i < carros.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {carros[i]}");
        }
    }
}
