using BlogAndPosts.Models;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace BlogAndPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool codeTerminator = true;

            while (codeTerminator)
            {
                string input = "5";
                Console.WriteLine("Enter Your Selection:");
                Console.WriteLine($"1) Display all blogs\n2) Add Blog\n 3) Create Post\n4) Display Posts\n5) Exit");
                input = Console.ReadLine();
                if (input == "1")
                {
                     using (var db = new BlogContext())
                    {
                         Console.WriteLine("Here is the list of blogs");
                         foreach (var b in db.Blogs)
                          {
                            Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                          }
                        
                    }
                }
                else if(input == "2")
                {
                    Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();

                    if (string.IsNullOrEmpty(blogName))
                    {
                        Console.WriteLine("Please Enter a valid Blog Name!");
                        Console.WriteLine("Enter your Blog name");
                        blogName = Console.ReadLine();
                    }
                    // Create new Blog
                    var blog = new Blog();
                    blog.Name = blogName;

                    // Save blog object to database
                    using (var db = new BlogContext())
                    {
                        db.Add(blog);
                        db.SaveChanges();
                    }
                }
                else if(input == "3") 
                {
                    var post = new Post();

                    Console.WriteLine("Enter your Post title");

                    var postName = Console.ReadLine();

                    if (string.IsNullOrEmpty(postName))
                    {
                        Console.WriteLine("Please Enter a valid Post Title!");
                        Console.WriteLine("Enter your Post Title: ");
                        postName = Console.ReadLine();
                    }

                    post.Title = postName;

                    Console.WriteLine("Enter Post Content: ");

                    var postContnt = Console.ReadLine();

                    if (string.IsNullOrEmpty(postContnt))
                    {
                        Console.WriteLine("Please Add text to your post!");
                        Console.WriteLine("Enter your Post Content: ");
                        postContnt = Console.ReadLine();
                    }
                    post.Content = postContnt;

                    Console.WriteLine("Enter BlogId of Post: ");
   
                    var blogsIds = Console.ReadLine();

                    if (string.IsNullOrEmpty(blogsIds))
                    {
                        Console.WriteLine("BlogId cannot be empty! Enter BlogId: ");
                        blogsIds = Console.ReadLine();
                    }
                    int blogId;
                    while (!int.TryParse(blogsIds, out blogId))
                    {
                        Console.WriteLine("BlogId must be a number! Enter valid BlogId: ");

                    }
                    post.BlogId = blogId;
                    using (var context = new BlogContext())
                    {
                        var blog = context.Blogs.FirstOrDefault(x => x.BlogId == blogId);
                        if (blog == null)
                        {
                            Console.WriteLine("Blog does not exist!");
                        }
                        else
                        {
                            context.Posts.Add(post);
                            context.SaveChanges();
                        }
                    }
                }
                else if(input =="4")
                {
                    Console.WriteLine("Which Blog number do you want to see posts?: ");
                    var blogsIds = Console.ReadLine();
                    if (string.IsNullOrEmpty(blogsIds))
                    {
                        Console.WriteLine("Please Enter a valid Blog ID!");
                        Console.WriteLine("Enter your Blog ID: ");
                        blogsIds = Console.ReadLine();
                    }

                    int blogId;
                    while (!int.TryParse(blogsIds, out blogId))
                    {
                        Console.WriteLine("BlogId must be a number! Enter valid BlogId: ");
                    }
                    using (var context = new BlogContext())
                    {
                        var blog = context.Blogs.FirstOrDefault(x => x.BlogId == blogId);
                        if (blog == null)
                        {
                            Console.WriteLine("Blog does not exist!");

                        }
                        else if (blog.Posts.IsNullOrEmpty())
                        {
                            Console.WriteLine($"There are no posts in {blog.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"Posts for Blog: {blog.Name}");
                            foreach (var post in blog.Posts)
                            {
                                Console.WriteLine($"\tPost: {post.PostId}) {post.Title}: {post.Content}");
                            }
                        }

                    }

                }
                else if(input == "5")
                {
                    Console.WriteLine("Thank you for using my code!");
                    codeTerminator= false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input: 1 , 2 , 3 , 4 , 5");
                }
            }

        }
    }
}