using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using StackOverflowProject.DomainModels;


namespace StackOverflowProject.Repositories
{
    interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);

    }
    public class VotesRepository : IVotesRepository
    {
        StackOverflowDatabaseDBContext db;
        public VotesRepository()
        {
            db = new StackOverflowDatabaseDBContext();
        }
        public void UpdateVote(int aid, int uid, int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if (value < 0) updateValue = -1;   
            else updateValue = 0;
            Vote vote = db.Votes.Where(temp => temp.AnswerID == aid && temp.UserID == uid).FirstOrDefault();
            if(vote != null)
            {
                vote.VoteValue = updateValue;
            }
            else
            {
                Vote newVote = new Vote() { AnswerID = aid, UserID = uid, VoteValue = updateValue};
                db.Votes.Add(newVote);
            }
            db.SaveChanges();
        }
    }
}
