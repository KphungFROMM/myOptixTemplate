#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.UI;
using FTOptix.DataLogger;
using FTOptix.NativeUI;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.WebUI;
using FTOptix.SerialPort;
using FTOptix.System;
#endregion

public class RoleStatus : BaseNetLogic
{
    public override void Start()
    {
        periodicTask = new PeriodicTask(StatusUpdate, 300, LogicObject);
        periodicTask.Start();
    }

    public override void Stop()
    {
        periodicTask?.Dispose();
    }

    private void StatusUpdate()
    {

        bool Variable1 = LogicObject.GetVariable("HasRoleAdmin").Value;
        bool Variable2 = LogicObject.GetVariable("HasRoleEngineer").Value;
        bool Variable3 = LogicObject.GetVariable("HasRoleMaintenance").Value;
        bool Variable4 = LogicObject.GetVariable("HasRoleOperator1").Value;
        bool Variable5 = LogicObject.GetVariable("HasRoleOperator2").Value;
        bool Variable6 = LogicObject.GetVariable("HasRoleOperator3").Value;
        bool Variable7 = LogicObject.GetVariable("HasRoleOperator4").Value;
        IUAVariable StatusOutput = LogicObject.GetVariable("RoleOutput");


        if (Variable1)
            StatusOutput.RemoteWrite("Administrator");
        else if (Variable2)
            StatusOutput.RemoteWrite("Engineer");
        else if (Variable3)
            StatusOutput.RemoteWrite("Maintenance");
        else if (Variable4)
            StatusOutput.RemoteWrite("Operator 1");
        else if (Variable5)
            StatusOutput.RemoteWrite("Operator 2");
        else if (Variable6)
            StatusOutput.RemoteWrite("Operator 3");
        else if (Variable7)
            StatusOutput.RemoteWrite("Operator 4");
        else
            StatusOutput.RemoteWrite("");

    }

    private PeriodicTask periodicTask;
}
