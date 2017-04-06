using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO.Compression;
using System.IO;
using Renci.SshNet;

namespace CIT349Website
{

    public partial class Downloads : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ourdb"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void sendCommand(string newcommand)
        {
            var PasswordConnection = new PasswordAuthenticationMethod("djmadurs", "r4vedave!");
            string myData = null;
            var connecitonInfo = new ConnectionInfo("141.210.25.85", "djmadurs", PasswordConnection);
            using (SshClient ssh = new SshClient(connecitonInfo))
            {
                ssh.Connect();
                var command = ssh.RunCommand(newcommand);
                myData = command.Result;
                ssh.Disconnect();
            }

        }


        protected void didCheckDownload(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("~/Downloads/Minecraft_Forge.zip"))
                {
                    Response.ContentType = "File/zip";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Minecraft_Forge.zip");
                    Response.TransmitFile(Server.MapPath("~/Downloads/Minecraft_Forge.zip"));
                    Response.End();
                }
                else
                {
                    var PasswordConnection = new PasswordAuthenticationMethod("djmadurs", "r4vedave!");
                    string myData = null;
                    var connecitonInfo = new ConnectionInfo("141.210.25.85", "djmadurs", PasswordConnection);
                    sendCommand("tar -czvf Minecraft_Forge.tar.gz /home/djmadurs/whitelist.json");
                    using (var sftp = new SftpClient(connecitonInfo))
                    {
                        string localFileName = Path.GetDirectoryName("~/Downloads");
                        string remoteFile = "";
                        sftp.Connect();
                        Stream file1 = File.OpenWrite(localFileName);

                        sftp.DownloadFile("/home/djmadurs/whitelist.json", file1);
                        sftp.Disconnect();
                    }



                }
            }catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
           
        }
        private static void DownloadDirectory(SftpClient client, string source, string destination)
        {
            var files = client.ListDirectory(source);
            foreach (var file in files)
            {
                if (!file.IsDirectory && !file.IsSymbolicLink)
                {
                    DownloadFile(client, file, destination);
                }
                else if (file.IsSymbolicLink)
                {
                    Console.WriteLine("Ignoring symbolic link {0}", file.FullName);
                }
                else if (file.Name != "." && file.Name != "..")
                {
                    var dir = Directory.CreateDirectory(Path.Combine(destination, file.Name));
                    DownloadDirectory(client, file.FullName, dir.FullName);
                }
            }
        }
        private static void DownloadFile(SftpClient client, Renci.SshNet.Sftp.SftpFile file, string directory)
        {
            Console.WriteLine("Downloading {0}", file.FullName);
            using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
            {
                client.DownloadFile(file.FullName, fileStream);
            }
        }
       

    }
}