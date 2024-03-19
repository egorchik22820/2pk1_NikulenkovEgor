using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleProject
{
    internal class ParkingTicket : ICloneable, IComparable<ParkingTicket>
    {
        public int ID;
        public int summ;
        public string startTime;
        public string endTime;
        public int carID;

        public void GetTicketInfo()
        {
            Console.WriteLine("ID :\t" + ID);
            Console.WriteLine("summ :\t" + summ);
            Console.WriteLine("startTime :\t" + startTime);
            Console.WriteLine("endTime :\t" + endTime);
            Console.WriteLine("carID :\t" + carID);
            Console.WriteLine();
        }

        public ParkingTicket(int ID, int summ, string startTime, string endTime, int carID)
        {
            this.ID = ID;
            this.summ = summ;
            this.startTime = startTime;
            this.endTime = endTime;
            this.carID = carID;
        }

        public object Clone()
        {
            return new ParkingTicket(this.ID, this.summ, this.startTime, this.endTime, this.carID);
        }

        public int CompareTo(ParkingTicket ticket)
        {
            return this.summ.CompareTo(ticket.summ);
        }


    }
}
