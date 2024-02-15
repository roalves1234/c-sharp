using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.eShop.Core.ObjetosDominio;

namespace Senac.eShop.Domain.Entidades
{
    public class Endereco: Entidade
    {
        protected Endereco() { }
        public Endereco(string logradouro, string complemento, string bairro, string cidade, string estado, string cep, TipoEndereco tipo)
        {
            SetLogradouro(logradouro);
            SetComplemento(complemento);
            SetBairro(bairro);
            SetCidade(cidade);
            SetEstado(estado);
            SetCEP(cep);
            SetTipo(tipo);
        }

        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public TipoEndereco Tipo { get; private set; }

        public void SetLogradouro(String value )
        {
            Logradouro = value;
        }
        public void SetComplemento(String value)
        {
            Complemento = value;
        }
        public void SetBairro(String value)
        {
            Bairro = value;
        }
        public void SetCidade(String value)
        {
            Cidade = value;
        }
        public void SetEstado(String value)
        {
            Estado = value;
        }
        public void SetCEP(String value)
        {
            CEP = value;
        }
        public void SetTipo(TipoEndereco value)
        {
            Tipo = value;
        }
    }
}
