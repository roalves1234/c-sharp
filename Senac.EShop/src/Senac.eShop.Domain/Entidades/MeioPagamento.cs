using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.eShop.Core.ObjetosDominio;


namespace Senac.eShop.Domain.Entidades
{
    public class MeioPagamento: Entidade
    {
        public MeioPagamento(string alias, string cartaoId, string ultimos4, Cliente cliente)
        {
            Alias = alias;
            CartaoId = cartaoId;
            Ultimos4 = ultimos4;
            Cliente = cliente;
            ClienteId = cliente.Id;
        }

        public string Alias { get; private set; }
        public string CartaoId { get; private set; }
        public string Ultimos4 { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public void SetAlias(string Value)
        {
            Alias = Value;
        }
        public void SetCartaoId(string Value)
        {
            CartaoId = Value;
         }
        public void SetUltimos4(string Value)
        {
            Ultimos4 = Value;
        }
    }
}
