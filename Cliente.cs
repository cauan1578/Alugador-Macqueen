using System;
class Cliente
{
    public string Nome { get; private set; }
    public int Idade { get; private set; }
    public string Cpf { get; private set; }
    public bool CpfValido { get; private set; }

    public Cliente(string nome, int idade, string cpf)
    {
        Nome = nome.ToUpper();
        if (idade >= 18)
        {
            Idade = idade;
        }
        else
        {
            Console.WriteLine("Idade informada não é possível possuir uma CNH. Cancelando cadastro.");
            return;
        }

        ValidarCPF(cpf);
        if (CpfValido)
        {
            Cpf = cpf;
        }
        else
        {

            return;
        }
    }

    public void ValidarCPF(string cpf)
    {
        CpfValido = false;



        if (cpf.Length != 11)
        {
            Console.WriteLine("CPF não faz sentido");
            return;
        }
        else
        {
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }
            int primeiroDigito = 11 - (soma % 11);

            if (primeiroDigito >= 10)
            {
                primeiroDigito = 0;
            }

            if ((cpf[9] - '0') == primeiroDigito)
            {
                soma = 0;
                for (int i = 0; i < 10; i++)
                {
                    soma += (cpf[i] - '0') * (11 - i);
                }
                int segundoDigito = 11 - (soma % 11);

                if (segundoDigito >= 10)
                {
                    segundoDigito = 0;
                }

                if ((cpf[10] - '0') == segundoDigito)
                {
                    CpfValido = true;
                }
            }
        }

        if (CpfValido)
        {
            Console.WriteLine("CPF Válido!");
        }
        else
        {
            Console.WriteLine("CPF Inválido!");
        }
    }
}
