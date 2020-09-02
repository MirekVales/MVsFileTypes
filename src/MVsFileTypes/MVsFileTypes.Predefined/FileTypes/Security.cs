using MVsFileTypes.Contracts;
using MVsFileTypes.Contracts.Collections;
using System.Collections.Generic;

namespace MVsFileTypes.Predefined.FileTypes
{
    public static class Security
    {
        public static string ID = "SEC";
        public static string UserName = "Security File Types";

        public static IEnumerable<FileType> GetFileTypes()
        {
            yield return (ID + "01", "csr", "Certificate Signing Request File");
            yield return (ID + "02", "crl", "Certificate Revocation List File");
            yield return (ID + "03", "pem;crt;ca-bundle", "PEM Certificate File");
            yield return (ID + "04", "p7b;p7s", "PKCS#7 Certificate File");
            yield return (ID + "05", "p10", "PKCS#10 Certificate File");
            yield return (ID + "06", "pfx;p12", "PKCS#12 Certificate File");
            yield return (ID + "07", "cer;der", "Binary Certificate File");
            yield return (ID + "08", "csr", "Certificate Signing Request File");
            yield return (ID + "09", "rsa", "RSA Certificate File");
        }

        public static FileTypeGroup Get()
            => new FileTypeGroup()
            {
                ID = Security.ID,
                Name = Security.UserName,
                FileTypes = GetFileTypes()
            };
    }
}
