using MVsFileTypes.Predefined.Lists;
using MVsFileTypes.Contracts.Collections;

namespace MVsFileTypes.Predefined.Policies
{
    public static class EmailBlacklistPolicy
    {
        public static string Name = nameof(EmailBlacklistPolicy);

        public static FileTypeList GetBlacklist()
            => PredefinedFileTypes
            .Get()
            .Filter(
                ("ade adp app asp aspx asx bas bat cer chm cmd cnt com cpl" +
                "crt csh der diagcab exe fxp gadget grp hlp hpj hta htc inf" +
                "ins inp its jar jnpl js jse ksh ink mad maf mag mam maq mar" +
                "mas mat mau mav maw mcf mda mdb mde mdt mdw mdz msc msh msh1 ms2" +
                "mshxml msh1xml msh2xml msi msp mst msu ops osd pcd pif pl plg prf prg" +
                "printerexport ps1 ps1xml ps2 ps2xml psc1 psc2 psd1 psdm1 pst py pyc" +
                "pyo pyw pyz pyzw reg scf scr sct shb shs theme tmp url vb vbe vbp vbs vhd" +
                "vhdx vsmacros vsw webpnp website ws wsc wsf wsh xbap xll xnk")
                .Split(' '), FilterOptions.ThrowOnNotFoundItems);
    }
}
