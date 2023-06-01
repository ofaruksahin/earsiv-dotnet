using GIBDotNet.Exceptions;
using System;
using System.Collections.Generic;

namespace GIBDotNet
{
    internal class CommandConstants
    {
        private static IDictionary<Type, string> CommandTitles = new Dictionary<Type, string>()
        {

        };

        private static IDictionary<Type, string> PageTitles = new Dictionary<Type, string>
        {

        };

        public static string GetCommandTitle(Type type)
        {
            return GetValue(CommandTitles, type);
        }

        public static string GetPageTitle(Type type)
        {
            return GetValue(PageTitles, type);
        }

        private static string GetValue(IDictionary<Type, string> dictionary,Type key)
        {
            if (!dictionary.ContainsKey(key))
                throw new UnsupportedCommandException(key);

            dictionary.TryGetValue(key, out string title);
            return title;
        }
    }
}
