using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MVVMTemplate.Model;
using MVVMTemplate.Properties;
using System.Net;

namespace MVVMTemplate.DataAccess
{
    public class DataItemRepository
    {
        private HttpClient client;

        public ObservableCollection<DataItem> DataItems { get; private set; }

        public DataItemRepository()
        {
            this.client        = new HttpClient();
            client.BaseAddress = new Uri(Settings.Default.WebServiceAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            DataItems = new ObservableCollection<DataItem>();
        }

        public void GetListHttpClient()
        {
            HttpResponseMessage response = client.GetAsync("api/Values").Result;    
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                ObservableCollection<DataItem> dataItems = JsonConvert.DeserializeObject<ObservableCollection<DataItem>>(result);
                DataItems = dataItems;
            }
        }

        public void GetSingleHttpClient(int id)
        {
            HttpResponseMessage response = client.GetAsync("api/Values/" + id).Result;  
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                DataItem dataItem = JsonConvert.DeserializeObject<DataItem>(result);
                if (dataItem != null)
                    DataItems.Add(dataItem);
            }
        }

        public void GetListWebClient()
        {
            using (WebClient webClient = new WebClient())
            {
                var result = webClient.DownloadString(Settings.Default.WebServiceAddress + "api/Values");

                ObservableCollection<DataItem> dataItems = JsonConvert.DeserializeObject<ObservableCollection<DataItem>>(result);
                DataItems = dataItems;
            }
        }

        public void GetSingleWebClient(int id)
        {
            using (WebClient webClient = new WebClient())
            {
                var result = webClient.DownloadString(Settings.Default.WebServiceAddress + "api/Values/" + id);

                DataItem dataItems = JsonConvert.DeserializeObject<DataItem>(result);
                DataItems.Add(dataItems);
            }
        }


        public void PostHttpClient()
        {
            DataItem item = new DataItem { UserId = 5, UserName = "test5" };
            var response = client.PostAsJsonAsync("api/Values", item).Result;
        }
    }
}
