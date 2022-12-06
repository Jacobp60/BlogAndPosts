using BlogAndPosts.Models;

namespace BlogAndPosts
{
    internal class Program
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
                }
                else if(input =="4")
                {

                }
                else if(input == "5")
                {
                    Console.WriteLine("Thank you!");
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