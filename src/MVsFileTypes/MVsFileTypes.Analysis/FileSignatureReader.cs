using System;
using System.IO;
using System.Linq;
using MVsFileTypes.Contracts;
using System.Collections.Generic;

namespace MVsFileTypes.Analysis
{
    public class FileSignatureReader : IDisposable
    {
        readonly FileInfo fileInfo;
        readonly int signatureMaxLength;
        readonly FileSignature[] signatures;

        public FileSignatureReader(string filePath, IEnumerable<FileSignature> fileSignatures)
        {
            fileInfo = new FileInfo(filePath);
            signatures = fileSignatures.ToArray();

            signatureMaxLength = signatures
                .Select(signature => signature.Length)
                .DefaultIfEmpty(0)
                .Max();
        }

        public bool FileExists()
           => fileInfo.Exists;

        public bool IsFileBlocked()
        {
            try
            {
                using (var stream = new FileStream(
                    fileInfo.FullName
                    , FileMode.Open
                    , FileAccess.Read
                    , FileShare.Read
                    , signatureMaxLength))
                    return false;
            }
            catch (SystemException e)
            {
                if (BlockedBecauseOfVirusHResults.Contains(e.HResult))
                    return true;

                throw e;
            }
        }

        public IEnumerable<int> BlockedBecauseOfVirusHResults
            => new[] { -2147467259, -2147024671, -2147024891 };

        public FileSignature GetFileSignature()
        {
            if (signatureMaxLength == 0)
                return FileSignature.Unknown;

            using (var stream = new FileStream(
                fileInfo.FullName
                , FileMode.Open
                , FileAccess.Read
                , FileShare.Read
                , signatureMaxLength))
            {
                var buffer = new byte[signatureMaxLength];
                stream.Read(buffer, 0, signatureMaxLength);

                return signatures
                    .Where(signature => IsSignatureMatch(buffer, signature))
                    .DefaultIfEmpty(FileSignature.Unknown)
                    .FirstOrDefault();
            }
        }

        static bool IsSignatureMatch(byte[] bytes, FileSignature signature)
        {
            if (signature.Length > bytes.Length)
                return false;

            var sameLengthBytes = new byte[signature.Length];
            Array.Copy(bytes, sameLengthBytes, signature.Length);

            return BitConverter.ToString(sameLengthBytes) == signature.Bytes;
        }

        public void Dispose()
        {
        }
    }
}