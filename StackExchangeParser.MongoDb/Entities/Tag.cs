namespace StackExchangeParser.MongoDb.Entities
{
    public class Tag
    {
        public virtual long Id { get; set; }
        public virtual string TagName { get; set; }
        public virtual int? Count { get; set; }
        public virtual long? ExcerptPostId { get; set; }
        public virtual int? WikiPostId { get; set; }
    }
}