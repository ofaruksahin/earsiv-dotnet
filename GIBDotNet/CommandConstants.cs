using GIBDotNet.Commands;
using GIBDotNet.Exceptions;
using System;
using System.Collections.Generic;

namespace GIBDotNet
{
    internal class CommandConstants
    {
        private static IDictionary<Type, string> CommandTitles = new Dictionary<Type, string>()
        {
            {typeof(CreateDraftInvoiceCommand),"EARSIV_PORTAL_FATURA_OLUSTUR" }
        };

        private static IDictionary<Type, string> PageTitles = new Dictionary<Type, string>
        {
            {typeof(CreateDraftInvoiceCommand),"RG_BASITFATURA" }
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
