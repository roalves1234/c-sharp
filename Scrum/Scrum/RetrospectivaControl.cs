﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Scrum.Model;
using Scrum;
using System.ComponentModel;
using System.Windows.Forms;
using NHibernate.Criterion;

namespace Scrum
{
    public class RetrospectivaControl
    {
        private Retrospectiva retrospectivaAtual;
        private IList<Retrospectiva> listaRetrospectiva;
        private Sprint sprintAtual;
        private DaoRetrospectiva Dao;
        public RetrospectivaControl()
        {
            this.Dao = new DaoRetrospectiva();
            this.ListarRegistro();
        }
        private void ListarRegistro()
        {
            sprintAtual = new SprintMap().GetSprintAtual();
            listaRetrospectiva = Dao.ObterLista(Restrictions.Disjunction().Add(Restrictions.Eq(Projections.Property<Retrospectiva>(t => t.Sprint.IdSprint), sprintAtual.IdSprint)));
        }
        public IList<Retrospectiva> ListaRetrospectiva
        {
            get { return listaRetrospectiva; }
        }
        public Retrospectiva RetrospectivaAtual
        {
            get { return (retrospectivaAtual); }
        }
        public Sprint SprintAtual
        {
            get { return (sprintAtual); }
        }
        public void SalvarRetrospectivaAtual()
        {
            Dao.Persistir(retrospectivaAtual);

            if ((listaRetrospectiva.Last() != null) && (!listaRetrospectiva.Last().Existe))
                listaRetrospectiva.Remove(listaRetrospectiva.Last());

            if (!listaRetrospectiva.Contains(retrospectivaAtual))
                listaRetrospectiva.Add(retrospectivaAtual);
        }
        public void EliminarRetrospectivaAtual()
        {
            Dao.Eliminar(retrospectivaAtual);
            listaRetrospectiva.Remove(retrospectivaAtual);
        }
        public void ConverterEmTarefa()
        {
            new DaoTarefa().Persistir(new Tarefa("Retrospectiva: " + retrospectivaAtual.Descricao));
            this.EliminarRetrospectivaAtual();
        }
        public RetrospectivaControl SetRetrospectivaAtual(Retrospectiva value)
        {
            retrospectivaAtual = value;
            return (this);
        }
        public void DoNovaRetrospectiva()
        {
            var retrospectiva = new Retrospectiva();
            retrospectiva.Sprint = sprintAtual;
            SetRetrospectivaAtual(retrospectiva);
        }
    }
}