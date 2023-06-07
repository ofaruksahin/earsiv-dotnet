using GIBDotNet.Commands;
using GIBDotNet.Exceptions;
using System;
using System.Collections.Generic;
using static GIBDotNet.Commands.SendVerifySMSCommand;

namespace GIBDotNet
{
    internal class CommandConstants
    {
        private static IDictionary<Type, string> CommandTitles = new Dictionary<Type, string>()
        {
            {typeof(CreateDraftInvoiceCommand),"EARSIV_PORTAL_FATURA_OLUSTUR" },
            {typeof(DownloadHTMLCommand),"EARSIV_PORTAL_BELGE_INDIR" },
            {typeof(GetInvoiceByEttnCommand),"EARSIV_PORTAL_TASLAKLARI_GETIR" },
            {typeof(GetInvoicesByDateRangeCommand),"EARSIV_PORTAL_TASLAKLARI_GETIR" },
            {typeof(DeleteInvoiceCommand),"EARSIV_PORTAL_FATURA_SIL" },
            {typeof(SendVerifySMSCommandStep1),"EARSIV_PORTAL_TELEFONNO_SORGULA" },
            {typeof(SendVerifySMSCommandStep2),"SIDE.GET_EAGER_BF_DEFS" }
        };

        private static IDictionary<Type, string> PageTitles = new Dictionary<Type, string>
        {
            {typeof(CreateDraftInvoiceCommand),"RG_BASITFATURA" },
            {typeof(GetInvoiceByEttnCommand),"RG_TASLAKLAR" },
            {typeof(GetInvoicesByDateRangeCommand),"RG_TASLAKLAR" },
            {typeof(DeleteInvoiceCommand),"RG_TASLAKLAR" },
            {typeof(SendVerifySMSCommandStep1),"RG_BASITTASLAKLAR" },
            {typeof(SendVerifySMSCommandStep2),"undefined" }
        };

        public static string GetCommandTitle(Type type)
        {
            return GetValue(CommandTitles, type);
        }

        public static string GetPageTitle(Type type)
        {
            return GetValue(PageTitles, type);
        }

        private static string GetValue(IDictionary<Type, string> dictionary, Type key)
        {
            if (!dictionary.ContainsKey(key))
                throw new UnsupportedCommandException(key);

            dictionary.TryGetValue(key, out string title);
            return title;
        }
    }
}