using FluentNHibernate.Mapping;
using FluentNHibernate.Utils;
using NHibernate.Criterion;
using NHibernate.Engine;
using Scrum;
using Scrum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Model
{
    public class TarefaMap : ClassMap<Tarefa>
    {
        public TarefaMap()
        {
            Table("Tarefa"); 

            Id(x => x.IdTarefa).GeneratedBy.Identity();
            Map(x => x.Data).Default("GETDATE()");
            Map(x => x.Hora).CustomType("TimeAsTimeSpan").Default("GETDATE()");
            Map(x => x.Descricao);
            Map(x => x.Pontuacao);
            Map(x => x.Status).Check("Status IN ('A Fazer', 'Fazendo', 'Feito')");
            References(x => x.Sprint).Column("IdSprint");
        }
    }
    public class SprintMap : ClassMap<Sprint>
    {
        public SprintMap() 
        {
            Table("Sprint");

            Id(x => x.IdSprint).GeneratedBy.Identity();
            Map(x => x.Descricao);
            Map(x => x.Data).Default("GETDATE()");
            Map(x => x.Hora).CustomType("TimeAsTimeSpan").Default("GETDATE()");
            Map(x => x.Status);
            HasMany(x => x.ListaTarefa).KeyColumn("IdSprint").Cascade.All().Inverse();
        }

        public class RetrospectivaMap : ClassMap<Retrospectiva>
        {
            public RetrospectivaMap()
            {
                Table("SprintRetrospectiva"); 

                Id(x => x.IdRetrospectiva).GeneratedBy.Identity();
                Map(x => x.Data).Default("GETDATE()");
                Map(x => x.Hora).CustomType("TimeAsTimeSpan").Default("GETDATE()");
                Map(x => x.Descricao);
                References(x => x.Sprint).Column("IdSprint");
            }
        }

        public Sprint GetSprintAtual()
        {
            using (var session = ConexaoBanco.getInstance().NewSession())
            {
                IList<Sprint> lista;

                var condicao = Restrictions.Disjunction();
                string[] listaStatus = { "Planejamento", "Execucao" };
                condicao.Add(Restrictions.In(Projections.Property<Tarefa>(t => t.Status), listaStatus));

                lista = session
                            .QueryOver<Sprint>()
                            .Where(condicao)
                            .List();
                if (lista.Count == 0)
                    throw new Exception("Não existe sprint em aberto");

                return (lista.First());
            }
        }
    }
}