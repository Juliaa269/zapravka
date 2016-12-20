using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Zapravka_Service
{
    class Refilling // заполнение
    {
        public delegate void MethodStart();
        //Событие OnFinish c типом делегата MethodContainer.
        public event MethodStart onStart;

        public Boolean IsАFree;//на заправке
        public Queue<Client> Q;
        private Client car;
        
        public Refilling()
        {
            this.IsАFree = true;
        }
        public void Start(Client c, Queue<Client> v)
        {
            this.IsАFree = false;
            this.car = c;
            this.car.SetIsWorkColumn(true);
            this.Q = v;
            if (!this.IsАFree) { if (onStart != null)  onStart(); }
        }
        public void Finish(Client Cl)
        {
            this.Q.Dequeue();
            Cl.SetIsWorkColumn(false); this.IsАFree = true;
           // MessageBox.Show(Cl.GetClientName() + "Событие:Заправился; Покинул очередь");
            Cl = null;
        }
       
    }
}