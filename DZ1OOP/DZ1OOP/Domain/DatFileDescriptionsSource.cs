using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DZ1OOP.Domain
{
    class DatFileDescriptionsSource : IDescriptionSource
    {
        List<ProductDescription> _descriptions = new List<ProductDescription>();

        public DatFileDescriptionsSource(string datFileName)
        {
            if(!File.Exists(datFileName))
            {
                var message = new StringBuilder();
                message.Append("Файл ");
                message.Append(datFileName);
                message.Append(" не найден");
                throw new FileNotFoundException(message.ToString());
            }
            var buf = File.ReadAllLines(datFileName);
            for(var i=0; i< buf.Length; i++)
            {
                var message = new StringBuilder();
                message.Append("Неправильный формат в файле ");
                message.Append(datFileName);
                var descriptionString = buf[i].Split(Convert.ToChar(92));
                if(descriptionString.Length != 3)
                {                 
                    throw new FormatException(message.ToString());
                }
                var article = descriptionString[0];
                if(article == null)
                {
                    throw new FormatException(message.ToString());
                }
                var title = descriptionString[1];
                if(title == null)
                {
                    throw new FormatException(message.ToString());
                }
                int result;
                if(!int.TryParse(descriptionString[2], out result))
                {
                    throw new FormatException(message.ToString());
                }
                var standardTime = new TimeSpan(0, result, 0);

                _descriptions.Add(new ProductDescription(article, standardTime, title));
            }
        }

        public List<ProductDescription> GetListOfDescriptions()
        {
            return _descriptions;
        }
    }
}
