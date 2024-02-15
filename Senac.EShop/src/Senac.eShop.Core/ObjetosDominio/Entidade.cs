using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Core.ObjetosDominio
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public DateTimeOffset CriadoEm { get; set; }
        public DateTimeOffset AlteradoEm { get; set; }
    }
}
