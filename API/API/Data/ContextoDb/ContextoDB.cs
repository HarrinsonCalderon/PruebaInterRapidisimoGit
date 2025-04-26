using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace API.Data.ContextoDb
{
    public   class ContextoDB
    {
        public string cadenaSql { get; set; }

        public ContextoDB( )
        {
            cadenaSql = "Server=DESKTOP-PTHQSOO\\SQLEXPRESS;database=Academico;User ID=SA;Password=12345";

        }
        public ContextoDB(String caden)
        {
               cadenaSql = caden;

        }
    }
}
