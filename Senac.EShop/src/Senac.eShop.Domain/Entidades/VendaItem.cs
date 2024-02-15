using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Domain.Entidades
{
    public class VendaItem
    {
        public VendaItem(Venda venda, Produto produto, int quantidade, double valorUnitario)
        {
            Venda = venda;
            Produto = produto;
            ProdutoId = produto.Id;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid VendaId { get; private set; }
        public Venda Venda { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public Double ValorUnitario { get; private set; }
        public Double ValorItem
        {
            get { return (Quantidade * ValorUnitario); }
        }
            
        public void SetVenda(Venda value)
        {
            Venda = value;
        }
        public void SetProduto(Produto value)
        {
            Produto = value;
        }
        public void SetQuantidade(int value)
        {
            Quantidade = value;
        }
        public void SetValorUnitario(double value) 
        { 
            ValorUnitario = value; 
        }

    }
}
