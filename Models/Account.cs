﻿namespace Models
{
    public class Account : IEntity<int>
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
