using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace OfficeDocToPdf.Converters
{
    public abstract class DocConverter
    {
        protected abstract string ExtensionList { get; }

        public virtual bool CanConvert(string fileExtension)
        {
            var extensions = GetExtensions(ExtensionList);
            return extensions.Contains(fileExtension.TrimStart('.'));
        }

        private List<string> GetExtensions(string extensionList)
        {
            var list = ConfigurationManager.AppSettings[extensionList];

            return list?.Split(',').ToList() ?? new List<string>();
        }
    }
}
