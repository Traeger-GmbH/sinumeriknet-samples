// Copyright (c) Traeger Industry Components GmbH. All Rights Reserved.

namespace Events.Messages
{
    using System.Globalization;
    using Sinumerik.Advanced;

    /// <summary>
    /// Provides the messages of custom OEM events. For all other events, it returns null, so that
    /// the messages of the other registered providers or the default messages are used.
    /// </summary>
    public class OemEventMessageProvider : NcuEventMessageProvider
    {
        #region ---------- Public constructors ----------

        public OemEventMessageProvider()
            : base()
        {
        }

        public OemEventMessageProvider(CultureInfo culture)
            : base(culture)
        {
        }

        #endregion

        #region ---------- Protected methods ----------

        protected override string GetMessageCore(NcuEventId eventId, params object[] arguments)
        {
            if (eventId.Value == 220000)
                return "Your OEM message without arguments.";

            if (eventId.Value == 220001)
                return string.Format(this.Culture, "Your OEM message with three arguments: {0}, {1} and {2}", arguments);

            return null;
        }

        #endregion
    }
}
