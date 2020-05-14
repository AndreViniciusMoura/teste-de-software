using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class FuncionarioFactory
    {
        #region Propriedades

        #endregion

        #region Construtor

        #endregion

        #region Metodos

        public static Funcionario Criar(string nome, double salario)
        {
            return new Funcionario(nome, salario);
        }

        #endregion
    }
}
