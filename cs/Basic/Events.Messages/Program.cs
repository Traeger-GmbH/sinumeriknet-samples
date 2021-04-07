// Copyright (c) Traeger Industry Components GmbH. All Rights Reserved.

namespace Events.Messages
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
            // Setup a custom OEM message provider for system and non-system events.
            NcuEvent.MessageProvider = new OemEventMessageProvider();

            // To reset the used message provider to NcuEventMessageProvider.Default:
            ////NcuEvent.MessageProvider = null;

            // In case you want to provide system and non-system messages using a resource file:
            ////NcuEvent.MessageProvider = NcuEventMessageProvider.Load(@".\Messages.de-DE.txt");
            // or using the OEM message provider:
            ////var fallback = NcuEventMessageProvider.Load(@".\Messages.de-DE.txt");
            ////NcuEvent.MessageProvider = new OemEventMessageProvider(fallback);

            // To prepare a "template" resource file you can use:
            ////NcuEventMessageProvider.Default.Save(@".\Messages.en-US.txt");

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
                    e.Event.Message ?? "[no message available]",
                    e.Event.Timestamp?.ToString() ?? "----");
        }
    }
}
