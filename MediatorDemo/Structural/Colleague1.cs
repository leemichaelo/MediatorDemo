using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDemo.Structural
{
    public class Colleague1 : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague1 receives notification message: {message}");
        }
    }
}
