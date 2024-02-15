using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Core.ObjetosDominio
{
    public enum VendaStatus
    {
        Criada = 1,
        Autorizada = 2,
        EmProcessamento = 3,
        Paga = 4,
        Recusada = 5,
        Entregue = 6,
        Cancelada = 7
    }
}
