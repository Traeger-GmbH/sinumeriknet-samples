// Copyright (c) Traeger Industry Components GmbH. All Rights Reserved.

namespace Data
{
    using System;
    using Sinumerik.Advanced;

    public class Program
    {
        /// <summary>
        /// This sample demonstrates how to implement an app which reads a single value.
        /// </summary>
        public static void Main()
        {
            // The following setup connects to a Sinumerik SolutionLine (Sl)
            // Just replace "sl" with "pl" to connect to a Sinumerik PowerLine instead.
            using (var client = new SinumerikClient("s840d.sl://192.168.0.131")) {
                client.Connect();

                var position = client.ReadValue("/Channel/MachineAxis/measPos1[u1, 1]");
                Console.WriteLine($"Current Position of Axis 1 is {position} mm");
            }
        }
    }
}
