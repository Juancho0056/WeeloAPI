using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Extensions
{
    public static class HttpPostedFileBaseExtensions
    {
        public static bool IsImage(this IFormFile File, int ImageMinimumBytes)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            //if (!string.Equals(File.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
            //    !string.Equals(File.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
            //    !string.Equals(File.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
            //    !string.Equals(File.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
            //    !string.Equals(File.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
            //    !string.Equals(File.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
            //{
            //    return false;
            //}

            try
            {

                Image.FromStream(File.OpenReadStream());
                byte[] buffer = new byte[ImageMinimumBytes];
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
