using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Model
{
    public class Sprint
    {
        public Sprint()
        {
            Data = DateTime.Now.Date;
            Hora = DateTime.Now.TimeOfDay;
            Status = "Planejamento";
        }
        public virtual int IdSprint { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual TimeSpan Hora { get; set; }
        public virtual string Status { get; set; }
        public virtual IList<Tarefa> ListaTarefa { get; set; } = new List<Tarefa>();
        public virtual bool Existe { get { return (IdSprint > 0); } }
    }
}
