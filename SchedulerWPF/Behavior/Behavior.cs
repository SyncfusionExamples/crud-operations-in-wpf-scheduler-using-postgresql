using SchedulerSample.Helper;
using Syncfusion.UI.Xaml.Scheduler;
using System.Windows.Interactivity;

namespace SchedulerSample
{
    public class Behavior:Behavior<SfScheduler>
    { 
        protected override void OnAttached()
        {
            this.AssociatedObject.AppointmentEditorClosing += AssociatedObject_AppointmentEditorClosing;
        }

        private void AssociatedObject_AppointmentEditorClosing(object sender, AppointmentEditorClosingEventArgs e)
        {
            if (e.Action == AppointmentEditorAction.Add)
            {
                string psqlAdd = "insert into Meetings (Subject,StartTime,EndTime)values('" + e.Appointment.Subject + "', '" + e.Appointment.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' , '" + e.Appointment.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                ConnectPSQL.ExecutePSQLQuery(psqlAdd);
            }
            else if (e.Action == AppointmentEditorAction.Delete)
            {
                string psqlDelete = "delete from Meetings where Subject ='" + e.Appointment.Subject + "';";
                ConnectPSQL.ExecutePSQLQuery(psqlDelete);
            }
            else if (e.Action == AppointmentEditorAction.Edit)
            {
                string psqlUpdate = "update Meetings set StartTime='" + e.Appointment.StartTime + "',EndTime='" + e.Appointment.EndTime + "' where Subject='" + e.Appointment.Subject + "';";
                ConnectPSQL.ExecutePSQLQuery(psqlUpdate);
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.AppointmentEditorClosing -= AssociatedObject_AppointmentEditorClosing;
        }
    }
}
