using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zapravka_Service
{
    /*
     Событие — это именованный делегат, при вызове которого, будут запущены
     все подписавшиеся на момент вызова события методы заданной сигнатуры.      *
     */
    public partial class Form1 : Form
    {
        public Queue<Client>[] m_Queue = new Queue<Client>[2];//Очередь 1
        public MyPriorityQueue SourceCars = new MyPriorityQueue();
        public Stack<Client> parking = new Stack<Client>();
        public Stack<Client> inspection = new Stack<Client>();
        public Form1()
        {
            InitializeComponent();
            int j = 0;
            foreach (Queue<Client> i in m_Queue)
            {
                m_Queue[j] = new Queue<Client>();
                j++;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Client Client;
            for (int i = 0; i < 10; i++)//Запустили партию машин в очередь с приоритетом
            {
                Client = new Client();
                SourceCars.arr.Add(Client);
            }
            SourceCars.MakePyramid();
            SourceCars.PyramidSort();

      
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //Подписались на событие окончания заправки машины
            //Подписываемся на событие MyEvent  
            // myClass.MyEvent += new MyDel(Handler);  
            Client client = new Client();
            client.onWaitRefilling += new Client.MethodWork(client.UpdateTimeInQueue);
            client.onWaitRefilling += new Client.MethodWork(this.UpdateTimeInQueue);
            client.onWaitInspection += new Client.MethodWork(client.UpdateTimeInStack);
            client.onWaitInspection += new Client.MethodWork(this.UpdateTimeInStack);

            Refilling refilling = new Refilling();
            Inspection inspect = new Inspection();
            //Подписались на событие - машина с наивысшим приоритетом идет в очередь к свободному автомату
            client.onFinishColumn += new Client.MethodFinish(refilling.Finish);
            client.onFinishColumn += new Client.MethodFinish(this.FinishСolumn);

            client.onFinishInspaction += new Client.MethodFinish(inspect.Finish);
            client.onFinishInspaction += new Client.MethodFinish(this.FinishInspect);

            refilling.onStart += new Refilling.MethodStart(this.DecLeftTimeColumn);
            refilling.onStart += new Refilling.MethodStart(client.DecLeftTimeColumn);

            inspect.onStart += new Inspection.MethodStart(this.DecLeftTimeInspection);
            inspect.onStart += new Inspection.MethodStart(client.DecLeftTimeInspaction);

            SourceCars.arr.Add(client);
            SourceCars.MakePyramid();
            SourceCars.PyramidSort();
            this.rbStat.Text += "Пришла машина. " + client.GetClientName() + " встала по приоритету.\r \n ";

            Random rQ = new Random();
            int rrQ = (int)(rQ.Next(3));//постановка в очередь

            if (SourceCars.arr.Count > 0)
            {
                switch (rrQ)
                {
                    case 0: Zapravka(m_Queue[0], SourceCars.arr[0], refilling, this.rbColumn1, 1); break;
                    case 1: Zapravka(m_Queue[1], SourceCars.arr[0], refilling, this.rbColumn2, 2); break;
                    case 2: Parking(parking,SourceCars.arr[0], this.rbParking ); break;
                }
                if (parking.Count>9) Inspection(inspection, parking.Peek(), inspect, this.rbInspection);
            }
            else
            {
                rbStat.Text += "Больше нет желающих заправиться";
                this.timer1.Stop();
            }
        }
        private void Zapravka(Queue<Client> Q, Client Cl, Refilling refill, RichTextBox z, int Nq)
        {
            if (!Cl.GetIsWork())
            {
                Q.Enqueue(Cl); SourceCars.arr.Remove(Cl);
                z.Text += "> Автомобиль<" + Cl.GetClientName() + "> присоединился к очереди на заправку..." + '\r' + '\n';
                rbStat.Text += "      " + Cl.GetClientName() + "  приоритет " + Cl.GetPriority().ToString() + "/100\r\n      "
                + Cl.GetClientName() + " время обслуживания" + Cl.GetWorkTime().ToString() + " сек.\r\n";
                Cl.SetIsWorkColumn(true);
                if (refill.IsАFree)
                {
                    refill.Start(Cl, Q);
                    rbStat.Text += "\n в очереди " + Nq + " обслуживается: " + Cl.GetClientName()+"\n";

                }
                else rbStat.Text += "Автомат занят.";
            }
            else
            {
                if (!refill.IsАFree)
                    rbStat.Text += "Процесс заправки идет.";
            }
        }
        private void Parking(Stack<Client> parking, Client Cl, RichTextBox z)
        {
            parking.Push(Cl); SourceCars.arr.Remove(Cl);
            z.Text += "> Автомобиль<" + Cl.GetClientName() + "> стал на стоянку..." + '\r' + '\n';
        }
        private void Inspection(Stack<Client> insp, Client Cl, Inspection inspect , RichTextBox z)
        {
            if (!Cl.GetIsWork())
            {
                insp.Push(Cl); SourceCars.arr.Remove(Cl);
                z.Text += "> Автомобиль<" + Cl.GetClientName() + "> стал на техосмотр..." + '\r' + '\n';
                rbStat.Text += "      " + Cl.GetClientName() + "  приоритет " + Cl.GetPriority().ToString() + "/100\r\n      "
                + Cl.GetClientName() + " время обслуживания" + Cl.GetWorkTime().ToString() + " сек.\r\n";
                Cl.SetIsWorkInspaction(true);
                if (inspect.IsАFree)
                {
                    inspect.Start(Cl, parking);
                    rbStat.Text += "\n на техосмотре " + " обслуживается: " + Cl.GetClientName();

                }
                else rbStat.Text += "Техосмотр занят.";
            }
            else
            {
                if (!inspect.IsАFree)
                    rbStat.Text += "Процесс осмотра идет.";
            }
        }
        public void FinishСolumn(Client Cl)
        {
            rbStat.Text += "\n "
                + Cl.GetClientName()
                + " (приоритет: " + Cl.GetPriority().ToString()
                + "; время ожидания в очереди: " + Cl.GetTimeInQueue().ToString()
                + "; время обслуживания: " + Cl.GetWorkTime().ToString()
                + ")  клиент покинул заправку\n";
        }
        public void FinishInspect(Client client)
        {
            rbStat.Text += "  \n "
                + client.GetClientName()
                + " (приоритет: " + client.GetPriority().ToString()
                + "; время ожидания в стеке: " + client.GetTimeInStack().ToString()
                + "; время обслуживания: " + client.GetWorkTime().ToString()
                + ")  клиент покинул техосмотр\n";
            Random rnd = new Random();
            int situation = (int)rnd.Next(2);
            m_Queue[0].Enqueue(client);
           
        }
        public void DecLeftTimeColumn()
        {
            rbStat.Text += "  \n - автомат стартовал\n";
        }
        public void DecLeftTimeInspection()
        {
            rbStat.Text += "  \n - техосмотр стартовал\n";
        }
        public void UpdateTimeInQueue(Client client)
        {
            rbStat.Text += "  \n "
                + client.GetClientName()
                + "- ожидает обслуживания автомата заправки\n";
        }
        public void UpdateTimeInStack(Client client)
        {
            rbStat.Text += "  \n "
                + client.GetClientName()
                + "- ожидает обслуживания техосмотра\n";
        }
        private void ShowQueue(Queue<Client> Q, Client Client)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void rbInspection_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbColumn2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
