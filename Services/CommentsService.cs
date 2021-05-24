using System;
using blogger_cs.Models;
using blogger_cs.Repositories;

namespace blogger_cs.Services
{
    public class CommentsService
    {

        private readonly CommentsRepository _repo;

        public CommentsService(CommentsRepository repo)
        {
            _repo = repo;
        }

        internal Comment CreateComment(Comment newComment)
        {
            Comment comment = _repo.CreateComment(newComment);
            return comment;
        }
    }
}