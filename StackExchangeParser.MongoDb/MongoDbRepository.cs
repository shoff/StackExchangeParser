namespace StackExchangeParser.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using ChaosMonkey.Guards;
    using Domain;
    using Domain.Models;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Zatoichi.Common.Infrastructure.Extensions;

    using MongoTag = Entities.Tag;
    using MongoUser = Entities.User;
    using MongoBadge = Entities.Badge;
    using MongoPost = Entities.Post;
    using MongoPostHistory = Entities.PostHistory;
    using MongoVote = Entities.Vote;
    using MongoComment = Entities.Comment;
    using Tag = Domain.Models.Tag;

    public class MongoDbRepository : IStackExchangeRepository, IMongoDbRepository
    {
        private readonly InsertOneOptions insertOneOptions;
        private readonly InsertManyOptions insertManyOptions;
        private readonly IMongoDatabase database;
        private readonly ILogger<MongoDbRepository> logger;
        private readonly IMapper mapper;

        public MongoDbRepository(
            IMapper mapper,
            ILogger<MongoDbRepository> logger,
            IOptions<MongoOptions> options)
        {
            this.mapper = mapper;
            this.logger = logger;

            var internalIdentity = new MongoInternalIdentity(Constants.ADMIN, options.Value.Username);
            var passwordEvidence = new PasswordEvidence(options.Value.Password);
            var mongoCredential = new MongoCredential(options.Value.AuthMechanism, internalIdentity, passwordEvidence);

            var settings = new MongoClientSettings
            {
                Credential = mongoCredential,
                Server = new MongoServerAddress(options.Value.MongoHost, int.Parse(options.Value.Port)),
                GuidRepresentation = GuidRepresentation.Standard
            };

            var client = new MongoClient(settings);
            this.database = client.GetDatabase(options.Value.DefaultDb);

            this.insertManyOptions = new InsertManyOptions
            {
                BypassDocumentValidation = false,
                IsOrdered = false
            };

            this.insertOneOptions = new InsertOneOptions
            {
                BypassDocumentValidation = false
            };
        }

        private IMongoCollection<MongoPost> PostCollection =>
            this.database.GetCollection<MongoPost>(typeof(MongoPost).Name);

        private IMongoCollection<MongoPostHistory> PostHistoryCollection =>
            this.database.GetCollection<MongoPostHistory>(typeof(MongoPostHistory).Name);

        private IMongoCollection<MongoUser> UserCollection =>
            this.database.GetCollection<MongoUser>(typeof(MongoUser).Name);

        private IMongoCollection<MongoBadge> BadgeCollection =>
            this.database.GetCollection<MongoBadge>(typeof(MongoBadge).Name);

        private IMongoCollection<MongoComment> CommentCollection =>
            this.database.GetCollection<MongoComment>(typeof(MongoComment).Name);

        private IMongoCollection<MongoVote> VoteCollection =>
            this.database.GetCollection<MongoVote>(typeof(MongoVote).Name);

        private IMongoCollection<MongoTag> TagCollection =>
            this.database.GetCollection<MongoTag>(typeof(MongoTag).Name);

        public ICollection<User> Users()
        {
            return this.mapper.ProjectTo<User>(UserCollection.AsQueryable()).ToList();
        }

        public ICollection<Post> Posts()
        {
            return this.mapper.ProjectTo<Post>(PostCollection.AsQueryable()).ToList();
        }

        public ICollection<Comment> Comments()
        {
            return this.mapper.ProjectTo<Comment>(CommentCollection.AsQueryable()).ToList();
        }

        public ICollection<Tag> Tags()
        {
            return this.mapper.ProjectTo<Tag>(TagCollection.AsQueryable()).ToList();
        }

        public ICollection<Badge> Badges()
        {
            return this.mapper.ProjectTo<Badge>(BadgeCollection.AsQueryable()).ToList();
        }

        public ICollection<PostHistory> PostHistories()
        {
            return this.mapper.ProjectTo<PostHistory>(PostHistoryCollection.AsQueryable()).ToList();
        }

        public ICollection<Vote> Votes()
        {
            return this.mapper.ProjectTo<Vote>(VoteCollection.AsQueryable()).ToList();
        }

        public async Task AddUsersAsync(ICollection<User> users, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(users, nameof(users));
            if (this.CollectionExists<MongoUser>())
            {
                await this.database.DropCollectionAsync(typeof(MongoUser).Name, cancellationToken)
                    .ConfigureAwait(false);
            }

            await UserCollection.InsertManyAsync(users.Map(m => 
                this.mapper.Map<MongoUser>(m)).ToList(), 
                this.insertManyOptions, cancellationToken);
        }

        public async Task AddPostsAsync(ICollection<Post> posts, CancellationToken cancellationToken = default)
        {

            Guard.IsNotNull(posts, nameof(posts));
            if (this.CollectionExists<MongoPost>())
            {
                await this.database.DropCollectionAsync(typeof(MongoPost).Name, cancellationToken)
                    .ConfigureAwait(false);
            }
            await PostCollection.InsertManyAsync(posts.Map(m => 
                    this.mapper.Map<MongoPost>(m)).ToList(), 
                this.insertManyOptions, cancellationToken);
        }

        public async Task AddCommentsAsync(ICollection<Comment> comments, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(comments, nameof(comments));
            if (this.CollectionExists<MongoComment>())
            {
                await this.database.DropCollectionAsync(typeof(MongoComment).Name, cancellationToken)
                    .ConfigureAwait(false);
            }
            await CommentCollection.InsertManyAsync(comments.Map(t =>
                    this.mapper.Map<MongoComment>(t)).ToList(),
                this.insertManyOptions, cancellationToken);
        }

        public async Task AddTagsAsync(ICollection<Tag> tags, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(tags, nameof(tags));
            if (this.CollectionExists<MongoTag>())
            {
                await this.database.DropCollectionAsync(typeof(MongoTag).Name, cancellationToken)
                    .ConfigureAwait(false);
            }
            await TagCollection.InsertManyAsync(tags.Map(t =>
                    this.mapper.Map<MongoTag>(t)).ToList(),
                this.insertManyOptions, cancellationToken);
        }

        public async Task AddBadgesAsync(ICollection<Badge> badges, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(badges, nameof(badges));
            if (this.CollectionExists<MongoBadge>())
            {
                await this.database.DropCollectionAsync(typeof(MongoBadge).Name, cancellationToken)
                    .ConfigureAwait(false);
            }
            await BadgeCollection.InsertManyAsync(badges.Map(t =>
                    this.mapper.Map<MongoBadge>(t)).ToList(),
                this.insertManyOptions, cancellationToken);
        }

        public async Task AddPostHistoriesAsync(ICollection<PostHistory> postHistories, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(postHistories, nameof(postHistories));
            if (this.CollectionExists<MongoPostHistory>())
            {
                await this.database.DropCollectionAsync(typeof(MongoPostHistory).Name, cancellationToken)
                    .ConfigureAwait(false);
            }
            await PostHistoryCollection.InsertManyAsync(postHistories.Map(t => 
                    this.mapper.Map<MongoPostHistory>(t)).ToList(), 
                this.insertManyOptions, cancellationToken);
        }

        public async Task AddVotesAsync(ICollection<Vote> votes, CancellationToken cancellationToken = default)
        {
            Guard.IsNotNull(votes, nameof(votes));
            if (this.CollectionExists<MongoPostHistory>())
            {
                await this.database.DropCollectionAsync(typeof(MongoVote).Name, cancellationToken);
            }
            await VoteCollection.InsertManyAsync(votes.Map(t =>
                    this.mapper.Map<MongoVote>(t)).ToList(),
                this.insertManyOptions, cancellationToken);
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return this.database.GetCollection<T>(typeof(T).Name).AsQueryable();
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            Guard.IsNotNull(expression, nameof(expression));
            this.logger.LogDebug($"Where:{expression.Body}");
            return this.All<T>().Where(expression);
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            Guard.IsNotNull(predicate, nameof(predicate));
            this.logger.LogDebug($"Delete:{predicate.Body}");
            _ = this.database.GetCollection<T>(typeof(T).Name).DeleteMany(predicate);
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            Guard.IsNotNull(expression, nameof(expression));
            this.logger.LogDebug($"Single:{expression.Body}");
            return this.All<T>().Where(expression).SingleOrDefault();
        }

        private bool CollectionExists<T>() where T : class, new()
        {
            this.logger.LogDebug($"CollectionExists:{typeof(T).Name}");
            return this.CollectionExists<T>(typeof(T).Name);
        }

        private bool CollectionExists<T>(string collectionName) where T : class, new()
        {
            Guard.IsNotNullOrWhitespace(collectionName, nameof(collectionName));
            var collection = this.database.GetCollection<T>(collectionName);
            var filter = new BsonDocument();
            var totalCount = collection.CountDocuments(filter);
            return totalCount > 0;
        }

        public Task AddAsync<T>(T item, CancellationToken cancellationToken = default)
            where T : class, new()
        {
            Guard.IsNotDefault(item, nameof(item));
            this.logger.LogDebug($"Add:{typeof(T).Name} {item.ToJson()}");

            return this.database.GetCollection<T>(typeof(T).Name)
                .InsertOneAsync(item,this.insertOneOptions, cancellationToken);
        }

        public Task AddAsync<T>(IEnumerable<T> items, CancellationToken cancellationToken = default)
            where T : class, new()
        {
            // ReSharper disable PossibleMultipleEnumeration
            Guard.IsNotNullOrEmpty(items, nameof(items));

            return this.database.GetCollection<T>(typeof(T).Name)
                .InsertManyAsync(items, this.insertManyOptions, cancellationToken);
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}