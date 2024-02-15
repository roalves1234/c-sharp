using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.eShop.Core.ObjetosDominio;

namespace Senac.eShop.Domain.Entidades
{
    public class Carrinho: Entidade
    {
        public Carrinho(Cliente cliente)
        {
            SetCliente(cliente);
            Itens = new List<CarrinhoItem>();
        }

        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<CarrinhoItem> Itens { get; private set; }
        public void SetCliente(Cliente value)
        {
            Cliente = value;
            ClienteId = Cliente.Id;
        }
        public void AdicionarItem(CarrinhoItem item)
        {
            Itens.Add(item);
        }
        public void RemoverItem(CarrinhoItem item)
        {
            Itens.Remove(item);
        }
        public void LimparCarrinho()
        {
            Itens.Clear();
        }
        public void AlterarQuantidadeItem(CarrinhoItem item, int novaQuantidade)
        {
            Itens.Where(i => i.CarrinhoId == item.CarrinhoId).First().SetQuantidade(novaQuantidade);
            //item.SetQuantidade(novaQuantidade);
        }

    }
}
