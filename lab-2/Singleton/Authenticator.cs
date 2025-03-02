using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Authenticator
    {
        private static readonly Lazy<Authenticator> instance = new Lazy<Authenticator>(() => new Authenticator());

        private Authenticator()
        {
            Console.WriteLine("Authenticator instance created.");
        }

        public static Authenticator Instance => instance.Value;

        public void Authenticate(string username)
        {
            Console.WriteLine($"User {username} authenticated.");
        }
    }
}
