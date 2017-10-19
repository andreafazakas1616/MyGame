using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyGame.UI.Models
{
    public class FileDetailsModel
    {
        public int Id { get; set; }
       
        [Display(Name ="File: ")]
        public String FileName { get; set; }

        public HttpPostedFileBase UploadedFile { get; set; }
    }
}