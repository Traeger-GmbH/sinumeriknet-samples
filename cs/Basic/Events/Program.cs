// Copyright (c) Traeger Industry Components GmbH. All Rights Reserved.

namespace Events
{
    using System;
    using Sinumerik.Advanced;

    public class Program
    {
        /// <summary>
        /// This sample demonstrates how to implement an app which subscribes the events of the NCU (= PLC + NCK).
        /// </summary>
        public static void Main()
        {
            // The following setup connects to a Sinumerik SolutionLine (Sl)
            // Just replace "sl" with "pl" to connect to a Sinumerik PowerLine instead.
            using (var client = new SinumerikClient("s840d.sl://192.168.0.80")) {
                client.Connect();
                client.SubscribeEvents(HandleEvents);

                Console.WriteLine("Subscribed!");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Handles the <see cref="NcuEventSubscription.EventReceived"/> event using NCU events.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private static void HandleEvents(object sender, NcuEventReceivedEventArgs e)
        {
            Console.WriteLine(
                    "{0}: ({1}) {2} ({3})",
                    e.Event.Area,
                    e.Event.EventId,
                    e.Event.Message,
                    e.Event.Timestamp?.ToString() ?? "----");
        }
    }
}
