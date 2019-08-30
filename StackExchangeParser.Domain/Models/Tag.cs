namespace StackExchangeParser.Domain.Models
{
    public interface ITag
    {
        long Id { get; set; }
        string TagName { get; set; }
        int? Count { get; set; }
        long? ExcerptPostId { get; set; }
        int? WikiPostId { get; set; }
    }

    public class Tag : ITag
    {
        public virtual long Id { get; set; }
        public virtual string TagName { get; set; }
        public virtual int? Count { get; set; }
        public virtual long? ExcerptPostId { get; set; }
        public virtual int? WikiPostId { get; set; }
    }
}