    //
    //  Copyright 2021  2021
    //
    //    Licensed under the Apache License, Version 2.0 (the "License");
    //    you may not use this file except in compliance with the License.
    //    You may obtain a copy of the License at
    //
    //        http://www.apache.org/licenses/LICENSE-2.0
    //
    //    Unless required by applicable law or agreed to in writing, software
    //    distributed under the License is distributed on an "AS IS" BASIS,
    //    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    //    See the License for the specific language governing permissions and
    //    limitations under the License.
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Services
    {
        public  static class IMageService
        {
            public const int ImageMinimumBytes = 512;

            private const int exifOrientationID = 0x112; //274
                                                      
            public static bool IsImage(IFormFile postedFile)
            {
                //-------------------------------------------
                //  Check the image mime types
                //-------------------------------------------
                if (postedFile.ContentType.ToLower() != "image/jpg" &&
                            postedFile.ContentType.ToLower() != "image/jpeg") 
                {
                    return false;
                }

                //-------------------------------------------
                //  Check the image extension
                //-------------------------------------------
                if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                
                    && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
                {
                    return false;
                }

                //-------------------------------------------
                //  Attempt to read the file and check the first bytes
                //-------------------------------------------
                try
                {
                    if (!postedFile.OpenReadStream().CanRead)
                    {
                        return false;
                    }
                    //------------------------------------------
                    //check whether the image size exceeding the limit or not
                    //------------------------------------------ 
                    if (postedFile.Length < ImageMinimumBytes)
                    {
                        return false;
                    }

                    byte[] buffer = new byte[ImageMinimumBytes];
                    postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
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

                //-------------------------------------------
                //  Try to instantiate new Bitmap, if .NET will throw exception
                //  we can assume that it's not a valid image
                //-------------------------------------------

                try
                {
                    using (var bitmap = new System.Drawing.Bitmap(postedFile.OpenReadStream()))
                    {
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    postedFile.OpenReadStream().Position = 0;
                }

                return true;
            }
            public static string GetUniqueFileName(string fileName)
            {
                fileName = Path.GetFileName(fileName);
                return Path.GetFileNameWithoutExtension(fileName)
                          + "_"
                          + Guid.NewGuid().ToString().Substring(0, 4)
                          + Path.GetExtension(fileName);
            }


       

            public static void ExifRotate(this Image img)
            {
                if (!img.PropertyIdList.Contains(exifOrientationID))
                    return;

                var prop = img.GetPropertyItem(exifOrientationID);
                int val = BitConverter.ToUInt16(prop.Value, 0);
                var rot = RotateFlipType.RotateNoneFlipNone;

                if (val == 3 || val == 4)
                    rot = RotateFlipType.Rotate180FlipNone;
                else if (val == 5 || val == 6)
                    rot = RotateFlipType.Rotate90FlipNone;
                else if (val == 7 || val == 8)
                    rot = RotateFlipType.Rotate270FlipNone;

                if (val == 2 || val == 4 || val == 5 || val == 7)
                    rot |= RotateFlipType.RotateNoneFlipX;

                if (rot != RotateFlipType.RotateNoneFlipNone)
                    img.RotateFlip(rot);
            }

            public static void checkBackground()
            {
             // accept only white background
            }


    }



}
