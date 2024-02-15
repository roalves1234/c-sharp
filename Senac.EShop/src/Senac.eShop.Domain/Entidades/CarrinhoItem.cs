using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Senac.eShop.Core.ObjetosDominio;

namespace Senac.eShop.Domain.Entidades
{
    public class CarrinhoItem: Entidade
    {
        protected CarrinhoItem() { }
        public CarrinhoItem(Produto produto, Guid carrinhoId, int quantidade)
        {
            SetProduto(produto);
            SetCarrinhoId(carrinhoId);
            SetQuantidade(quantidade);
        }

        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public Guid CarrinhoId { get; private set; }
        public int Quantidade { get; private set; }
        public void SetProduto(Produto value)
        {
            Produto = value;
            ProdutoId = Produto.Id;
        }
        public void SetCarrinhoId(Guid value)
        {
            CarrinhoId = value;
        }
        public void SetQuantidade(int value)
        {
            Quantidade = value;
        }
        public void AlterarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}
