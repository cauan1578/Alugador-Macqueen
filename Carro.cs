using System;
class Carro
{
    public string Placa { get; }
    public string Marca { get; }
    public string Modelo { get; }
    public int Ano { get; }
    public double PrecoDiario { get; }
    public bool Alugado;

    public bool getAlugado()
    {
        return Alugado;
    }
    public bool setAlugado()
    {
        return Alugado;
    }


    public Carro(string placa, string marca, string modelo, int ano, double precoDiario)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
        PrecoDiario = precoDiario;
        Alugado = false;
    }

    public override string ToString()
    {
        return $"{Marca} {Modelo} ({Ano}) - Placa: {Placa} - Preço Diário: ${PrecoDiario}";
    }
}