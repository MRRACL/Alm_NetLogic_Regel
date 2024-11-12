#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.Recipe;
#endregion

public class Alarm_Net : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]

    public void EvalAlarmInt()
    {
        // Initialize and read inputs

        int alm_no = LogicObject.GetVariable("AlmInt").Value;

        

        
        foreach (IUANode childrenObject in Project.Current.Get("Alarms").Children)
        {
            try
            {
                if (childrenObject.GetVariable("AlmNumb").Value == alm_no)
                {
                    childrenObject.GetVariable("InputValue").Value = 1;
                }
                else
                {
                    childrenObject.GetVariable("InputValue").Value = 0;
                }

               
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Log.Error("FindPages.Catch", "Exception thrown: " + ex.Message);
            }
        }

        

       

    }
}
