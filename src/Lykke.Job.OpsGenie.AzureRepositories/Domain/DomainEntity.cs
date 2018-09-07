using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Job.OpsGenie.AzureRepositories.Domain
{
    internal class DomainEntity:TableEntity
    {
        public string Domain { get; set; }

        public static string GeneratePartitionKey()
        {
            return "dmn";
        }

        public static string GenerateRowKey(string domain)
        {
            return domain;
        }

        public static  DomainEntity Create(string domainName)
        {
            return new DomainEntity
            {
                Domain = domainName,
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(domainName)
            };
        }
    }
}
