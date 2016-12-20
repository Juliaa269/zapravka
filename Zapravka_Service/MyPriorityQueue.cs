using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Zapravka_Service
{
    public class MyPriorityQueue
    {     
        public List<Client> arr;
        public int Heap_Size;
        public MyPriorityQueue()
      {
 	    this.arr = new List<Client>();
        this.Heap_Size=arr.Count();
 	  }
      // Рекурсивная поцедура просеивания элемента по древу (пирамиде)
      // Основная компонента построения пирамиды для массива
      // и построения отсортированного массива по пирамиде
      public void Seed(int i)
      {
          //просеивание элемента с индексом i,
          //нарушающего свойство пирамидальности массива
          int l = 2 * i + 1, r = l + 1;   //индексы левого и правого потомка
          Client temp;
          if (l > Heap_Size - 1) return;  //это лист пирамиды
          int cand = i;
          if (this.arr[i].GetPriority() < arr[l].GetPriority()) cand = l;
          if ((r < Heap_Size) && (arr[cand].GetPriority() < arr[r].GetPriority())) cand = r;
          if (cand != i) //обмен
          {
              temp = arr[i]; arr[i] = arr[cand]; arr[cand] = temp;
              Seed(cand);     //Просеивание вниз
          }
      }
      // Преобразует массив arr  в пирамиду
      // Массив является пирамидой, если для каждого элемента массива,
      // не являющегося листом пирамиды, его значение меньше или равно
      // значения двух его потомков
      private void MakePyramid()
      {
          int m = (Heap_Size - 2) / 2;
          //m- индекс последнего элемента, имеющего потомков
          //элементы с индексами, большими m, являются листьями пирамиды
          for (int k = m; k >= 0; k--)
              Seed(k);
      }
      // Пирамидальная сортировка
      // Вначале по массиву строится пирамида 
      // затем по пирамиде строится отсортированный массив
      public void PyramidSort()
      {          
          Heap_Size = arr.Count();
          Client temp;
          MakePyramid();
          for (int i = 0; i < Heap_Size - 1; i++)
          {
              temp = arr[0]; arr[0] = arr[Heap_Size - 1];
              arr[Heap_Size - 1] = temp; Heap_Size--;
              Seed(0);
          }
          
      }
     
    }
}
