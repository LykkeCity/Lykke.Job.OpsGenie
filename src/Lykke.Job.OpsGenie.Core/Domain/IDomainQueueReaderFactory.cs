namespace Lykke.Job.OpsGenie.Core.Domain
{
    public interface IDomainQueueReaderFactory
    {
        IDomainQueueReader Create(string domain);
    }
}
