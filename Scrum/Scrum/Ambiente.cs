using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrum.Model;

namespace Scrum
{
    public class Ambiente
    {
        private static Ambiente instance;
        private Sprint sprintAtual;
        public Sprint SprintAtual
        {
            get
            {
                if (sprintAtual == null)
                    sprintAtual = new DaoSprint().GetAtual();
                return (sprintAtual);
            }
        }
        public static Ambiente GetInstance()
        {
            if (instance == null)
                instance = new Ambiente();
            return (instance);
        }




    }
}
