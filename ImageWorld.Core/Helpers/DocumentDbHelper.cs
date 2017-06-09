using System;
using System.Collections.Generic;
using System.Linq;
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

        public static Document UpdateImage(Image image)
        {
            var docDbClient = GetDocDbClient();

            return docDbClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(
                    Config.Default.DocDbName,
                    Config.Default.DocDbCollectionName,
                    $"{image.id}"
                ), image)
                .Result;
        }

        private class IdOnly
        {
            public string id { get; set; }
        }

        public static IEnumerable<string> GetAllImageIds()
        {
            var docDbClient = GetDocDbClient();

            var allImageIds = docDbClient
                .CreateDocumentQuery<IdOnly>(
                    UriFactory.CreateDocumentCollectionUri(
                        Config.Default.DocDbName,
                        Config.Default.DocDbCollectionName),
                    "SELECT c.id AS id FROM c")
                .ToList()
                .Select(r => r.id);
                

            return allImageIds;
        }

        /// <summary>
        /// return null if not found
        /// </summary>
        /// <param name="imageGuid"></param>
        /// <returns></returns>
        public static async Task<Image> GetImageAsync(string imageGuid)
        {
            var docDbClient = GetDocDbClient();

            // I hate that they force you to use try-catch because no exists() api
            try
            {
                return await docDbClient
                    .ReadDocumentAsync<Image>(
                        UriFactory.CreateDocumentUri(
                            Config.Default.DocDbName,
                            Config.Default.DocDbCollectionName,
                            imageGuid)
                    );
            }

            catch(DocumentClientException)
            {
                return null;
            }
        }

        public static async Task DeleteImageAsync(string imageGuid)
        {
            var docDbClient = GetDocDbClient();

            await docDbClient
                .DeleteDocumentAsync(
                    UriFactory.CreateDocumentUri(
                        Config.Default.DocDbName,
                        Config.Default.DocDbCollectionName,
                        imageGuid)
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
