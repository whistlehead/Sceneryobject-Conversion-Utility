using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SceneryobjectConversionUtility
{

    public partial class Form1 : Form
    {
        private readonly string programVersion = "v0.3.3";
        private readonly string programFilePath = Application.StartupPath;
        private readonly string programOpeningMessage = "In this version:\r\n - Blender and COLLADA files supported\r\n - Little to no error checking, if it breaks it breaks - No overwrite checking on output\r\n - Transparency may cause render order artefacts\r\n - Temporary X file directories are not cleaned up\r\n\r\nNOTE: You must have OMSI 2, the OMSI SDK and Blender v2.79 properly installed to use this utility";

        private readonly int MAX_X_SIZE_BYTES = 8000000;

        private string fullPathPython;
        private string fullPathPythonOutput;
        private string fullPathTexconv;
        private string fullPathSCOTemplate;
        private string fullPathOMSI;
        private string fullPathXconv;
        private string fullPathBlender;

        private string objectNameDirty;
        private string objectNameClean;

        private int objectGroupsNo = 0;
        private string[] objectGroups = new string[5];

        private string filePathSource;
        private string fullPathSource;
        private string filePathTemp;

        private string filePathOutput;
        private string filePathOutputModel;
        private string filePathOutputTexture;
        private string fullPathTempDirectX;
        private string fullPathTempO3D;
        //private string fullPathOutputDirectX;
        private string fullPathOutputO3D;
        private string fullPathOutputSCO;

        public int existsBehaviour = 0;

        private bool tidyUp = false;

        private bool initialised = false;

        public Form1()
        {
            InitializeComponent();
            fullPathOMSI = Properties.Settings.Default.fullPathOMSI;
            if (File.Exists(fullPathOMSI))
            {
                lbl_browseOMSI.Text = fullPathOMSI;
                pic_browseOMSI.BackColor = Color.Lime;
            }
            fullPathXconv = Properties.Settings.Default.fullPathXconv;
            if (File.Exists(fullPathXconv))
            {
                lbl_browseXconv.Text = fullPathXconv;
                pic_browseXconv.BackColor = Color.Lime;
            }
            fullPathBlender = Properties.Settings.Default.fullPathBlender;
            if (File.Exists(fullPathBlender))
            {
                lbl_browseBlender.Text = fullPathBlender;
                pic_browseBlender.BackColor = Color.Lime;
            }
            filePathSource = Properties.Settings.Default.filePathSource;
            filePathOutput = Properties.Settings.Default.filePathOutput;
            if (Directory.Exists(filePathOutput))
            {
                lbl_browseOutput.Text = filePathOutput;
                filePathOutputModel = filePathOutput + "\\Model";
                filePathOutputTexture = filePathOutput + "\\Texture";
            }
            cbx_yUp.Checked = Properties.Settings.Default.yUp;
            cbx_prefixTexture.Checked = Properties.Settings.Default.prefixTextureNames;
            cbx_includeTransparency.Checked = Properties.Settings.Default.includeTransparency;

            cbx_getFileNameFromFile.Checked = Properties.Settings.Default.fileNameFromFile;
            cbx_getFriendlynameFromFile.Checked = Properties.Settings.Default.friendlyNameFromFile;
            
            switch(Properties.Settings.Default.groupsIndex)
            {
                case 0:
                    rdb_groups0.Checked = true;
                    break;
                case 1:
                    rdb_groups1.Checked = true;
                    break;
                case 2:
                    rdb_groups2.Checked = true;
                    break;
                case 3:
                    rdb_groups3.Checked = true;
                    break;
                case 4:
                    rdb_groups4.Checked = true;
                    break;
                default:
                    break;
            }

            tbx_groups1.Text = Properties.Settings.Default.groups1;
            tbx_groups2.Text = Properties.Settings.Default.groups2;
            tbx_groups3.Text = Properties.Settings.Default.groups3;
            tbx_groups4.Text = Properties.Settings.Default.groups4;

            CheckEnableConvertButton();

            string openingMessageBoxTitle = "Sceneryobject Conversion Utility " + programVersion;
            MessageBox.Show(programOpeningMessage, openingMessageBoxTitle);

            initialised = true;
        }

        //GUI METHODS

        private void Btn_browseOMSI_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd_browseOMSI.ShowDialog();
            if (result == DialogResult.OK)
            {
                fullPathOMSI = ofd_browseOMSI.FileName;
                lbl_browseOMSI.Text = fullPathOMSI;
                pic_browseOMSI.BackColor = Color.Lime;
                Properties.Settings.Default.fullPathOMSI = fullPathOMSI;
                Properties.Settings.Default.Save();
            }
            CheckEnableConvertButton();
        }

        private void Btn_browseXconv_Click(object sender, EventArgs e)
        {
            ofd_browseXconv.InitialDirectory = Path.GetDirectoryName(fullPathOMSI);
            DialogResult result = ofd_browseXconv.ShowDialog();
            if (result == DialogResult.OK)
            {
                fullPathXconv = ofd_browseXconv.FileName;
                lbl_browseXconv.Text = fullPathXconv;
                pic_browseXconv.BackColor = Color.Lime;
                Properties.Settings.Default.fullPathXconv = fullPathXconv;
                Properties.Settings.Default.Save();
            }
            CheckEnableConvertButton();
        }

        private void Btn_browseBlender_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd_browseBlender.ShowDialog();
            if (result == DialogResult.OK)
            {
                fullPathBlender = ofd_browseBlender.FileName;
                lbl_browseBlender.Text = fullPathBlender;
                pic_browseBlender.BackColor = Color.Lime;
                Properties.Settings.Default.fullPathBlender = fullPathBlender;
                Properties.Settings.Default.Save();
            }
            CheckEnableConvertButton();
        }

        private void Tbx_ModelName(object sender, EventArgs e)
        {
            {
                if (tbx_fileName.Text != null && tbx_fileName.Text != "")
                {
                    objectNameDirty = tbx_fileName.Text;
                    objectNameClean = CleanDirtyString(objectNameDirty);
                    lbl_fileName.Text = objectNameClean;
                }
            }

            CheckEnableConvertButton();
        }

        private void Btn_browseSource_Click(object sender, EventArgs e)
        {
            fbd_browseTexture.SelectedPath = filePathSource;
            DialogResult result = ofd_browseSource.ShowDialog();
            if (result == DialogResult.OK)
            {
                fullPathSource = ofd_browseSource.FileName;
                lbl_browseSource.Text = fullPathSource;
                filePathSource = Path.GetDirectoryName(fullPathSource);
                Properties.Settings.Default.filePathSource = filePathSource;
                Properties.Settings.Default.Save();
                cbx_getFileNameFromFile.Enabled = true;
                GetObjectNameFromFile();
                cbx_getFriendlynameFromFile.Enabled = true;
                GetFriendlynameFromFile();
            }
            CheckEnableConvertButton();
        }

        private void Cbx_yUp_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.yUp = cbx_yUp.Checked;
            Properties.Settings.Default.Save();
        }

        private void Cbx_getNameFromFile(object sender, EventArgs e)
        {
            if(initialised) GetObjectNameFromFile();

            Properties.Settings.Default.fileNameFromFile = cbx_getFileNameFromFile.Checked;
            Properties.Settings.Default.Save();

            CheckEnableConvertButton();
        }

        private void Cbx_getFriendlynameFromFile(object sender, EventArgs e)
        {
            if (initialised) GetFriendlynameFromFile();

            Properties.Settings.Default.friendlyNameFromFile = cbx_getFriendlynameFromFile.Checked;
            Properties.Settings.Default.Save();

            CheckEnableConvertButton();
        }

        private void Btn_browseOutput_Click(object sender, EventArgs e)
        {
            fbd_browseOutput.SelectedPath = Path.GetDirectoryName(fullPathOMSI) + "\\Sceneryobjects";
            DialogResult result = fbd_browseOutput.ShowDialog();
            if (result == DialogResult.OK)
            {
                filePathOutput = fbd_browseOutput.SelectedPath;
                lbl_browseOutput.Text = filePathOutput;
                filePathOutputModel = filePathOutput + "\\Model";
                filePathOutputTexture = filePathOutput + "\\Texture";
                Properties.Settings.Default.filePathOutput = filePathOutput;
                Properties.Settings.Default.Save();
            }
            CheckEnableConvertButton();
        }

        private void Rdb_groups0_CheckedChanged(object sender, EventArgs e)
        {
            objectGroupsNo = 0;
            tbx_groups1.Enabled = false;
            tbx_groups2.Enabled = false;
            tbx_groups3.Enabled = false;
            tbx_groups4.Enabled = false;

            Properties.Settings.Default.groupsIndex = objectGroupsNo;
            Properties.Settings.Default.Save();

        }

        private void Rdb_groups1_CheckedChanged_1(object sender, EventArgs e)
        {
            objectGroupsNo = 1;
            tbx_groups1.Enabled = true;
            tbx_groups2.Enabled = false;
            tbx_groups3.Enabled = false;
            tbx_groups4.Enabled = false;
            objectGroups[1] = tbx_groups1.Text;

            Properties.Settings.Default.groupsIndex = objectGroupsNo;
            Properties.Settings.Default.Save();
        }

        private void Rdb_groups2_CheckedChanged(object sender, EventArgs e)
        {
            objectGroupsNo = 2;
            tbx_groups1.Enabled = true;
            tbx_groups2.Enabled = true;
            tbx_groups3.Enabled = false;
            tbx_groups4.Enabled = false;
            objectGroups[2] = tbx_groups2.Text;

            Properties.Settings.Default.groupsIndex = objectGroupsNo;
            Properties.Settings.Default.Save();
        }

        private void Rdb_groups3_CheckedChanged(object sender, EventArgs e)
        {
            objectGroupsNo = 3;
            tbx_groups1.Enabled = true;
            tbx_groups2.Enabled = true;
            tbx_groups3.Enabled = true;
            tbx_groups4.Enabled = false;
            objectGroups[3] = tbx_groups3.Text;

            Properties.Settings.Default.groupsIndex = objectGroupsNo;
            Properties.Settings.Default.Save();
        }

        private void Rdb_groups4_CheckedChanged(object sender, EventArgs e)
        {
            objectGroupsNo = 4;
            tbx_groups1.Enabled = true;
            tbx_groups2.Enabled = true;
            tbx_groups3.Enabled = true;
            tbx_groups4.Enabled = true;
            objectGroups[4] = tbx_groups4.Text;

            Properties.Settings.Default.groupsIndex = objectGroupsNo;
            Properties.Settings.Default.Save();
        }

        private void Tbx_groups1_TextChanged(object sender, EventArgs e)
        {
            objectGroups[1] = tbx_groups1.Text;

            Properties.Settings.Default.groups1 = tbx_groups1.Text;
            Properties.Settings.Default.Save();

        }

        private void Tbx_groups2_TextChanged(object sender, EventArgs e)
        {
            objectGroups[2] = tbx_groups2.Text;

            Properties.Settings.Default.groups2 = tbx_groups2.Text;
            Properties.Settings.Default.Save();
        }

        private void Tbx_groups3_TextChanged(object sender, EventArgs e)
        {
            objectGroups[3] = tbx_groups3.Text;

            Properties.Settings.Default.groups3 = tbx_groups3.Text;
            Properties.Settings.Default.Save();
        }

        private void Tbx_groups4_TextChanged(object sender, EventArgs e)
        {
            objectGroups[4] = tbx_groups4.Text;

            Properties.Settings.Default.groups4 = tbx_groups4.Text;
            Properties.Settings.Default.Save();
        }

        private void Btn_Convert_Click(object sender, EventArgs e)
        {
            DoConversion();
            if (tidyUp) DeleteFolder(filePathTemp); 
        }

        //INTERNAL METHODS

        private void DoConversion()
        {

            btn_convert.Enabled = false;
            bool convertTransparent = cbx_includeTransparency.Checked;
            bool yUp = cbx_yUp.Checked;

            string texturePrefix = "";
            if (cbx_prefixTexture.Checked) texturePrefix = objectNameClean + "_";

            //CREATE SYSTEM PATHS
            fullPathPython = programFilePath + "\\Data\\PythonCS.py";
            fullPathPythonOutput = programFilePath + "\\Data\\PythonOutput.txt";
            fullPathTexconv = programFilePath + "\\Data\\texconv.exe";
            fullPathSCOTemplate = programFilePath + "\\Data\\sco_template.txt";
            filePathTemp = filePathSource + "\\" + objectNameClean + "_Temp";
            //fullPathOutputDirectX = filePathOutputModel + "\\" + objectNameClean + ".x";
            fullPathTempDirectX = filePathTemp + "\\" + objectNameClean + ".x";
            fullPathTempO3D = filePathTemp + "\\" + objectNameClean + ".o3d";
            fullPathOutputO3D = filePathOutputModel + "\\" + objectNameClean + ".o3d";
            fullPathOutputSCO = filePathOutput + "\\" + objectNameClean + ".sco";

            DialogResult result;

            string fileType = Path.GetExtension(fullPathSource).ToLower();

            //CONFIRM ACTION WITH USER
            result = MessageBox.Show("You are about to create:\n" + fullPathOutputSCO + "\nProceed?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                btn_convert.Enabled = true;
                return;
            }

            // if output object exists
            //    ask user if they want to overwrite, add new files, or cancel
            if (File.Exists(fullPathOutputSCO))
            {
                existsBehaviour = 0;
                ConfirmOverwrite confirmOverwrite = new ConfirmOverwrite(this);
                DialogResult dialogResult = confirmOverwrite.ShowDialog();

                if(dialogResult == DialogResult.Cancel)
                {
                    btn_convert.Enabled = true;
                    return;
                }
            }

            //CREATE OUTPUT FOLDERS
            CreateFolder(filePathTemp);
            CreateFolder(filePathOutput);
            CreateFolder(filePathOutputModel);
            CreateFolder(filePathOutputTexture);

            //CREATE PYTHON SCRIPT
            MakePythonScript(yUp, fileType);

            //CHECK DAE FILE FOR MISSING TEXTURES
            if (fileType == ".dae")
            {
                int missingTextureCount = CheckDAEForMissingTextures(fullPathSource);
                if (missingTextureCount > 0)
                {
                    string plural = " is";
                    if (missingTextureCount > 1) { plural = "s are"; }
                    result = MessageBox.Show(missingTextureCount + " texture file" + plural + " not in the expected location!\nProceed?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        btn_convert.Enabled = true;
                        return;
                    }
                }
            }

            //CONVERT TO X (BLENDER)
            Process blender = new Process();
            blender.StartInfo.FileName = fullPathBlender;
            blender.StartInfo.Arguments = "-b -P \"" + fullPathPython + "\" --factory--startup";
            blender.Start();
            Console.Read();
            blender.WaitForExit();
            blender.Dispose();

            //CHECK SIZE OF X FILE AND WARN USER IF TOO LARGE
            long xFileBytes = new FileInfo(fullPathTempDirectX).Length;
            if (xFileBytes > MAX_X_SIZE_BYTES)
            {
                result = MessageBox.Show("X file size is " + xFileBytes / 1000 + "kB.\r\nFiles larger than " + MAX_X_SIZE_BYTES / 1000 + "kB may cause the .o3d converter to fail.\r\n\r\nModels with complex geometry may be inappropriate for OMSI, or may need to be broken into smaller pieces and imported manually.\r\n\r\nProceed anyway?", "X File Too Large", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                {
                    btn_convert.Enabled = true;
                    return;
                }
            }

            //RESIZE AND CONVERT ALL TEXTURES
            List<string> transparentTextureList = ResizeConvertMoveTexturesAndReturnListOfTransparent(texturePrefix);

            //SEARCH FOR AND REPLACE BAD SPECULAR VALUES IN X FILE
            //TODO: Provide user with options for what to amend?
            string directX;
            try
            {
                directX = File.ReadAllText(fullPathTempDirectX);
            }
            catch
            {
                MessageBox.Show("Could not find .x file. Check you have enabled the Blender .X exporter.");
                return;
            }

            string badDiff = "0.640000; 0.640000; 0.640000; 1.000000;;";
            string goodDiff = "1.000000; 1.000000; 1.000000; 1.000000;;";
            directX = directX.Replace(badDiff, goodDiff);
            string badPower = "96.078431;";
            string goodPower = "0.0000000;";
            directX = directX.Replace(badPower, goodPower);
            string badSpec = "0.500000; 0.500000; 0.500000;;";
            string goodSpec = "0.000000; 0.000000; 0.000000;;";
            directX = directX.Replace(badSpec, goodSpec);
            string badMatStart = "TextureFilename {\"";
            string goodMatStart = badMatStart + texturePrefix;
            directX = directX.Replace(badMatStart, goodMatStart);
            string badJPG = ".jpg";
            string badJPEG = ".jpeg";
            string badPNG = ".png";
            string goodDDS = ".dds";
            directX = directX.Replace(badJPG, goodDDS);
            directX = directX.Replace(badJPEG, goodDDS);
            directX = directX.Replace(badPNG, goodDDS);
            File.WriteAllText(fullPathTempDirectX, directX);

            //CONVERT FROM X TO O3D (OMSIXCONV)
            try
            {
                Process xconv = new Process();
                xconv.StartInfo.FileName = fullPathXconv;
                xconv.StartInfo.Arguments = "\"" + fullPathTempDirectX + "\"";
                xconv.Start();
                xconv.WaitForExit();
                xconv.Dispose();
                Movefile(fullPathTempO3D, fullPathOutputO3D);
            }
            catch
            {
                MessageBox.Show("Could not create .o3d file. Check that the OMSI X Converter is installed correctly with all DLL files in the same folder as the executable.");
                return;
            }
            //TODO: Work out how to check for errors

            //GENERATE SCO FILE FROM TEMPLATE
            if(existsBehaviour == 0) GenerateSCO(transparentTextureList, convertTransparent);

            //CLEAN UP
            //File.Delete(fullPathTempDirectX);
            //DeleteFolder(filePathTemp);

            //INFORM USER OF SUCCESS
            MessageBox.Show("Complete!");

            btn_convert.Enabled = true;
        }

        private List<string> ResizeConvertMoveTexturesAndReturnListOfTransparent(string texturePrefix)
        {

            //Make list of textures in file
            //ArrayList textureList = GetArrayListOfTextures(fullPathSource);
            //List<string> textureList = GetListOfTexturesWithPaths(fullPathSource);
            List<string> textureList = GetListOfTexturePathsFromPythonOutputFile();
            List<string> transparentTextureList = new List<string>();

            //TODO: Find all instances of transparent texture use
            //Count instances of use in .X file

            //TODO: Try to eliminate duplicates
            //Create new temp file for modified version
            //Forget about identifying what a duplicate is for now
            //Once a duplicate has been selected:
            //  -   Replace all IDs of texture to be replaced
            //  -   Delete texture definition
            //Provide user option to retain temp file after conversion

            string args;
            Process texconv = new Process();
            texconv.StartInfo.FileName = fullPathTexconv;
            foreach (string texture in textureList)
            {
                string textureName = texture.Replace("//", "\\");
                string convertedTextureName = Path.GetFileNameWithoutExtension(texture) + ".dds";
                string destinationTextureName = texturePrefix + convertedTextureName;
                //textureFormatted = texture.Replace("/", "\\");
                if (Path.GetExtension(texture).ToLower() != ".dds")
                {
                    string extension = Path.GetExtension(texture);
                    //if (extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
                    if (CheckExtension(extension, new[] { ".jpg", ".jpeg", ".bmp" }))
                    {
                        //Non-transparent (DXT1)
                        args = "-y -pow2 -f DXT1 -if CUBIC \"" + textureName + "\"" + " -o \"" + filePathTemp + "\"";
                        texconv.StartInfo.Arguments = args;
                        texconv.Start();
                        texconv.WaitForExit();
                    }
                    //else if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                    else if (CheckExtension(extension, new[] { ".png", ".tga", ".tiff" }))
                    {
                        //Transparent (DXT5)
                        args = "-y -pow2 -f DXT5 -if CUBIC \"" + textureName + "\"" + " -o \"" + filePathTemp + "\"";
                        texconv.StartInfo.Arguments = args;
                        texconv.Start();
                        texconv.WaitForExit();
                        transparentTextureList.Add(convertedTextureName);
                    }
                    else
                    {
                        MessageBox.Show("Unrecognised file extension " + extension);
                        throw new Exception("Unrecognised file extension " + extension);
                        //TODO: Handle exception
                    }

                    //Move and rename
                    Movefile(filePathTemp + "\\" + convertedTextureName, filePathOutputTexture + "\\" + destinationTextureName);
                }
                else
                {
                    transparentTextureList.Add(textureName);

                    //Copy and rename
                    Copyfile(textureName, filePathOutputTexture + "\\" + destinationTextureName);
                }
            }
            texconv.Dispose();
            return transparentTextureList;
        }

        private int[] GetInstancesOfTextureUseFromList(List<string> textureList)
        {
            int[] instances = new int[textureList.Count];
            string[] directX = File.ReadAllLines(fullPathTempDirectX);
            for (int i = 0; i < instances.Length; i++)
            {
                string texture = textureList[i];
                foreach (string line in directX)
                {
                    if (line.Contains(texture))
                     {
                        instances[i]++;
                     }
                }
            }
            return instances;
        }

        private void GenerateSCO(List<string> transparentTextureList, Boolean convertTransparent)
        {
            string sco = File.ReadAllText(fullPathSCOTemplate);
            string scoDate = DateTimeOffset.Now.ToString("f");
            sco = sco.Replace("<DATE>", scoDate);
            sco = sco.Replace("<VERSION>", programVersion);
            sco = sco.Replace("<FRIENDLYNAME>", tbx_friendlyname.Text);
            string scoGroupsNo = objectGroupsNo.ToString();
            sco = sco.Replace("<GROUPNO>", scoGroupsNo);
            string scoGroups = "";
            if (objectGroupsNo != 0)
            {
                for (int n = 0; n < 4; n++)
                {
                    if (objectGroupsNo > n)
                    {
                        scoGroups = scoGroups + objectGroups[n + 1] + "\r\n";
                    }
                }
            }
            sco = sco.Replace("<GROUPS>", scoGroups);
            sco = sco.Replace("<MESHNAME>", objectNameClean);
            sco = sco.Replace("<FRIENDLYNAME>", objectNameDirty);
            string scoMaterials = "";
            if (transparentTextureList.Count > 0 && convertTransparent)
            {
                int[] transparentTextureInstances = GetInstancesOfTextureUseFromList(transparentTextureList);
                for (int i = 0; i < transparentTextureList.Count; i++)
                {
                    string texture = transparentTextureList[i];
                    int instances = transparentTextureInstances[i];
                    for (int j = 0; j < instances; j++)
                    {
                        scoMaterials += "[matl]" + "\r\n";
                        scoMaterials += texture + "\r\n";
                        scoMaterials += j + "\r\n";
                        scoMaterials += "[matl_alpha]" + "\r\n";
                        scoMaterials += "2" + "\r\n";
                        scoMaterials += "\r\n";
                    }
                }
            }
            sco = sco.Replace("<MATERIALS>", scoMaterials);
            File.WriteAllText(fullPathOutputSCO, sco);
        }

        private void Movefile(string inputFile, string outputFile)
        {
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            try
            {
                File.Move(inputFile, outputFile);
            }
            catch (FileNotFoundException)
            {
                //TODO: Message to user that file does not exist, clean up
            }
        }

        private void Copyfile(string inputFile, string outputFile)
        {
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            try
            {
                File.Copy(inputFile, outputFile);
            }
            catch (FileNotFoundException)
            {
                //TODO: Message to user that file does not exist, clean up
            }
        }

        private void CreateFolder(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void DeleteFolder(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
        }

        private void MakePythonScript(bool yUp, string extension)
        {
            List<string> pythonList = new List<string>();

            string upAxis;
            switch (yUp)
            {
                case true:
                    upAxis = "Y";
                    break;
                default:
                    upAxis = "Z";
                    break;
            }

            pythonList.Add("import bpy");

            // TODO: v2.8+ uses bpy.ops.preferences.addon_enable
            pythonList.Add("bpy.ops.wm.addon_enable(module = \"io_scene_x\")");

            switch (extension)
            {
                case ".dae":
                    pythonList.Add("bpy.ops.wm.collada_import(filepath=r\"" + fullPathSource + "\")");
                    break;
                case ".blend":
                    pythonList.Add("bpy.ops.wm.open_mainfile(filepath=r\"" + fullPathSource + "\")");
                    break;
            }

            //pythonList.Add("f = open(r\"C:\\Users\\chris\\Desktop\\test.txt\", \"w+\")");
            //pythonList.Add("f.write(\"This is some text\")");
            //pythonList.Add("f.close()");

            pythonList.Add("");
            //pythonList.Add("textures = []");
            //pythonList.Add("for ob in bpy.data.objects:");
            //pythonList.Add("\tif ob.type == \"MESH\":");
            //pythonList.Add("\t\tfor mat_slot in ob.material_slots:");
            //pythonList.Add("\t\t\tif mat_slot.material:");
            //pythonList.Add("\t\t\t\tfor tex_slot in mat_slot.material.texture_slots:");
            //pythonList.Add("\t\t\t\t\ttextures.append(tex_slot.texture)");

            pythonList.Add("list = []");
            pythonList.Add("for t in bpy.data.textures:");
            pythonList.Add("\tif hasattr(t, 'image'):");
            pythonList.Add("\t\tlist.append(bpy.path.abspath(t.image.filepath))");
            pythonList.Add("\t\tlist.append(\"\\n\")");

            pythonList.Add("");

            pythonList.Add("f = open(r\"" + fullPathPythonOutput + "\", \"w+\")");
            pythonList.Add("f.writelines(list)");
            pythonList.Add("f.close()");

            switch (extension)
            {
                case ".dae":
                    pythonList.Add("bpy.ops.export_scene.x(filepath=r\"" + fullPathTempDirectX + "\", SelectedOnly=True, CoordinateSystem='RIGHT_HANDED', UpAxis='" + upAxis + "')");
                    break;
                case ".blend":
                    pythonList.Add("bpy.ops.export_scene.x(filepath=r\"" + fullPathTempDirectX + "\", SelectedOnly=False, CoordinateSystem='RIGHT_HANDED', UpAxis='" + upAxis + "')");
                    break;
            }
            pythonList.Add("bpy.ops.wm.quit_blender()");

            //string pythonScriptLine1 = "import bpy";
            //string pythonScriptLine2 = "bpy.ops.wm.collada_import(filepath=r\"" + fullPathSource + "\")";
            //string pythonScriptLine3;
            //switch (yUp)
            //{
            //    case true:
            //        pythonScriptLine3 = "bpy.ops.export_scene.x(filepath=r\"" + fullPathTempDirectX + "\", SelectedOnly=False, CoordinateSystem='RIGHT_HANDED', UpAxis='Y')";
            //        break;
            //    default:
            //        pythonScriptLine3 = "bpy.ops.export_scene.x(filepath=r\"" + fullPathTempDirectX + "\", SelectedOnly=False, CoordinateSystem='RIGHT_HANDED', UpAxis='Z')";
            //        break;
            //}
            //string pythonScriptLine4 = "bpy.ops.wm.quit_blender()";
            //string[] pythonScript = { pythonScriptLine1, pythonScriptLine2, pythonScriptLine3, pythonScriptLine4 };

            string[] pythonScript = pythonList.ToArray();
            File.WriteAllLines(fullPathPython, pythonScript);

        }

        private static string CleanDirtyString(string dirty)
        {
            string scrubbed = Regex.Replace(dirty, "[^A-Za-z0-9_]", "_");
            return scrubbed.First().ToString().ToUpper() + scrubbed.Substring(1);
        }

        //private static ArrayList GetArrayListOfTextures(string file)
        //{
        //    ArrayList textureList = new ArrayList();
        //    string[] lines = File.ReadAllLines(file);

        //    //COLLADA files
        //    if (Path.GetExtension(file) == ".dae")
        //    {
        //        for (int i = 0; i < lines.Length - 1; i++)
        //        {
        //            string thisLine = lines[i];
        //            string nextLine = lines[i + 1];
        //            if (thisLine.Contains("<image id=") && nextLine.Contains("<init_from>"))
        //            {
        //                //Remove tags from line
        //                nextLine = nextLine.Replace("<init_from>", "");
        //                nextLine = nextLine.Replace("</init_from>", "");
        //                //Remove whitespace
        //                nextLine = nextLine.Trim();
        //                textureList.Add(Path.GetFileNameWithoutExtension(nextLine));
        //                //Don't need to bother reading the next two lines
        //                i += 2;
        //            }
        //        }
        //    }
        //    return textureList;
        //}

        //private static List<string> GetListOfTexturesWithPaths(string file)
        //{
        //    List<string> textureList = new List<string>();
        //    string[] lines = File.ReadAllLines(file);

        //    //COLLADA files
        //    if (Path.GetExtension(file) == ".dae")
        //    {
        //        for (int i = 0; i < lines.Length - 1; i++)
        //        {
        //            string thisLine = lines[i];
        //            string nextLine = lines[i + 1];
        //            if (thisLine.Contains("<image id=") && nextLine.Contains("<init_from>"))
        //            {
        //                //Remove tags from line
        //                nextLine = nextLine.Replace("<init_from>", "");
        //                nextLine = nextLine.Replace("</init_from>", "");
        //                //Remove whitespace
        //                nextLine = nextLine.Trim();
        //                textureList.Add(nextLine);
        //                //Don't need to bother reading the next two lines
        //                i += 2;
        //            }
        //        }
        //    }
        //    return textureList;
        //}

        private int CheckDAEForMissingTextures(string file)
        {
            List<string> missingTextureList = new List<string>();
            int missingTextureCount = 0;
            string[] lines = File.ReadAllLines(file);

            //COLLADA files
            if (Path.GetExtension(file) == ".dae")
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string thisLine = lines[i];
                    string nextLine = lines[i + 1];
                    if (thisLine.Contains("<image id=") && nextLine.Contains("<init_from>"))
                    {
                        //Remove tags from line
                        nextLine = nextLine.Replace("<init_from>", "");
                        nextLine = nextLine.Replace("</init_from>", "");
                        //Remove whitespace
                        nextLine = nextLine.Trim();
                        nextLine = nextLine.Replace("/", "\\");
                        string filePath = filePathSource + "\\" + nextLine;
                        if (!File.Exists(filePath))
                        {
                            missingTextureList.Add(filePath);
                            missingTextureCount++;
                        }

                        //Don't need to bother reading the next two lines
                        i += 2;
                    }
                }
            }
            return missingTextureCount;
        }

        private List<string> GetListOfTexturePathsFromPythonOutputFile()
        {
            return new List<string>(File.ReadAllLines(fullPathPythonOutput));
            // Read texture list file from Python? Or make Python do this for us?
            // Doing this ourselves means we can handle errors
            // Blender does the work of finding the full texture file paths
        }

        //TODO: Replace with function to update all UI elements
        private void CheckEnableConvertButton()
        {
            Boolean checkOMSI = !String.IsNullOrEmpty(fullPathOMSI) && File.Exists(fullPathOMSI);
            Boolean checkXconv = !String.IsNullOrEmpty(fullPathXconv) && File.Exists(fullPathXconv);
            Boolean checkBlender = !String.IsNullOrEmpty(fullPathBlender) && File.Exists(fullPathBlender);
            //TODO: Check if file is a .SKP
            //TODO: Check if file is a .BLEND

            Boolean checkSource = !String.IsNullOrEmpty(fullPathSource) && File.Exists(fullPathSource);
            //Boolean checkSourceTexture = !String.IsNullOrEmpty(filePathSourceTexture) && Directory.Exists(filePathSourceTexture);

            Boolean checkObjectNameClean = !String.IsNullOrEmpty(objectNameClean);

            Boolean checkOutput = !String.IsNullOrEmpty(filePathOutput);

            if (checkOMSI && checkXconv && checkBlender && checkSource && checkObjectNameClean && checkOutput)
            {
                btn_convert.Enabled = true;
            }
            else
            {
                btn_convert.Enabled = false;
            }
        }

        private void GetObjectNameFromFile()
        {
            switch (cbx_getFileNameFromFile.Checked)
            {
                case true:
                    tbx_fileName.Enabled = false;
                    objectNameDirty = Path.GetFileNameWithoutExtension(fullPathSource);
                    objectNameClean = CleanDirtyString(objectNameDirty);
                    tbx_fileName.Text = objectNameDirty;
                    lbl_fileName.Text = objectNameClean;
                    break;
                default:
                    tbx_fileName.Enabled = true;
                    break;
            }
        }

        private void GetFriendlynameFromFile()
        {
            switch (cbx_getFriendlynameFromFile.Checked)
            {
                case true:
                    tbx_friendlyname.Enabled = false;
                    tbx_friendlyname.Text = Path.GetFileNameWithoutExtension(fullPathSource);
                    break;
                default:
                    tbx_friendlyname.Enabled = true;
                    break;
            }
        }

        private bool CheckExtension(string extension, string[] extensionList)
        {
            foreach (string s in extensionList)
            {
                if (extension.Equals(s, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

    //UNUSED GUI METHODS

    private void Lbl_browseSketchUp_Click(object sender, EventArgs e)
        {
                }

        private void Ofd_browseSketchUp_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Lbl_browseXconv_Click(object sender, EventArgs e)
        {

        }

        private void Ofd_browseXconv_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Pic_browseSketchUp_Click(object sender, EventArgs e)
        {

        }

        private void Pic_browseBlender_Click(object sender, EventArgs e)
        {

        }

        private void Pic_browseXconv_Click(object sender, EventArgs e)
        {

        }

        private void Pic_browseOMSI_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_browseBlender_Click(object sender, EventArgs e)
        {

        }

        private void Ofd_browseBlender_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Lbl_browseOMSI_Click(object sender, EventArgs e)
        {

        }

        private void Ofd_browseOMSI_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_FileName_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Lbl_browseSource_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_browseTexture_Click(object sender, EventArgs e)
        {

        }

        private void Ofd_browseSource_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Ofd_browseTexture_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Fbd_browseTexture_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_browseOutput_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void tbx_friendlyname_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbx_includeTransparency_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.includeTransparency = cbx_includeTransparency.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbx_prefixTexture_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.prefixTextureNames = cbx_prefixTexture.Checked;
            Properties.Settings.Default.Save();
        }

        //METHODS FOR OBJECT ALREADY EXISTING


    }
}
