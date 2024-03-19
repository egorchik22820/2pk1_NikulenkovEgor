using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleProject
{
    internal class Pasagir : IPasagir
    {
        ParkingTicket ticket;
        string Name { get; set; }
        int Age { get; set; }
        public Pasagir(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public void BuyTicket(ParkingTicket ticket)
        {
            this.ticket = ticket;
        }

        public void GetInfo()
        {
            Console.WriteLine($"name : {Name}");
            Console.WriteLine($"age : {Age}");
            Console.WriteLine($"ticket : {ticket.ID}");
        }





    }
}
