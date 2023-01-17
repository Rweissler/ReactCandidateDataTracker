using CandidateTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactCandidateTracker.Data;
using System.Collections.Generic;

namespace ReactCandidateTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Constr");
        }

        [Route("getrefusedcount")]
        [HttpGet]
        public int GetRefusedCount()
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetRefusedCount();
        }

        [Route("getpendingcount")]
        [HttpGet]
        public int GetPendingCount()
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetPendingdCount();
        }

        [Route("getconfirmedcount")]
        [HttpGet]
        public int GetConfirmedCount()
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetConfirmedCount();
        }

        [Route("addcandidate")]
        [HttpPost]
        public void AddCandidate(Candidate candidate)
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            repo.AddCandidate(candidate);
        }

        [Route("getconfirmedcandidates")]
        [HttpGet]
        public List<Candidate> GetConfirmedCandidates()
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetRefusedCandidates();
        }

        [Route("getrefusedcandidates")]
        [HttpGet]
        public List<Candidate> GetRefusedCandidates()
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetRefusedCandidates();
        }
        [Route("getpendingcandidates")]
        [HttpGet]
        public List<Candidate> GetPendingCandidates()
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetPendingCandidates();
        }

        [Route("getcandidate")]
        [HttpGet]
        public Candidate GetCandidate(int id)
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            return repo.GetCandidate(id);
        }

        [Route("refusedcandidate")]
        [HttpPost]

        public void RefusedCandidate(Candidate candidate)
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            candidate.RegistrationStatus = RegistrationStatus.refused;
            repo.UpdateCandidates(candidate);
        }

        [Route("confirmedcandidate")]
        [HttpPost]
        public void ConfirmedCandidate(Candidate candidate)
        {
            var repo = new CandidateTrackerRepository(_connectionString);
            candidate.RegistrationStatus = RegistrationStatus.confirmed;
            repo.UpdateCandidates(candidate);
        }
    }
}
