
namespace OfficeDocToPdf.Converters
{
    public interface IDocConverter
    {
        bool CanConvert(string fileExtension);
        ConversionResult Convert(object inputFile, object outputFile);
    }
}
