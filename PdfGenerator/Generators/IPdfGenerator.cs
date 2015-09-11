
namespace PdfGenerator.Generators
{
    interface IPdfGenerator
    {
        byte[] GeneratePdf(PdfRequest request);
    }
}
