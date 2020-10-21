using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDemo.Structural
{
    public class Colleague2 : Colleague
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague2 receives notification message: {message}");
        }
    }
}
