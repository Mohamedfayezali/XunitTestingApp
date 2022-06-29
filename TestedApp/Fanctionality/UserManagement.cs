﻿namespace TestedApp.Fanctionality
{
    public record User(string firstName, string lastName)
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Phone { get; set; }
        public bool VerifiedEmail { get; set; } = false;

    }

    public class UserManagement
    {
        private readonly List<User> _users = new();
        private int idCounter = 1;
        public IEnumerable<User> AllUsers => _users;
        public void Add(User user)
        {
            _users.Add(user with { Id = idCounter++ });
        }

        public void UpdatePhone(User user)
        {
            var dbUser = _users.FirstOrDefault(x => x.Id == user.Id);
            dbUser.Phone = user.Phone;
        }
        public void VerifyEmail(int userId)
        {
            var dbUser = _users.FirstOrDefault(x => x.Id == userId);
            dbUser.VerifiedEmail = true;
        }

    }
}
