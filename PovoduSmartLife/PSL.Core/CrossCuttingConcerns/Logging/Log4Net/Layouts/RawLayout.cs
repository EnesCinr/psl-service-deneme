using log4net.Core;
using log4net.Layout;

namespace PSL.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class RawLayout : LayoutSkeleton
    {
        public RawLayout()
        {
        }
        public RawLayout(string pattern)
        {
            ConversionPattern = pattern;
        }
        public override void ActivateOptions()
        {
        }
        public string ConversionPattern { get; set; }
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var messageObject = loggingEvent.MessageObject;
            var property = messageObject.GetType().GetProperty(ConversionPattern);
            var propertyValue = property.GetValue(messageObject);
            writer.Write(propertyValue);
        }
    }
}
