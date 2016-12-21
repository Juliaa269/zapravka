using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Zapravka_Service
{
    public class Client // клиент
    {  public delegate void MethodWork(Client Client);
        //Событие onWaitRefilling c типом делегата MethodWork.
       public event MethodWork onWaitRefilling;
       public event MethodWork onWaitInspection;

        public delegate void MethodFinish(Client Cl);
       //Событие OnFinish c типом делегата MethodContainer.
       public event MethodFinish onFinishColumn;
        public event MethodFinish onFinishInspaction;


        private int prioritet;//приоритет
       private String m_clientName;//номера машины
       private int m_workTime;//Время обслуживания
       public int m_leftTime;//оставшееся время обслуживания
       private int m_timeInQueue;//Время ожидания в очереди
       private int m_timeInStack;//Время ожидания в стеке
       private Boolean isBusy;//признак того,что он на заправляется или на осмотре
       public Client(String clientName)
       {
            this.m_clientName = clientName;
        Random rtime = new Random();
        int randtime = (int)(rtime.Next(5) + 5);//Время постановки в очередь
        this.isBusy = false;
        Random rprio = new Random();
        int randprio = (int)(rprio.Next(100));//приоритет
        this.prioritet = randprio;

        
       
           this.m_workTime = randtime;
           this.m_leftTime = this.m_workTime;
       
        this.m_timeInQueue = 0;
        this.isBusy = false;
   }
       public String GetClientName()
       {
           return m_clientName;
       }
       public void refill(Boolean refillingStatus)
       {
           this.isBusy = refillingStatus;
           if (isBusy && onWaitRefilling != null) {
               onWaitRefilling(this);
            }
       }
       public void SetIsWorkInspaction(Boolean inspectionStarted)
       {
            this.isBusy = inspectionStarted;
            if (onWaitInspection != null) { if (this.isBusy) onWaitInspection(this); }
       }
        public Boolean GetIsWork()
       {
           return this.isBusy;
       }
       public int GetWorkTime()
       {
           return m_workTime;
       }
       public int GetLeftTime()
       {
           return m_leftTime;
       }
       public void SetLeftTime(int y)
       {
           this.m_leftTime = y;
       }
       public int GetTimeInQueue()
       {
           return m_timeInQueue;
       }
        public int GetTimeInStack()
        {
            return m_timeInStack;
        }
        public int GetPriority()
       {
           return this.prioritet;
       }
       public void DecLeftTimeColumn()
       {
           for (int i = 1; i <= this.GetWorkTime(); i++)this.m_leftTime--;//пришлось ускорить
           if (this.m_leftTime <= 0) { if (onFinishColumn != null)  onFinishColumn(this); }
       }
        public void DecLeftTimeInspaction()
        {
            for (int i = 1; i <= this.GetWorkTime(); i++) this.m_leftTime--;//пришлось ускорить
            if (this.m_leftTime <= 0) { if (onFinishInspaction != null) onFinishInspaction(this); }
        }
        public void UpdateTimeInQueue(Client Client)//время ожидания в очереди
       { 
           m_timeInQueue++;
       }
       public void UpdateTimeInStack(Client Client)//время ожидания в стеке
        {
            m_timeInStack++;
        }
    }
} 
