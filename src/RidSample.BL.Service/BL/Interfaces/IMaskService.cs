namespace RidSample.BL.Service.BL.Interfaces;

public interface IMaskService
{
    string MaskNameFail(string name);
    string MaskNameByRune(string name);
    string MaskNameByChar(string name);
}