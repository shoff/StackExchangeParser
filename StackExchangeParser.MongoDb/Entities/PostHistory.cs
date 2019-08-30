namespace StackExchangeParser.MongoDb.Entities
{
    using System;
    using Domain.Models;

    public class PostHistory : IPostHistory
    {
        public virtual long Id { get; set; }
        public virtual int PostHistoryTypeId { get; set; }
        public virtual long? PostId { get; set; }
        public virtual string RevisionGUID { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual long? UserId { get; set; }
        public virtual string Text { get; set; }
        public virtual string Comment { get; set; }
    }
}