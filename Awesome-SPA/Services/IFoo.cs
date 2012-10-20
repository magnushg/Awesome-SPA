using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome_SPA.Services
{
    public interface IFoo
    {
        string GetValues();
    }

    public class Foo : IFoo
    {
        public string GetValues()
        {
            return "Hello";
        }
    }
}
