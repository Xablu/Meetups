using System;
using DiAndIOC.Core.Interfaces;

namespace DiAndIOC.Core.Provider
{
    public class HelloTextProvider : ITextProvider
    {
        public string Text => "Hello!";
    }
}
