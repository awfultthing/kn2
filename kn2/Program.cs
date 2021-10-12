using System;
namespace kn2
{
    class ClassCounter  //Класс со счётом
    {
        public delegate void MethodContainer();

        //Событие OnCount c типом делегата MethodContainer.
        public event MethodContainer onCount;

        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 65)
                {
                    onCount();
                }
            }
        }
    }
    class Handler_I //Это класс, реагирующий на событие (счет равен 65) записью строки в консоли.
    {
        public void Message()
        {
            Console.WriteLine("Пора действовать, ведь уже 65!");
        }
    }
    class Handler_II
    {
        public void Message()
        {
            Console.WriteLine("Точно, уже 65!");
        }
    }
    //когда счетчик будет считать до 100 и достигнет 65, должны сработать методы Message() для классов Handler_I и Handler_II
    class Program
    {
        static void Main(string[] args)
        {
            ClassCounter Counter = new ClassCounter();
            Handler_I Handler1 = new Handler_I();
            Handler_II Handler2 = new Handler_II();
            //Подписались на событие
            Counter.onCount += Handler1.Message;
            Counter.onCount += Handler2.Message;
            //Запустили счетчик
            Counter.Count();

        }
    }
}