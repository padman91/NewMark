using Azure;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewMarkAPI.Models;

namespace NewMarkAPI.Services
{
    public class PropertyService : IPropertyService
    {
        // Blob URI and SAS token. Hardcoded for simplicity. This can be configured in app settings.
        private readonly string _blobUri = "https://nmrkpidev.blob.core.windows.net/dev-test/dev-test.json";
        private readonly string _sasToken = @"sp=r&st=2024-10-28T10:35:48Z&se=2025-10-28T18:35:48Z&spr=https&sv=2022-11-02&sr=b&sig=bdeoPWtefikVgUGFCUs4ihsl22ZhQGu4%2B4cAfoMwd4k%3D";

        public async Task<IEnumerable<Property>> GetPropertiesFromBlobAsync()
        {
            try
            {
                // Combine the Blob URI and SAS token
                string blobUriWithSas = $"{_blobUri}?{_sasToken}";

                BlobClient blobClient = new BlobClient(new Uri(blobUriWithSas));

                using (MemoryStream ms = new MemoryStream())
                {
                    await blobClient.DownloadToAsync(ms);
                    ms.Position = 0;

                    // Assuming the blob content is JSON, you can deserialize it to an object
                    using (StreamReader reader = new StreamReader(ms))
                    {
                        string content = await reader.ReadToEndAsync();
                        var properties = JsonConvert.DeserializeObject<IEnumerable<Property>>(content);
                        return properties;
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                // Handle Azure specific exceptions
                Console.WriteLine($"Azure request failed: {ex.Message}");
                throw new Exception("Failed to download data from Azure Blob Storage.", ex);
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization exceptions
                Console.WriteLine($"JSON deserialization failed: {ex.Message}");
                throw new Exception("Failed to deserialize JSON data.", ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception("An unexpected error occurred while downloading data from Azure Blob Storage.", ex);
            }
        }
    }
}
