using GIBDotNet.Commands.RequestModels;
using System.Collections.Generic;
using System.Text.Json;

namespace GIBDotNet.Commands.GIBRequestModels
{
    public class CreateDraftInvoiceGIBRequestModel
    {
        public string Invoice { get; private set; } = string.Empty;

        public class MalHizmetTable
        {
            public string malHizmet { get; set; }
            public int miktar { get; set; } = 1;
            public string birim { get; set; } = "C62";
            public string birimFiyat { get; set; }
            public string fiyat { get; set; }
            public int iskontoOrani { get; set; } = 0;
            public string iskontoTutari { get; set; } = "0";
            public string iskontoNedeni { get; set; } = "";
            public string malHizmetTutari { get; set; }
            public string kdvOrani { get; set; }
            public int vergiOrani { get; set; } = 0;
            public string kdvTutari { get; set; }
            public string vergininKdvTutari { get; set; }
            public string ozelMatrahTutari { get; set; }
            public string hesaplananotvtevkifatakatkisi { get; set; }
        }

        public class Fatura
        {
            public string faturaUuid { get; set; }
            public string belgeNumarasi { get; set; } = "";
            public string faturaTarihi { get; set; }
            public string saat { get; set; }
            public string paraBirimi { get; set; } = "TRY";
            public string dovzTLkur { get; set; } = "0";
            public string faturaTipi { get; set; } = "SATIS";
            public string hangiTip { get; set; } = "5000/30000";
            public string vknTckn { get; set; }
            public string aliciUnvan { get; set; }
            public string aliciAdi { get; set; }
            public string aliciSoyadi { get; set; }
            public string binaAdi { get; set; }
            public string binaNo { get; set; }
            public string kapiNo { get; set; }
            public string kasabaKoy { get; set; }
            public string vergiDairesi { get; set; }
            public string ulke { get; set; } = "Türkiye";
            public string bulvarcaddesokak { get; set; }
            public string irsaliyeNumarasi { get; set; }
            public string irsaliyeTarihi { get; set; }
            public string mahalleSemtIlce { get; set; }
            public string sehir { get; set; } = " ";
            public string postaKodu { get; set; }
            public string tel { get; set; }
            public string fax { get; set; }
            public string eposta { get; set; }
            public string websitesi { get; set; }
            public List<object> iadeTable { get; set; } = new List<object>();
            public string vergiCesidi { get; set; } = " ";
            public List<MalHizmetTable> malHizmetTable { get; set; } = new List<MalHizmetTable>();
            public string tip { get; set; } = "İskonto";
            public string matrah { get; set; }
            public string malhizmetToplamTutari { get; set; }
            public string toplamIskonto { get; set; } = "0";
            public string hesaplanankdv { get; set; }
            public string vergilerToplami { get; set; }
            public string vergilerDahilToplamTutar { get; set; }
            public string odenecekTutar { get; set; }
            public string not { get; set; }
            public string siparisNumarasi { get; set; }
            public string siparisTarihi { get; set; }
            public string fisNo { get; set; }
            public string fisTarihi { get; set; }
            public string fisSaati { get; set; }
            public string fisTipi { get; set; } = " ";
            public string zRaporNo { get; set; }
            public string okcSeriNo { get; set; }
        }

        public CreateDraftInvoiceGIBRequestModel(CreateDraftInvoiceRequestModel requestModel)
        {
            var fatura = new Fatura();
            fatura.faturaUuid = requestModel.Ettn;
            fatura.belgeNumarasi = string.Empty;
            fatura.faturaTarihi = requestModel.InvoiceDate.ToString("dd/MM/yyyy").Replace(".", "/");
            fatura.saat = "00:00:00";
            fatura.paraBirimi = "TRY";
            fatura.dovzTLkur = "0";
            fatura.faturaTipi = "SATIS";
            fatura.hangiTip = "5000/30000";
            fatura.vknTckn = requestModel.VKN;
            fatura.aliciAdi = requestModel.Name;
            fatura.aliciSoyadi = requestModel.Surname;
            fatura.binaAdi = string.Empty;
            fatura.binaNo = string.Empty;
            fatura.kapiNo = string.Empty;
            fatura.kasabaKoy = string.Empty;
            fatura.vergiDairesi = requestModel.TaxOffice;
            fatura.ulke = "Türkiye";
            fatura.bulvarcaddesokak = requestModel.Address;
            fatura.irsaliyeNumarasi = string.Empty;
            fatura.irsaliyeTarihi = string.Empty;
            fatura.mahalleSemtIlce = requestModel.Address;
            fatura.sehir = " ";
            fatura.postaKodu = string.Empty;
            fatura.tel = string.Empty;
            fatura.fax = string.Empty;
            fatura.eposta = string.Empty;
            fatura.websitesi = string.Empty;
            fatura.vergiCesidi = string.Empty;
            fatura.tip = "İskonto";
            fatura.not = string.Empty;
            fatura.siparisNumarasi = string.Empty;
            fatura.siparisTarihi = string.Empty;
            fatura.fisNo = string.Empty;
            fatura.fisTarihi = string.Empty;
            fatura.fisSaati = " ";
            fatura.zRaporNo = string.Empty;
            fatura.okcSeriNo = string.Empty;
            fatura.matrah = Format(requestModel.SubTotal - requestModel.Tax);
            fatura.malhizmetToplamTutari = fatura.matrah;
            fatura.hesaplanankdv = Format(requestModel.Tax);
            fatura.vergilerToplami = fatura.hesaplanankdv;
            fatura.vergilerDahilToplamTutar = Format(requestModel.SubTotal);
            fatura.odenecekTutar = fatura.vergilerDahilToplamTutar;

            foreach (var item in requestModel.Items)
            {
                MalHizmetTable urun = new MalHizmetTable();
                urun.malHizmet = item.Name;
                urun.miktar = item.Piece;
                urun.birim = "C62";
                urun.birimFiyat = Format((item.SubTotal - item.Tax) / item.Piece);
                urun.fiyat = Format(item.SubTotal);
                urun.malHizmetTutari = Format(item.SubTotal - item.Tax);
                urun.kdvOrani = Format((item.SubTotal * 100 / (item.SubTotal - item.Tax)) - 100);
                urun.kdvTutari = Format(item.Tax);
                urun.iskontoOrani = 0;
                urun.iskontoTutari = "0";
                urun.iskontoNedeni = "";
                urun.vergiOrani = 0;
                urun.vergininKdvTutari = "0";
                urun.ozelMatrahTutari = "0";
                urun.hesaplananotvtevkifatakatkisi = "0";
                fatura.malHizmetTable.Add(urun);
            }

            Invoice = JsonSerializer.Serialize(fatura);
        }

        string Format(double val) => val.ToString().Replace(",", ".");
    }
}
