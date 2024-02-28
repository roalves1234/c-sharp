using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Model
{
    public class Tarefa
    {
        public Tarefa()
        {
            Data = DateTime.Now.Date;
            Hora = DateTime.Now.TimeOfDay;
            Status = "A Fazer";
        }
        public virtual int IdTarefa { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual TimeSpan Hora { get; set; }
        public virtual int Pontuacao { get; set; }
        public virtual string Status { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual bool Existe { get { return (IdTarefa > 0); } }


    }
}
