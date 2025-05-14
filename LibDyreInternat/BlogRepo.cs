using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{
    public static class BlogRepo
    {
        public static List<Blog> AllBlogs { get; private set; } = new List<Blog>()
        {
            new Blog("Bob did go for an walk", 565656, 01-01-01, Activity, "The trip to the woods was enjoyable, Bob marked every tree along the way."),
            new Blog("Blub the fish did go for an swim", 465465, 01-01-01, Activity, "Blub the fish a brave little fish went for a swim and proudly discovered the same rock at least ten times.")
        };

        public static void AddBlog(Blog blog) { AllBlogs.Add(blog); }

        public static bool Delete(int id)
        {
            foreach (Blog b in AllBlogs)
            {
                if (b.Id.Equals(id))
                {
                    return AllBlogs.Remove(b);
                }
            }
            return false;
        }
    }
}
