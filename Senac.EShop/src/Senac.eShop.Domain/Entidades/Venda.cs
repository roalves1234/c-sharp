using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.eShop.Core.ObjetosDominio;

namespace Senac.eShop.Domain.Entidades
{
    public class Venda : Entidade
    {
        const int TAMANHO_CODIGO = 5;
        protected Venda() { }
        public Venda(Cliente cliente, double valorTotal, double valorDesconto, CupomDesconto cupomDesconto, Endereco endereco, Carrinho carrinho, MeioPagamento meioPagamento)
        {
            Cliente = cliente;
            ClienteId = cliente.Id;
            ValorTotal = valorTotal;
            ValorDesconto = valorDesconto;
            CupomDesconto = cupomDesconto;
            CupomDescontoId = cupomDesconto.Id;
            Carrinho = carrinho;
            Status = VendaStatus.Criada;
            SetEndereco(endereco);
            SetMeioPagamento(meioPagamento);
            SetCodigo();
        }
        private readonly List<VendaItem> _vendaItens;
        public IReadOnlyCollection<VendaItem> VendaItens => _vendaItens;
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public double ValorTotal { get; private set; }
        public double ValorFinal { get; private set; }
        public double ValorDesconto { get; private set; }
        public Guid CupomDescontoId { get; private set; }
        public CupomDesconto CupomDesconto { get; private set; }
        public Guid EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid CarrinhoId { get; private set; }
        public Carrinho Carrinho { get; private set; }
        public Guid MeioPagamentoId { get; private set; }
        public MeioPagamento MeioPagamento { get; private set; }
        public VendaStatus Status { get; private set; }
        public string CodigoCompra { get; private set; }
        public void SetMeioPagamento(MeioPagamento Value)
        {
            MeioPagamento = Value;
            MeioPagamentoId = Value.Id;
        }
        public void SetEndereco(Endereco Value)
        {
            Endereco = Value;
            EnderecoId = Value.Id;
        }
        public void AplicaCupom(CupomDesconto cupom)
        {
            CupomDesconto = cupom;
            CupomDescontoId = cupom.Id;

            CalcularValorTotalDesconto();
        }

        public void CalcularValorVenda()
        {
            if (VendaItens == null)
                ValorTotal = 0;
            else
                ValorTotal = VendaItens.Sum<VendaItem>(i => i.ValorItem);
        }
        public void CalcularValorTotalDesconto()
        {
            double desconto = 0;
            double valor = ValorTotal;

            if (CupomDesconto.TipoDesconto == TipoDescontoCupom.Percentual)
                desconto = (valor * CupomDesconto.Valor / 100);
            else
                desconto = (CupomDesconto.Valor);

            valor -= desconto;

            if (valor < 0)
                ValorFinal = 0;
            else
                ValorFinal = valor;

        }
        private string SetCodigoAleatorio(int tamanho)
        {
            string letrasNumeros = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var aleatorio = new Random();
            var resultado = new string(Enumerable.Repeat(letrasNumeros, tamanho)
                                         .Select(s => s[aleatorio.Next(s.Length)])
                                         .ToArray());
            return (resultado);
        }
        public void SetCodigo()
        {
            CodigoCompra = SetCodigoAleatorio(TAMANHO_CODIGO);
        }

        public void AutorizeVendaStatus() =>
            Status = VendaStatus.Autorizada;
        public void CancelaVendaStatus() =>
            Status = VendaStatus.Cancelada;
        public void EntregaVendaStatus() =>
            Status = VendaStatus.Entregue;
        public void PagueVendaStatus() =>
            Status = VendaStatus.Paga;
    }
}
