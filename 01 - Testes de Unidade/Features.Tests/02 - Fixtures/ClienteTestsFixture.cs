using Features.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Features.Tests._02___Fixtures
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection: ICollectionFixture<ClienteTestsFixture> {}

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            return new Cliente(Guid.NewGuid(),
                               "André",
                               "Moura",
                               DateTime.Now.AddYears(-30),
                               "andre.moura@email.com",
                               true,
                               DateTime.Now);
        }

        public Cliente GerarClienteInvalido()
        {
            return new Cliente(Guid.NewGuid(),
                               "",
                               "",
                               DateTime.Now,
                               "andre.moura@email.com",
                               true,
                               DateTime.Now);
        }

        public void Dispose()
        {            
        }
    }
}
