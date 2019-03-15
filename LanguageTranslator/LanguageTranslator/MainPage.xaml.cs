﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageTranslator
{
    class AppCache
    {
        #region Read-only methods - Due the methods being static, we can refer to them without creating objects
        public static string APIKey { get; } = @"trnsl.1.1.20190314T153953Z.82626c9c38180ce0.c966002352eefc59e595db2a168f997d19814cbc";

        /* To check if this link is valid and the API key is valid, replace '{0}' with the API key and '{1}' with your source language e.g. 'en'
         * All available languages - and the shorthand for each - will be returned in JSON format
         * Here, the service used is 'getLangs'
         */
        public static string getLanguages { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={0}&ui={1}";

        /* To check if this link is valid and the API key is valid, replace '{0}' with the API key and '{1}' with a word e.g text=Hello
         * A status code plus the shorthand of the detected language will be returned. In this example, ' "code": 200, "lang": "en" ' will be returned
         * Here, the service used here is 'detect'
         */ 
        public static string detectSourceLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/detect?key={0}&ui={1}";

        /* To check if this link is valid and the API key is valid, replace '{0}' with the API key,'{1}' with a word e.g text=Hello,
         * and '{2}' with the shorthand of the language you wish to translate the text to e.g. 'fr' to translate the text into French
         * A status code, the two languages the text is in, and the translated text will be returned. In this example, ' "code": 200, "lang": "en-fr", 
         * "text": [ *translated text* ] ' will be returned
         * Here, the service used here is 'translate'
         */
        public static string translateLanguage { get; } = @"https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}";
        #endregion
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void restSharpSetup()
        {
            // Create new RestSharp client
            var client = new RestClient()
            {
                BaseUrl = new Uri(string.Format(AppCache.detectSourceLanguage, AppCache.APIKey, entText.Text))
            };

            // Create new RestSharp request
            var request = new RestRequest()
            {
                Method = Method.GET
            };

            var serverResponse = client.Execute(request);
        }

        private void EntText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnNAME_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnTranslate_Clicked(object sender, EventArgs e)
        {

        }

        /* Detects the source language i.e detects what language the entered text is in.
         * It does this through a library called 'RestSharp'
         */ 
        private void BtnDetectSourceLanguage_Clicked(object sender, EventArgs e)
        {
            restSharpSetup();

        }
    }
}