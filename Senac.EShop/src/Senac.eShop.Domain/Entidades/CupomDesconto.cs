using Senac.eShop.Core.ObjetosDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Domain.Entidades
{
    public class CupomDesconto: Entidade
    {
        protected CupomDesconto() { }
        public CupomDesconto(string codigo, double valor, int quantidade, DateTime expiraEm, TipoDescontoCupom tipoDesconto)
        {
            SetCodigo(codigo);
            SetValor(valor);
            SetQuantidade(quantidade);
            SetExpiraEm(expiraEm);
            SetTipoDesconto(tipoDesconto);
            SetAtivo(true);
        }

        public string Codigo { get; private set; }
        public Double Valor { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime ExpiraEm { get; private set; }
        public TipoDescontoCupom TipoDesconto { get; private set; }
        public bool Ativo { get; private set; }

        public void SetCodigo(string value)
        {
            Codigo = value;
        }
        public void SetValor(Double value)
        {
            Valor = value;
        }
        public void SetQuantidade(int value)
        {
            Quantidade = value;
        }
        public void SetExpiraEm(DateTime value)
        {
            ExpiraEm = value;
        }
        public void SetAtivo(bool value)
        {
            Ativo = value;
        }
        public void SetTipoDesconto(TipoDescontoCupom value)
        {
            TipoDesconto = value;
        }

    }
}
