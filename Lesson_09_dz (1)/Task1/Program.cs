using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;




//Разработать приложение «Тамагочи». Жизненный
//цикл персонажа — 1-2 минуты. Персонаж случайным
//образом выдаёт просьбы (но подряд одна и та же просьба
//не выдаётся). Просьбы могут быть следующие: Покормить, Погулять, Уложить спать, Полечить, Поиграть.
//Если просьбы не удовлетворяются трижды, персонаж
//«заболевает» и просит его полечить. В случае отказа —
//«умирает». Персонаж отображается в консольном окне
//при помощи псевдографики.
//Диалог с персонажем осуществляется посредством
//вызова метода Show() класса MessageBox из пространства
//имен System.Windows.Forms. За получением подробной
//информации по работе с этим методом обратитесь к Вашему преподавателю или в MSDN.
//Для решения этой задачи Вам понадобится класс Timer
//из пространства имен System.Timers, событие которого
//Elapsed, типа делегата ElapsedEventHandler, происходит через определенный интервал времени, который
//задан в свойстве Interval. Методы Start() и Stop()
//запускают и останавливают таймер, соответственно.
//Вы также можете захотеть делать паузы в работе приложения, в этом случае можно вызвать метод Sleep()
//класса Thread из пространства имен System.Threading,
//передав в него необходимое количество миллисекунд.
namespace Task1
{
    //я нигде не смог найти где и как с нуля описано про этот System.Windows.Forms,
    //сам пытался разобраться но ничего не получилось
    //сделал в консоли
    public class Program
    {
        public static short Life = 0;

        public static DateTime datec1 = new DateTime();
        public static DateTime datecFin = new DateTime();

        [DllImport("msvcrt.dll")]
       public  static extern int system(string command);

      
        public static void Main(string[] args)
        {
            Random rand = new Random((int)(DateTime.Now.Ticks));
            Tamagochi t =new Tamagochi();

            

            datec1=DateTime.Now;
            datecFin=DateTime.Now.AddMinutes(2);

            Console.WriteLine("Hi, my name is Tam");
            ///t.Img();
            for (; datec1<=datecFin; datec1=datec1.AddSeconds(1))
            {
                
                //Надо 
                //отвечать
                //Yes or No

             

                if (rand.Next(0,4)==0)
                {
                    t.Eat();
                    Thread.Sleep(1000);
                }
                else if (rand.Next(0, 4)==1)
                {
                    t.Walk();
                    Thread.Sleep(1000);

                }
                else if (rand.Next(0, 4)==2)
                {
                    t._Sleap();
                    Thread.Sleep(1000);

                }
                else if(rand.Next(0, 4)==3)
                {
                    t.Play();
                    Thread.Sleep(1000);
                }


                if (Life==3)
                {   
                    Console.WriteLine("U died");         
                }
                else if (Life==2)
                {
                    Console.WriteLine("I need AID!!");
                    t.Aid();
                }     
            }
            
        }
    }
    public class Tamagochi :  Program
    {
        public  dynamic Eat()
        {
            Console.WriteLine("I wanna eat\nWill u give me smth to eat?");
            string eat = Console.ReadLine();
            if (eat=="No")
            {
                return Life++;
            }
            else if (eat=="Yes")
            {
                if (Life==0)
                    return 0;
                return Life--;
            }
            else
            {
                throw new Exception("Error value");
            }
        }
        public  dynamic Walk()
        {
            Console.WriteLine("I wanna walk\nWill u walk with me?");
            string eat = Console.ReadLine();
            if (eat=="No")
            {
                return Life++;
            }
            else if (eat=="Yes")
            {
                if (Life==0)
                    return 0;
                return Life--;
            }
            else
            {
                throw new Exception("Error value");
            }
        }
        public  dynamic _Sleap()
        {
            Console.WriteLine("I wanna sleap\nWill u walk give me time for sleap?");
            string eat = Console.ReadLine();
            if (eat=="No")
            {
                return Life++;
            }
            else if (eat=="Yes")
            {if (Life == 0)
                    return 0;
                return Life--;
            }
            else
            {
                throw new Exception("Error value");
            }
        }
        public  dynamic Aid()
        {
            Console.WriteLine("I need go to the hospital\nCan i do it?");
            string eat = Console.ReadLine();
            if (eat=="No")
            {
                throw new Exception("U died");
            }
            else if (eat=="Yes")
            {if (Life == 0)
                    return 0;
                return Life--;
            }
            else
            {
                throw new Exception("Error value");
            }
        }
        public  dynamic Play()
        {
            Console.WriteLine("I wanna play\nWill u play with me time?");
            string eat = Console.ReadLine();
            if (eat=="No")
            {
                return Life++;
            }
            else if (eat=="Yes")
            {if (Life == 0)
                    return 0;
                return Life--;
            }
            else
            {
                throw new Exception("Error value");
            }
        }
        //public dynamic Img()
        //{
        //    //string s = Environment.CurrentDirectory;
        //    //s+="\\default.jpg";
        //    //Bitmap _bitmap = new Bitmap(s);    
        //    //return _bitmap;
        //    string s = "cd "+Environment.CurrentDirectory;
        //    s+="\\default.jpg";
        //    Console.Write(s+"\n");
        //    system(s);
        //    return s;
        //}

    }
}
