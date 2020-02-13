using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EM.IServicio.Helpers.Foto
{
    //
    // Resumen:
    //     Represents a file sent with the HttpRequest.
    public interface IFormFile
    {
        //
        // Resumen:
        //     Gets the raw Content-Type header of the uploaded file.
        string ContentType { get; }
        //
        // Resumen:
        //     Gets the raw Content-Disposition header of the uploaded file.
        string ContentDisposition { get; }
        //
        // Resumen:
        //     Gets the header dictionary of the uploaded file.
        IHeaderDictionary Headers { get; }
        //
        // Resumen:
        //     Gets the file length in bytes.
        long Length { get; }
        //
        // Resumen:
        //     Gets the form field name from the Content-Disposition header.
        string Name { get; }
        //
        // Resumen:
        //     Gets the file name from the Content-Disposition header.
        string FileName { get; }

        //
        // Resumen:
        //     Copies the contents of the uploaded file to the target stream.
        //
        // Parámetros:
        //   target:
        //     The stream to copy the file contents to.
        void CopyTo(Stream target);
        //
        // Resumen:
        //     Asynchronously copies the contents of the uploaded file to the target stream.
        //
        // Parámetros:
        //   target:
        //     The stream to copy the file contents to.
        //
        //   cancellationToken:
        Task CopyToAsync(Stream target, CancellationToken cancellationToken = default);
        //
        // Resumen:
        //     Opens the request stream for reading the uploaded file.
        Stream OpenReadStream();
    }
}
