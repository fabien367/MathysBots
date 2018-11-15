using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Mathys.Services.Services
{
    public class EmbeddedDocuments
    {
        public static Stream GetDocumentStream(string RessourceId)
        {
            if (String.IsNullOrEmpty(RessourceId))
                return null;
            else
            {
                var assembly = typeof(EmbeddedDocuments).Assembly;
                var stream = assembly.GetManifestResourceStream(RessourceId);

                return stream;
            }
        }
    }
}
