using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapravka_Service
{
    class Inspection  // тех.осмотр
    {
        public delegate void MethodStart();
        //Событие OnFinish c типом делегата MethodContainer.
        public event MethodStart onStart;

        public Boolean status;//на теосмотре
        public Stack<Client> parking;
        private Client car;

        private const bool BUSY = false;
        private const bool FREE  = true;

        public Inspection()
        {
            this.status = FREE;
        }
        public void Start(Client c, Stack<Client> s)
        { 
            this.status = BUSY;
            this.car = c;
            this.car.SetIsWorkInspaction(true);
            this.parking = s;

            if (onStart != null)
                onStart(); 
        }
        public void Finish(Client client)
        {
            this.parking.Pop();
            client.SetIsWorkInspaction(false);
            this.status = FREE;
            // MessageBox.Show(Cl.GetClientName() + "Событие:Заправился; Покинул очередь");
            client = null;
        }
    }
}
