using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Instagraph.Data;
using Instagraph.Models.DTOs;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new ExportPostDto
                {
                    Id = p.Id,
                    User = p.User.Username,
                    Picture = p.Picture.Path
                })
                .OrderBy(p => p.Id)
                .ToList();

            var jsonString = JsonConvert.SerializeObject(posts, Formatting.Indented);

            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts.Any(p => p.Comments.Any(c => u.Followers.Any(f => f.FollowerId == c.UserId))))
                .OrderBy(u => u.Id)
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Followers = u.Followers.Count
                })
                .ToList();

            var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonString;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var serializer = new XmlSerializer(typeof(List<ExportUserPostsDto>), new XmlRootAttribute("users"));
            var namespaces = new XmlSerializerNamespaces(new[] { new System.Xml.XmlQualifiedName("", "") });

            var users = context.Users
                .Select(u => new ExportUserPostsDto
                {
                    Username = u.Username,
                    MostComments = u.Posts.Count == 0 ? 0 : u.Posts.Max(p => p.Comments.Count)
                    
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToList();

            var result = new StringBuilder();

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, users, namespaces);
            }

            return result.ToString().Trim();
        }
    }
}
