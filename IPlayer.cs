using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;
namespace IFN563_N1109119_Final
{
    public interface IPlayer
    {
        int ChooseCell();
        int ChooseNumber();
    }
}

