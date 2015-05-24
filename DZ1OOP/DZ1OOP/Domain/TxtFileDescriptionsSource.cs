using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DZ1OOP.Domain
{
    class TxtFileDescriptionsSource : IDescriptionSource
    {
        List<ProductDescription> _descriptions = new List<ProductDescription>();

        public TxtFileDescriptionsSource(string txtFileName)
        {
            if (!File.Exists(txtFileName))
            {
                var message = new StringBuilder();
                message.Append("Файл ");
                message.Append(txtFileName);
                message.Append(" не найден");
                throw new FileNotFoundException(message.ToString());
            }
            var buf = File.ReadAllLines(txtFileName);
            for(var i=0; i< buf.Length; i++)
            {
                var message = new StringBuilder();
                message.Append("Неправильный формат в файле ");
                message.Append(txtFileName);
                message.Append(" Верный формат: Article;Title;StandardTime1;StandardTime2");

                var descriptionString = buf[i].Split(';');
                if (descriptionString.Length != 4)
                {
                    throw new FormatException(message.ToString());
                }
                var article = descriptionString[0];
                if (article == null)
                {
                    throw new FormatException(message.ToString());
                }
                var title = descriptionString[1];
                if (title == null)
                {
                    throw new FormatException(message.ToString());
                }
                var firstStandardTime = new TimeSpan();
                var secondStandardTime = new TimeSpan();
                if(!TimeSpan.TryParse(descriptionString[2], out firstStandardTime) ||
                    !TimeSpan.TryParse(descriptionString[3], out secondStandardTime) )
                {
                    throw new FormatException(message.ToString());
                }

                var standardTime = firstStandardTime + secondStandardTime;
                _descriptions.Add(new ProductDescription(article, standardTime, title));
            }
        }

        public List<ProductDescription> GetListOfDescriptions()
        {
            return _descriptions;
        }
    }
}
