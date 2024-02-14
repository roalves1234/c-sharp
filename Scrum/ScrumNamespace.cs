using System;

namespace ScrumNamespace
{
    public class Tarefa
    {
        public virtual int IdTarefa { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual TimeSpan Hora { get; set; }
        public virtual int Pontuacao { get; set; }
        public virtual string Status { get; set; }
    }

}
