using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace Longmao.Web.Sites.ajax
{
    public partial class file : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection files = Request.Files;
            string msg = string.Empty;
            string error = string.Empty;
            string imgurl;

            if (files.Count > 0)
            {
                HttpPostedFile postedFile = files[0];
                string FileType = postedFile.ContentType.ToString();
                string fileName, fileExtension;
                fileName = Path.GetFileName(postedFile.FileName);
                fileExtension = Path.GetExtension(fileName);

                string filePath = "";
                string res = "";

                filePath = RandomFileName() + fileExtension;
                if ((fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif") && postedFile.ContentLength / 1024 <= 1024)
                {
                    files[0].SaveAs(Server.MapPath("/longmao/images/upload/") + filePath);
                    msg = " 成功! 文件大小为:" + files[0].ContentLength;
                    imgurl = "/longmao/images/upload/" + filePath;
                }
                else
                {
                    imgurl = "";
                    error = "必须上传1M的图片文件。";
                }

                res = "{ error:'" + error + "', msg:'" + msg + "',imgurl:'" + imgurl + "'}";
                Response.Write(res);
                Response.End();
            }
        }

        protected bool upMorefile()
        {

            //遍历File表单元素
            HttpFileCollection files = HttpContext.Current.Request.Files;
            //状态信息
            StringBuilder strMsg = new StringBuilder("成功上传的文件信息分别为：<hr color=red>");
            int fileCount;
            int filecount = files.Count;

            try
            {
                for (fileCount = 0; fileCount < files.Count; fileCount++)
                {
                    //定义访问客户端上传文件的对象
                    System.Web.HttpPostedFile postedFile = files[fileCount];
                    string FileType = postedFile.ContentType.ToString();//获取要上传的文件类型,验证文件头  

                    string fileName, fileExtension;
                    //取得上传得文件名
                    fileName = Path.GetFileName(postedFile.FileName);
                    //取得文件的扩展名
                    fileExtension = Path.GetExtension(fileName);

                    //在上传文件不为空的情况下，验证文件名以及大小是否符合，如果不符合则不允许上传
                    if (((FileType == "text/plain" && fileExtension.ToLower() == ".txt") || (FileType == "application/x-zip-compressed" && fileExtension.ToLower() == ".zip") || (FileType == "application/octet-stream" && fileExtension.ToLower() == ".rar")) && postedFile.ContentLength / 1024 <= 1024)
                    {

                        if (fileName != String.Empty)
                        {
                            fileName = RandomFileName() + fileExtension;

                            //上传的文件信息
                            strMsg.Append("上传的文件类型：" + postedFile.ContentType.ToString() + "<br>");
                            strMsg.Append("客户端文件地址：" + postedFile.FileName + "<br>");
                            strMsg.Append("上传文件的文件名：" + fileName + "<br>");
                            strMsg.Append("上传文件的大小为：" + postedFile.ContentLength + "字节<br>");
                            strMsg.Append("上传文件的扩展名：" + fileExtension + "<br><hr color=red>");
                            //保存到指定的文件夹
                            postedFile.SaveAs(Server.MapPath("public_file/") + fileName);
                            fileName = "";

                        }
                    }
                    else
                    {
                        Response.Write("第" + (fileCount + 1) + "个文件不符合要求<br/>  ");
                    }

                }

                Response.Write(strMsg.ToString());
                return true;
            }
            catch (System.Exception error)
            {
                Response.Write(error.Message);
                return false;
            }
        }

        /// <summary>
        /// 生成文件名称
        /// </summary>
        /// <returns></returns>
        public string RandomFileName()
        {
            string filename = "";
            filename = DateTime.Now.ToString("yyyyMMddHHmmss");
            return filename;
        }
    }
}