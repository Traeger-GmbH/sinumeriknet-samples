namespace App
{
    using System;
    using System.Threading;

    using Sinumerik.Advanced;

    public class Program
    {
        public static void Main()
        {
            var device = new SinumerikDevice("192.168.0.80");

            using (var connection = device.CreateConnection()) {
                connection.Open();

                while (true) {                    
                    var position = connection.ReadDouble("/Channel/MachineAxis/measPos1[u1, 1]");
                    Console.WriteLine($"Current Position of Axis 1 is {position} mm");

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
