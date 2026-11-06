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
            // Register a custom OEM message provider for the current UI culture (see
            // NcuEventMessage.Culture). Events for which no registered provider returns a
            // message use the default messages.
            var oemProvider = new OemEventMessageProvider();
            NcuEventMessage.RegisterProvider(oemProvider);

            // To remove the custom message provider again:
            ////NcuEventMessage.UnregisterProvider(oemProvider);

            // In case you want to provide system and non-system messages using a resource file
            // (the culture is determined from the file name if possible, otherwise the current
            // UI culture is used):
            ////NcuEventMessage.RegisterProvider(NcuEventMessageProvider.Load(@".\Messages.de-DE.txt"));

            // To prepare a "template" resource file you can use:
            ////((NcuEventMessageProvider)NcuEventMessage.Provider).Save(@".\Messages.en-US.txt");

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
                    e.Event.SourceTimestamp);
        }
    }
}
