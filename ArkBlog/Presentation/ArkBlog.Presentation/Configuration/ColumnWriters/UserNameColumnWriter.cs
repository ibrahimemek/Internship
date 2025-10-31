using NpgsqlTypes;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace ArkBlog.Presentation.Configuration.ColumnWriters
{
    public class UserNameColumnWriter : ColumnWriterBase
    {
        public UserNameColumnWriter() : base(NpgsqlDbType.Varchar)
        {
        }

        public override object GetValue(LogEvent logEvent, IFormatProvider formatProvider = null)
        {
            return new();
        }
    }
}
