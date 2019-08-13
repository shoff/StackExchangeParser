namespace StackExchangeParser.Configuration
{
    using System;
    using System.Linq;
    using Domain.Data;
    using EF;
    using EFCore.BulkExtensions;
    using Microsoft.Extensions.DependencyInjection;

    internal static class Seeder
    {
        internal static void SeedDatabase(IServiceProvider sp)
        {
            var up = sp.GetService<IUserParser>();
            var pp = sp.GetService<IPostParser>();
            var cp = sp.GetService<ICommentParser>();
            var bp = sp.GetService<IBadgeParser>();
            var vp = sp.GetService<IVoteParser>();
            var tp = sp.GetService<ITagParser>();
            var php = sp.GetService<IPostHistoryParser>();
            var context = sp.GetService<StackExchangeDbContext>();
            var users = up.Parse();
            Console.WriteLine($"Found {users.Count} users");

            var comments = cp.Parse();
            Console.WriteLine($"Found {comments.Count} comments");

            var posts = pp.Parse();
            Console.WriteLine($"Found {posts.Count} posts");

            var postHistories = php.Parse();
            Console.WriteLine($"Found {postHistories.Count} post histories");

            var badges = bp.Parse();
            Console.WriteLine($"Found {badges.Count} badges");

            var votes = vp.Parse();
            Console.WriteLine($"Found {votes.Count} votes");

            var tags = tp.Parse();
            Console.WriteLine($"Found {tags.Count} tags");



            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.ChangeTracker.AcceptAllChanges();

            try
            {
                Console.WriteLine("Beginning insertion of users ...");
                context.BulkInsert(users.ToList());
                Console.WriteLine("Users added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Beginning insertion of posts ...");
                context.BulkInsert(posts.ToList());
                Console.WriteLine("Posts added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Beginning insertion of comments ...");
                context.BulkInsert(comments.ToList());
                Console.WriteLine("Comments added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Beginning insertion of badges ...");
                context.BulkInsert(badges.ToList());
                Console.WriteLine("Badges added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Beginning insertion of votes ...");
                context.BulkInsert(votes.ToList());
                Console.WriteLine("Votes added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Beginning insertion of tags ...");
                context.BulkInsert(tags.ToList());
                Console.WriteLine("Tags added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Beginning insertion of post histories ...");
                context.BulkInsert(postHistories.ToList());
                Console.WriteLine("Post Histories added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            context.Dispose();
        }
    }
}