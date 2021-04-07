// Copyright (c) Traeger Industry Components GmbH. All Rights Reserved.

namespace Events.Messages
{
    using Sinumerik.Advanced;

    public class OemEventMessageProvider : NcuEventMessageProvider
    {
        #region ---------- Private readonly fields ----------

        private readonly INcuEventMessageProvider fallbackProvider;

        #endregion

        #region ---------- Public constructors ----------

        public OemEventMessageProvider()
            : this(Default)
        {
        }

        public OemEventMessageProvider(INcuEventMessageProvider fallbackProvider)
            : base()
        {
            this.fallbackProvider = fallbackProvider ?? Default;
        }

        #endregion

        #region ---------- Public methods ----------

        public override string GetMessage(long eventId, params object[] arguments)
        {
            var message = this.fallbackProvider.GetMessage(eventId, arguments);

            if (message == null) {
                if (eventId == 220000)
                    message = "Your OEM message without arguments.";
                else if (eventId == 220001)
                    message = string.Format(this.Culture, "Your OEM message with three arguemnts: {0}, {1} and {2}", arguments);
            }

            return message;
        }

        #endregion
    }
}
