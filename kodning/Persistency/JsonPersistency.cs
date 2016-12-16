using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using kodning.Model;

namespace kodning.Persistency
{
    public class JsonPersistency
    {
        //StorageFolder localfolder = null;
        ////private KuvertCatalogSingleton Instance { get; set; }
        //public async void GemDataTilDiskAsync()
        //{
        //    string jsonText = KuvertCatalogSingleton.Instance.MandagListe.SaveJson();

        //    StorageFile lisa = await localfolder.CreateFileAsync(Kuvertfilnavn, CreationCollisionOption.ReplaceExisting);
        //    await FileIO.WriteTextAsync(lisa, jsonText);
        //}


        //public async void HentDataFraDiskAsync()
        //{

        //    try
        //    {
        //        StorageFile lisa = await localfolder.GetFileAsync(Kuvertfilnavn);

        //        string jsonText = await FileIO.ReadTextAsync(lisa);

        //        Instance.MandagListe.Clear();
        //        //this.KuvertListenMandag.Clear();

        //        //metoden på medarbejderlisten
        //        //KuvertListenMandag.IndsætJson(jsonText);
        //        Instance.MandagListe.HentJson(jsonText);

        //        // Try og catch for at fange en exception for at undgå grimme fejlmeddelser
        //    }
        //    catch (Exception)
        //    {
        //        //Popup vindue til at fortælle brugeren at filen ikke blev fundet. 
        //        MessageDialog messageDialog = new MessageDialog("Filen ikke fundet. Har du fjernet den?");
        //        await messageDialog.ShowAsync();
        //        //throw;
        //    }
        //}
    }
}
