using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using Scrum.Model;

namespace Scrum
{
    public interface IPartRegra
    {
        void Alterar(Tarefa tarefa);
        Junction GetCondicaoWhere();
    }
}
