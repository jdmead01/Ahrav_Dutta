using System;
using System.Collections.Generic;
namespace wedding_planner.Models
{
    public class User
    {
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<Wedding> CreatedWeddings {get; set;}
        public List<Invite> Invitations {get; set;}

    }
    public class Wedding
    {
        public int WeddingId {get; set;}
        public string Groom {get; set;}
        public string Bride {get; set;}
        public DateTime Date {get; set;}
        public string Address {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int UserId {get; set;}
        public List<Invite> Guests {get; set;}
    }
    public class Invite 
    {
        public int InviteId {get; set;}
        public int WeddingId {get; set;}
        public Wedding Wedding {get; set;}
        public int UserId {get; set;}
        public User InvitedUser {get; set;}
    }
}