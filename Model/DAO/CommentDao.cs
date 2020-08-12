using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CommentDao
    {
        private BookStoreDbContext db;
        public CommentDao()
        {
            this.db = new BookStoreDbContext();
        }

        public void addComment(comment comment)
        {
            db.comments.Add(comment);
            db.SaveChanges();
        }
    }
}
