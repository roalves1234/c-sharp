using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Model
{
    public class Retrospectiva
    {
        public Retrospectiva()
        {
            Data = DateTime.Now.Date;
            Hora = DateTime.Now.TimeOfDay;
        }
        public virtual int IdRetrospectiva { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual TimeSpan Hora { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual bool Existe { get { return (IdRetrospectiva > 0); } }
    }
}
