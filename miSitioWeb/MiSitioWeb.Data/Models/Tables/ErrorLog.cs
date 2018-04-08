namespace MiSitioWeb.Data.Models.Tables
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ErrorLog
    {
        [Key]
        public int ErrorLogId { get; set; }

        [MaxLength(200, ErrorMessage = "The field {0} contains a maximun of {1} characters")]
        public string ActionName { get; set; }

        [MaxLength(200, ErrorMessage = "The field {0} contains a maximun of {1} characters")]
        public string ExceptionName { get; set; }

        [MaxLength(200, ErrorMessage = "The field {0} contains a maximun of {1} characters")]
        public string Message { get; set; }

        public int UserId { get; set; }
    }
}
