using CandidateTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCandidateTracker.Data
{
   public class CandidateTrackerRepository
    {
        private string _connectionString;
        public CandidateTrackerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int GetRefusedCount()
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.Where(c => c.RegistrationStatus == RegistrationStatus.refused).Count();
        }

        public int GetConfirmedCount()
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.Where(c => c.RegistrationStatus == RegistrationStatus.confirmed).Count();
        }
        public int GetPendingdCount()
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.Where(c => c.RegistrationStatus == RegistrationStatus.pending).Count();
        }

        public void AddCandidate(Candidate candidate)
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            candidate.RegistrationStatus = RegistrationStatus.pending;
            context.Add(candidate);
            context.SaveChanges();
        }

        public List<Candidate> GetConfirmedCandidates(Candidate candidate)
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.Where(c => c.RegistrationStatus == RegistrationStatus.confirmed).ToList();
        }

        public List<Candidate>  GetRefusedCandidates(Candidate candidate)
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.Where(c => c.RegistrationStatus == RegistrationStatus.refused).ToList();
        }

        public List<Candidate> GetRefusedCandidates()
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetPendingCandidates(Candidate candidate)
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.Where(c => c.RegistrationStatus == RegistrationStatus.pending).ToList();
        }

        public List<Candidate> GetPendingCandidates()
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidate(int id)
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            return context.Candidates.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCandidates(Candidate candidate)
        {
            using var context = new CandidateTrackerDataContext(_connectionString);
            context.Candidates.Update(candidate);
            context.SaveChanges();
        }
    }
}
