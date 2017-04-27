using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeoDataLayer.Utils
{
    // enum for handling delete errors
    public enum Status
    {
        Saved,
        Deleted,
        Ok,
        Invalid,
        ProjectAttatchedToIssue,
        ProjectAttachedToProject,
        ProjectStatusAttachedToProject,
        FileNotOnDisk,
        UnexpectedError,
        NotFound
    }

    public static class StatusExtensions
    {
        public static string Get(this Status status)
        {
            switch (status)
            {
                case Status.Saved:
                    return "Saved!";
                case Status.Deleted:
                    return "Deleted!";
                case Status.UnexpectedError:
                    return "Unexpected error";
                case Status.ProjectAttachedToProject:
                    return "The project that you attempted to delete is attached as parent project to another project, therefore it can not be deleted!";
                case Status.ProjectAttatchedToIssue:
                    return "The project that you attempted to delete is attached to an issue therefore it can not be deleted!";
                case Status.ProjectStatusAttachedToProject:
                    return "The project status that you attempted to delete it is attached to a project therefore it can not be deleted!";
                case Status.FileNotOnDisk:
                    return "The file is not longer on your disk!";
                case Status.NotFound:
                    return "Item not found!";
                case Status.Ok:
                    return "OK";
                case Status.Invalid:
                    return "Model is not valid!";
                default:
                    return "Unknouwn";
            }
        }
    }

    public enum AlertType
    {
        Success,
        Danger
    }

    public static class AlertTypeExtensions
    {
        public static string Get(this AlertType alert)
        {
            switch (alert)
            {
                case AlertType.Success:
                    return "success";
                case AlertType.Danger:
                    return "danger";
                default:
                    return "success";
            }
        }
    }

    [Serializable]
    public class AlertMessage
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public bool AllowDismiss { get; set; }
        public int Delay { get; set; }

        public AlertMessage(string message, string type, bool allowDismiss = true, int delay = 1000)
        {
            Message = message;
            Type = type;
            AllowDismiss = allowDismiss;
            Delay = delay;
        }
    }
}
