using System;
using DiAndIOC.Core.Interfaces;

namespace DiAndIOC.Core.Provider
{
    public class GoodbyeTextProvider : ITextProvider
    {
        public string Text => "Goodbye!";
    }
}
