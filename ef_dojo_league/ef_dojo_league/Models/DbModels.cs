using System;
using System.Collections.Generic;
namespace ef_dojo_league.Models
{
    public class Ninja 
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int Level {get; set;}
        public string Description {get; set;}
        public int DojoId {get; set;}
        public Dojo Dojo {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
    public class Dojo
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Location {get; set;}
        public string Information {get; set;}
        public List<Ninja> Ninjas {get; set;}
        public Dojo()
        {
            Ninjas = new List<Ninja>();
        }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}