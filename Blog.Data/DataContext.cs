using Blog.Core.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Blog.Data
{
    public class DataContext
    {
        private readonly DataPathes _path;

        public List<Category> CategoryData { get; set; }
        public List<Comment> CommentData { get; set; }
        public List<Post> PostData { get; set; }
        public List<Tag> TagData { get; set; }
        public List<User> UserData { get; set; }

        public DataContext(DataPathes path)
        {
            _path = path;
            if (!File.Exists(_path.CategoryPath))
                File.Create(_path.CategoryPath).Close();
            if (!File.Exists(_path.CommentPath))
                File.Create(_path.CommentPath).Close();
            if (!File.Exists(_path.PostPath))
                File.Create(_path.PostPath).Close();
            if (!File.Exists(_path.TagPath))
                File.Create(_path.TagPath).Close();
            if (!File.Exists(_path.UserPath))
                File.Create(_path.UserPath).Close();
            LoadCategoryData();
            LoadCommentData();
            LoadPostData();
            LoadTagData();
            LoadUserData();
        }

        public bool LoadCategoryData()
        {
            try
            {
                if (new FileInfo(_path.CategoryPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.CategoryPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        CategoryData = csv.GetRecords<Category>().ToList();
                    }
                }
                else
                {
                    CategoryData = new List<Category>();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveCategoryData()
        {
            try
            {
                if (File.Exists(_path.CategoryPath))
                    File.Delete(_path.CategoryPath);
                using (var writer = new StreamWriter(_path.CategoryPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(CategoryData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadCommentData()
        {
            try
            {
                if (new FileInfo(_path.CommentPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.CommentPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        CommentData = csv.GetRecords<Comment>().ToList();
                    }
                }
                else
                {
                    CommentData = new List<Comment>();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveCommentData()
        {
            try
            {
                if (File.Exists(_path.CommentPath))
                    File.Delete(_path.CommentPath);
                using (var writer = new StreamWriter(_path.CommentPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(CommentData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadPostData()
        {
            try
            {
                if (new FileInfo(_path.PostPath).Length > 0)
                {

                    using (var reader = new StreamReader(_path.PostPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        PostData = csv.GetRecords<Post>().ToList();
                    }
                }
                else
                {
                    PostData = new List<Post>();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SavePostData()
        {
            try
            {
                if (File.Exists(_path.PostPath))
                    File.Delete(_path.PostPath);
                using (var writer = new StreamWriter(_path.PostPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(PostData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadTagData()
        {
            try
            {
                if (new FileInfo(_path.TagPath).Length > 0)
                {

                    using (var reader = new StreamReader(_path.TagPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        TagData = csv.GetRecords<Tag>().ToList();
                    }
                }
                else
                {
                    TagData = new List<Tag>();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SaveTagData()
        {
            try
            {
                if (File.Exists(_path.TagPath))
                    File.Delete(_path.TagPath);
                using (var writer = new StreamWriter(_path.TagPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(TagData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadUserData()
        {
            try
            {
                if (new FileInfo(_path.UserPath).Length > 0)
                {

                    using (var reader = new StreamReader(_path.UserPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        UserData = csv.GetRecords<User>().ToList();
                    }
                }
                else
                {
                    UserData = new List<User>();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveUserData()
        {
            try
            {
                if (File.Exists(_path.UserPath))
                    File.Delete(_path.UserPath);
                using (var writer = new StreamWriter(_path.UserPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(UserData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public class DataPathes
        {
            private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Blog.Data", "Data");
            public string CategoryPath { get; set; }
            public string CommentPath { get; set; }
            public string PostPath { get; set; }
            public string TagPath { get; set; }
            public string UserPath { get; set; }
            public DataPathes()
            {
                CategoryPath = Path.Combine(_basePath, "category_data.csv");
                CommentPath = Path.Combine(_basePath, "comment_data.csv");
                PostPath = Path.Combine(_basePath, "post_data.csv");
                TagPath = Path.Combine(_basePath, "tag_data.csv");
                UserPath = Path.Combine(_basePath, "user_data.csv");
            }
        }
    }
}
