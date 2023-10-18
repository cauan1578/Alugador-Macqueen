using System;
class Locacao
{
    public Cliente Cliente { get; }
    public Carro CarroAlugado { get; }
    public DateTime DataLocacao { get; }

    public Locacao(Cliente cliente, Carro carro)
    {
        this.Cliente = cliente;
        CarroAlugado = carro;
        DataLocacao = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Cliente: {Cliente.Nome}, Carro Alugado: {CarroAlugado}, Data de Locação: {DataLocacao}";
    }

}
