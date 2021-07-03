using System;
using System.Collections.Generic;
using WebSupergoo.ABCpdf11;
using WebSupergoo.ABCpdf11.Objects;

namespace abcPDFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MergePdfs();
        }

        private static void MergePdfs()
        {
            var bookmarkIndex = 1;
            var mergedDocument = new Doc();

            var toMergeList = new List<Doc>
            {
                GetPdfStream("Applications.pdf"),
                GetPdfStream("Layout.pdf"),
            };

            foreach (var docToMerge in toMergeList)
            {
                if (docToMerge.Bookmark.Count == 0)
                {
                    var preMergePageCount = docToMerge.PageCount;

                    // Append doc and set bookmark
                    mergedDocument.Append(docToMerge);
                    AddDocBookmark(mergedDocument, bookmarkIndex++, preMergePageCount + 1);
                }
                else
                {
                    NestBookmarks(mergedDocument, bookmarkIndex++, docToMerge);
                }
            }

            mergedDocument.Save($"{AppContext.BaseDirectory}MergedPdf.pdf");
        }

        private static Doc GetPdfStream(string filename)
        {
            var pdfDocument = new Doc();
            pdfDocument.Read($"{AppContext.BaseDirectory}{filename}");

            return pdfDocument;
        }

        private static Bookmark AddDocBookmark(Doc mergeDocument, int index, int newDocInitialPageNumber)
        {
            mergeDocument.PageNumber = newDocInitialPageNumber;
            mergeDocument.AddBookmark($"Bookmark {index}", false);

            return GetBookmarkByTitle(mergeDocument, $"Bookmark {index}");
        }

        private static Bookmark GetBookmarkByTitle(Doc doc, string title)
        {
            try
            {
                var bookmarkIndex = doc.Bookmark.IndexOf(title);
                return doc.Bookmark[bookmarkIndex]; // Error occurs here. bookmarkIndex is -1
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void NestBookmarks(Doc mergeDocument, int index, Doc nextDoc)
        {
            var initialBookmarksCount = mergeDocument.Bookmark.Count;

            var preMergePageCount = mergeDocument.PageCount;

            // append the doc (with no bookmarks)
            mergeDocument.Append(nextDoc);

            var newBookmarksCount = mergeDocument.Bookmark.Count - initialBookmarksCount;

            // Bookmarks copy
            Bookmark[] allBookmarks = new Bookmark[mergeDocument.Bookmark.Count];
            // Gather all doc child bookmarks
            mergeDocument.Bookmark.CopyTo(allBookmarks, 0);

            List<Bookmark> list = new List<Bookmark>(allBookmarks);

            // Gather the chidren bookmarks for the doc just added
            Bookmark[] newBookmarks = new Bookmark[newBookmarksCount];
            list.CopyTo(initialBookmarksCount, newBookmarks, 0, newBookmarksCount);

            // Add the new parent bookmark and attach all children bookmarks underneath it
            var parentBookmark = AddDocBookmark(mergeDocument, index, preMergePageCount + 1);

            foreach (var bookmark in newBookmarks)
            {
                parentBookmark.Adopt(bookmark);
            }
        }
    }
}
