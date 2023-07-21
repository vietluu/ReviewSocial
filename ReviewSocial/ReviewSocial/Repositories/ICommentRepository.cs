using ReviewSocial.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;



namespace ReviewSocial.Repositories
{
    public interface ICommentRepository
    {
        
        public IEnumerable<Comment> GetByPost(int id);
            Comment GetById(int id);
        int CountByPost(int id);

        Comment Create(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);

    }
}
