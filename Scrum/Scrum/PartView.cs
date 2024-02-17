﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Loader.Entity;
using Scrum.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using ScrumValidacao;
using System.Runtime.ConstrainedExecution;

namespace Scrum
{
    public interface IPartRegra
    {
        void Alterar(Tarefa tarefa);
        Junction GetCondicaoWhere();
    }

    public partial class PartView : UserControl
    {
        private PartPresenter presenter;
        private Color CorSelecionado = Color.Yellow;
        private Color CorNormal = Color.White;
        public PartView()
        {
            InitializeComponent();
        }

        public PartView SetPresenter(PartPresenter Value)
        {
            presenter = Value;
            return (this);
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {          
            if ((grid.SelectedRows.Count > 0) && (grid.SelectedRows[0].DataBoundItem != null) && (grid.SelectedRows[0].DataBoundItem.GetType() == typeof(Tarefa)))
                presenter.SetTarefaAtual((grid.SelectedRows[0].DataBoundItem as Tarefa));
            else
                presenter.SetTarefaAtual(null);
        }

        private void DefinirCorSelecionado(Color cor)
        {
            DataGridViewCellStyle estilo = new DataGridViewCellStyle();
            estilo.SelectionBackColor = cor;
            estilo.SelectionForeColor = Color.Black;
            grid.RowTemplate.DefaultCellStyle = estilo;

            foreach (DataGridViewRow row in grid.Rows)
                row.DefaultCellStyle = estilo;
        }
        private void DoDefinirCorSelecionado(Boolean ehSelecionado)
        {
            if (ehSelecionado)
                DefinirCorSelecionado(CorSelecionado);
            else
                DefinirCorSelecionado(CorNormal);
        }

        private void grid_Enter(object sender, EventArgs e)
        {
            DoDefinirCorSelecionado(true);
        }

        private void grid_Leave(object sender, EventArgs e)
        {
            DoDefinirCorSelecionado(false);
        }
    }
}
