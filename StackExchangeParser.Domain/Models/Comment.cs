namespace StackExchangeParser.Domain.Models
{
    using System;

    public class Comment
    {
        public virtual long Id { get; set; }
        public virtual long? PostId { get; set; }
        public virtual int Score { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual long? UserId { get; set; }
        public virtual User User { get; set; }
    }
}