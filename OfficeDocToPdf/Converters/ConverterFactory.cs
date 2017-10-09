using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OfficeDocToPdf.Converters
{
    public class ConverterFactory
    {
        private readonly List<IDocConverter> _converters;

        public ConverterFactory()
        {
            _converters = new List<IDocConverter>
            {
                new WordDocConverter(),
                new ExcelDocConverter(),
                new VisioDocConverter(),
                new PowerPointDocConverter(),
                new ProjectDocConverter(),
            };
        }

        public IDocConverter GetConverter(string fileName)
        {
            return _converters.FirstOrDefault(c => c.CanConvert(Path.GetExtension(fileName)));
        }
    }
}
