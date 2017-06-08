using System;
using System.Threading.Tasks;
using ImageWorld.Core.Class;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ImageWorld.Core.Helpers
{
    public static class DocumentDbHelper
    {
        public static async Task<Document> AddImageToDbAsync(Image image)
        {
            var docDbClient = new DocumentClient(
                new Uri(Config.Default.DocDbEndpointUrl),
                Config.Default.DocDbKey);

             return await docDbClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    Config.Default.DocDbName, 
                    Config.Default.DocDbCollectionName
                    ),
                image);
        }


    }
}
