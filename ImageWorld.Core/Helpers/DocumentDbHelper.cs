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
            var docDbClient = GetDocDbClient();

            return await docDbClient.CreateDocumentAsync(
               UriFactory.CreateDocumentCollectionUri(
                   Config.Default.DocDbName,
                   Config.Default.DocDbCollectionName
                   ),
               image);
        }

        public static async Task<Document> UpdateImageAsync(Image image)
        {
            var docDbClient = GetDocDbClient();

            return await docDbClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(
                    Config.Default.DocDbName,
                    Config.Default.DocDbCollectionName,
                    $"{image.Id}"
                ), image, 
                new RequestOptions { PartitionKey = new PartitionKey($"{image.Id}") });
        }

        public static async Task<Image> GetImageAsync(string imageGuid)
        {
            var docDbClient = GetDocDbClient();
           
            return await docDbClient
                .ReadDocumentAsync<Image>(
                    UriFactory.CreateDocumentUri(
                        Config.Default.DocDbName, 
                        Config.Default.DocDbCollectionName,
                        imageGuid),
                        new RequestOptions { PartitionKey = new PartitionKey(imageGuid) }
                        );
        }

        public static async Task DeleteImageAsync(string imageGuid)
        {
            var docDbClient = GetDocDbClient();

            await docDbClient
                .DeleteDocumentAsync(
                    UriFactory.CreateDocumentUri(
                        Config.Default.DocDbName,
                        Config.Default.DocDbCollectionName,
                        imageGuid
                        ), new RequestOptions { PartitionKey = new PartitionKey(imageGuid) }
                );
        }

        private static DocumentClient GetDocDbClient()
        {
            return new DocumentClient(
                new Uri(Config.Default.DocDbEndpointUrl),
                Config.Default.DocDbKey);
        }
    }
}
