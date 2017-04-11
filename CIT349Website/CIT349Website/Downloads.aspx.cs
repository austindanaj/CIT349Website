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
            var PasswordConnection = new PasswordAuthenticationMethod("sumomuf", "Temp12345");
            string myData = null;
            var connecitonInfo = new ConnectionInfo("141.210.25.93", "sumomuf", PasswordConnection);
            using (SshClient ssh = new SshClient(connecitonInfo))
            {
                ssh.Connect();
                var command = ssh.RunCommand(newcommand);
                myData = command.Result;
                ssh.Disconnect();
            }

        }


        protected void didCheckDownload1(object sender, EventArgs e)
        {
            try
            {
                
                Response.ContentType = "File/jar";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Minecraft_Forge.jar");
                Response.TransmitFile(Server.MapPath("~/Minecraft/Minecraft_Forge.jar"));
                Response.End();
            
            }catch(Exception ex)
            {
               // Response.Write(ex.ToString());
            }
           
        }
        protected void didCheckDownload2(object sender, EventArgs e)
        {
            try
            {
                if (!System.IO.File.Exists(@"C:\inetpub\wwwroot\PackageTmp\Minecraft\Minecraft_Mods.zip"))
                {
                    var PasswordConnection = new PasswordAuthenticationMethod("sumomuf", "Temp12345");
                    string myData = null;
                    var connecitonInfo = new ConnectionInfo("141.210.25.93", "sumomuf", PasswordConnection);
                    sendCommand("zip -r Minecraft_Mods.zip /home/mdrichar/minecraft/mods");


                    using (var scp = new ScpClient(connecitonInfo))
                    {

                        DirectoryInfo info = new DirectoryInfo(@"C:\inetpub\wwwroot\PackageTmp\Minecraft");

                        scp.Connect();
                        scp.Download("/home/sumomuf/Minecraft_Mods.zip", info);
                    }
                }

                Response.ContentType = "File/.zip";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Minecraft_Mods.zip");
                Response.TransmitFile(Server.MapPath("~/Minecraft/Minecraft_Mods.zip"));
                Response.End();

                
            }
            catch (Exception ex)
            {
               // Response.Write(ex.ToString());
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