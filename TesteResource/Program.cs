using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteResource
{
    class Program
    {
        class Veiculo
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Ano { get; set; }
            public double ValorMinimo { get; set; }
        }

        class Carro : Veiculo
        {
            public string Motor { get; set; }
        }

        class Moto : Veiculo
        {
            public string Cilindradas { get; set; }
        }

        interface IVenda
        {
            void VendaVeiculo();
            void VendaVeiculo(double valorVenda, Veiculo veiculo);
        }

        class Venda : IVenda
        {
            public void VendaVeiculo()
            {
                throw new NotImplementedException();
            }

            public void VendaVeiculo(double valorVenda, Veiculo veiculo)
            {
                List<Veiculo> listaVeiculo = new List<Veiculo>(); //imaginando q eu tenha a lista preenchida

                if (valorVenda < veiculo.ValorMinimo)
                {
                    var veiculosDisponiveis = listaVeiculo.Where(v => v.ValorMinimo <= valorVenda);
                    //lista de veiculos disponiveis para o valor de venda
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Hello World");
        }
    }
}
