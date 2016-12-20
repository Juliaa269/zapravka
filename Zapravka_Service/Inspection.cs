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

        public Boolean IsАFree;//на теосмотре
        public Stack<Client> parking;
        private Client car;

        public Inspection()
        {
            this.IsАFree = true;
        }
        public void Start(Client c, Stack<Client> s)
        {
            this.IsАFree = false;
            this.car = c;
            this.car.SetIsWorkInspaction(true);
            this.parking = s;
            if (!this.IsАFree) { if (onStart != null) onStart(); }
        }
        public void Finish(Client Cl)
        {
            this.parking.Pop();
            Cl.SetIsWorkInspaction(false); this.IsАFree = true;
            // MessageBox.Show(Cl.GetClientName() + "Событие:Заправился; Покинул очередь");
            Cl = null;
        }
    }
}
