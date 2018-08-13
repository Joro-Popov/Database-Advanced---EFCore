using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.Models;
using System.ComponentModel.DataAnnotations;
using Instagraph.Models.DTOs;
using System.Xml.Serialization;
using System.IO;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var deserializedPictures = JsonConvert.DeserializeObject<List<Picture>>(jsonString);

            var pictures = new List<Picture>();

            var sb = new StringBuilder();

            foreach (var pic in deserializedPictures)
            {
                var PathIsNotUnique = pictures.Any(p => p.Path == pic.Path);
                var PathIsEmpty = pic.Path == string.Empty;
                var SizeisZero = pic.Size == 0;
                var IsValidPicture = IsValid(pic);

                if (PathIsNotUnique || PathIsEmpty || SizeisZero || !IsValidPicture)
                {
                    sb.AppendLine($"Error: Invalid data.");
                    continue;
                }

                pictures.Add(pic);
                sb.AppendLine($"Successfully imported Picture {pic.Path}.");
            }

            context.Pictures.AddRange(pictures);
            context.SaveChanges();
            
            return sb.ToString().Trim();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var deserializedUsers = JsonConvert.DeserializeObject<List<UserDto>>(jsonString);

            var users = new List<User>();

            var sb = new StringBuilder();

            foreach (var usr in deserializedUsers)
            {
                if (usr.Username == null || usr.Password == null || !IsValid(usr))
                {
                    sb.AppendLine($"Error: Invalid data.");
                    continue;
                }
                
                var user = new User
                {
                    Username = usr.Username,
                    Password = usr.Password,
                    ProfilePicture = new Picture
                    {
                        Path = usr.ProfilePicture,
                        Size = context.Pictures.FirstOrDefault(p => p.Path == usr.ProfilePicture).Size
                    }
                };
                
                users.Add(user);
                sb.AppendLine($"Successfully imported user {user.Username}.");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var deserializedUserFollower = JsonConvert.DeserializeObject<List<UserFollowerDto>>(jsonString);

            var userFollowers = new List<UserFollower>();

            var sb = new StringBuilder();

            foreach (var usr in deserializedUserFollower)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == usr.User);
                var follower = context.Users.FirstOrDefault(u => u.Username == usr.Follower);

                if (user == null || follower == null || !IsValid(user) || !IsValid(follower))
                {
                    sb.AppendLine($"Error: Invalid data.");
                    continue;
                }

                var userFollower = new UserFollower
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                };

                var followerExists = user.Followers.Any(u => u.FollowerId == follower.Id);

                if (!followerExists)
                {
                    user.Followers.Add(userFollower);
                    sb.AppendLine($"Successfully imported Follower {usr.Follower} to User {usr.User}.");
                    context.SaveChanges();
                }
            }
            
            return sb.ToString().Trim();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<PostDto>), new XmlRootAttribute("posts"));

            var deserializedPosts = (List<PostDto>)serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var posts = new List<Post>();

            foreach (var post in deserializedPosts)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == post.Username);
                var picture = context.Pictures.FirstOrDefault(p => p.Path == post.PicturePath);
                var isValidPost = IsValid(post);

                if (user == null || picture == null || !isValidPost)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var currentPost = new Post
                {
                    Caption = post.Caption,
                    UserId = user.Id,
                    PictureId = picture.Id
                };

                posts.Add(currentPost);
                sb.AppendLine($"Successfully imported Post {currentPost.Caption}.");
            }

            context.Posts.AddRange(posts);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<CommentDto>), new XmlRootAttribute("comments"));

            var deserializedComments = (List<CommentDto>)serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var comments = new List<Comment>();

            foreach (var comment in deserializedComments)
            {
                if (comment.Username == null || comment.Post == null)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == comment.Username);
                var post = context.Posts.FirstOrDefault(p => p.Id == comment.Post.Id);
                var isValidComment = IsValid(comment);

                if (user == null || post == null || !isValidComment)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var comm = new Comment
                {
                    Content = comment.Content,
                    UserId = user.Id,
                    PostId = post.Id
                };

                comments.Add(comm);
                sb.AppendLine($"Successfully imported Comment {comm.Content}.");
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
