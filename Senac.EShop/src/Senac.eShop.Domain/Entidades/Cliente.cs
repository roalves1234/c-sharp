using Senac.eShop.Core.ObjetosDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Domain.Entidades
{
    public class Cliente : Entidade
    {
        protected Cliente()
        {

        }

        public Cliente(string nome, string sobrenome, string email, string telefone, string documento, string sexo, Endereco endereco)
        {
            SetNome(nome, sobrenome);
            SetEmail(email);
            SetTelefone(telefone);
            SetDocumento(documento);
            SetSexo(sexo);
            SetEnderecoCliente(endereco);
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Documento { get; private set; }
        public string Sexo { get; private set; }
        public Endereco EnderecoCliente { get; private set; }
        public Guid EnderecoId { get; private set; }
        private List<MeioPagamento> _meioPagamento = new List<MeioPagamento>();
        public IEnumerable<MeioPagamento> MeiosPagamento => _meioPagamento.AsReadOnly();

        public void SetNome(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public void SetEmail(string value)
        {
            Email = value;
        }
        public void SetTelefone(string value)
        {
            Telefone = value;
        }
        public void SetDocumento(string value)
        {
            Documento = value;
        }
        public void SetSexo(string value)
        {
            Sexo = value;
        }
        public void SetEnderecoCliente(Endereco value)
        {
            EnderecoCliente = value;
            EnderecoId = value.Id;
        }
    }
}
