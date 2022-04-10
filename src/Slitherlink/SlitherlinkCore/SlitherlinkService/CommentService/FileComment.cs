using Slitherlink.SlitherlinkCore.SlitherlinkEntity;

using System.Runtime.Serialization.Formatters.Binary;

namespace Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService
{
    [Serializable]
    public class FileComment : CommentService
    {
        private string file_name = "Comment.bin";
        private IList<Comment> comment = new List<Comment>();
        public void AddComment(Comment comments)
        {
            comment.Add(comments);
            Save();
        }
        public IList<Comment> GetComment()
        {
            Load();
            return (from s in comment orderby s.Author descending select s).Take(5).ToList();
        }
        public void DeleteComment()
        {
            comment.Clear();
            File.Delete(file_name);
        }
        private void Save()
        {
            using (var fs = File.OpenWrite(file_name))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, comment);
            }
        }

        private void Load()
        {
            if (File.Exists(file_name))
            {
                using (var fs = File.OpenRead(file_name))
                {
                    var bf = new BinaryFormatter();
                    comment = (List<Comment>)bf.Deserialize(fs);
                }
            }
        }
    }
}
