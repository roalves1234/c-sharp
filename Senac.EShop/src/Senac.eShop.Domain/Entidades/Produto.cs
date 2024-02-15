using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.eShop.Core.ObjetosDominio;

namespace Senac.eShop.Domain.Entidades
{
    public class Produto : Entidade
    {
        protected Produto() { }
        public Produto(string nome, string descricao, bool ativo, double preco, string imagem, int quantidadeEstoque)
        {
            SetNome(nome);
            SetDescricao(descricao);
            SetAtivo(ativo);
            SetPreco(preco);
            SetImagem(imagem);
            SetQuantidadeEstoque(quantidadeEstoque);
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public double Preco { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public void SetNome(string value)
        {
            Nome = value;
        }
        public void SetDescricao(string value)
        {
             Descricao = value;
        }
        public void SetAtivo(bool value)
        {
             Ativo = value;
        }
        public void SetPreco(double value)
        {
             Preco = value;
        }
        public void SetImagem(string value)
        {
             Imagem = value;
        }
        public void SetQuantidadeEstoque(int value)
        {
            QuantidadeEstoque  = value;
        }
        public void DiminuirEstoque(int quantidade)
        {
            if (quantidade > QuantidadeEstoque) 
                throw new Exception("Quantidade maior que o disponível em estoque");
            QuantidadeEstoque -= quantidade;

        }
        public void AdicionarEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }
    }
}
