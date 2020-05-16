using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Clientes
{
    public class ClienteEmailNotification
    {
        #region Propriedades

        public string Origem { get; private set; }

        public string Destino { get; private set; }

        public string Assunto { get; private set; }

        public string Mensagem { get; private set; }

        #endregion

        #region Construtor

        public ClienteEmailNotification(string origem, string destino, string assunto, string mensagem)
        {
            Origem = origem;
            Destino = destino;
            Assunto = assunto;
            Mensagem = mensagem;
        }

        #endregion

        #region Metodos

        #endregion
    }
}
