using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remote_Query_Tool
{
    /// <summary>
    /// Contains options to be saved/loaded. This struct is simple and public to allow for easy XMLSerialization based save/load
    /// </summary>
    public struct Options
    {
        public string pcNameText;
        public string inputTBText;
        public string outputTBText;
        public bool singleQueryChecked;
        public bool multipleQueriesChecked;
        public decimal simultaneousQValue;
        public bool currentUserRBChecked;
        public bool usersRBChecked;
        public bool localMachineRBChecked;
        public string keyPathTBText;
        public bool existsRBChecked;
        public bool outputRBChecked;
        public bool valueRBChecked;
        public string valueTBText;
        public bool ProcessRBChecked;
        public bool ServicesRBChecked;
        public bool SingleRBChecked;
        public bool MultipleRBChecked;
        public string toSearchForText;
        public bool restartCheckBoxChecked;
        public string CmdLine1Text;
        public string CmdLine2Text;
        public string CmdLine3Text;
        public string CmdLine4Text;
        public string CmdLine5Text;
        public bool echoOffBoxChecked;
        public bool ServiceDisplayNameChecked;
        public bool ServiceSystemNameChecked;
    }
}
