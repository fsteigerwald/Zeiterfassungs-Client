using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CustomExtensions
{
    class Logging
    {
        //
        // Default Ort und Name des Logfiles
        private string sFileNameOfLogfile = "LogFile.Log";                  // Default-Name des Logfiles: ClientUpdate.Log
        private string sPathOfLogfile = "%TEMP%";                           // Default-Pfad zum Logfile: Tempordner, alternativ: @"c:\current"
        private const string CASOLD = "AsOld";                              // Umbenennung von *.Log nach *.Old gewünscht
        private const string CASDATETIMEOLD = "AsDateTimeOld";              // Umbenennung von *.Log nach *_20190631_183558.Old
        //
        // Gestaltung des Logfiles 
        private string sIndentLetter = "";                                  // Ein String aufgefüllt mit Einrückungszeiben: '   '
        private int nIdentLetterCount = 0;                                  // Anzahl der einzurückenden Zeichen am Zeilenanfang
        private bool bDoNotWriteToLog = false;                              // true unterbricht das Logging bis diese Variable False wird
        private bool bAddTimeToLine = false;                                // true schreibt in jede Zeile die aktuelle Zeit
        //
        // Mitzählen der Fehlerhinweise in der Logzeile
        private int nErrorCount = 0;                                        // Anzahl der gefundenen Fehler 'ERROR:' im Logfile
        private const string CERROR = "ERROR: ";                             // Text in Logzeile, der auf einen Fehler hinweist
        //
        // Infotexte des Exception Fensters
        private string sCaptionFile = "Fehler beim Dateizugriff";           // Caption des Exception-Infofensters
        private string sCaptionPath = "Fehler beim Verzeichniszugriff";     // Caption der Exception

        /* Gestaltungsfunktionen für das Logfile   
        // #######################################################################################################################
        // ###                              Funktionen zur Gestaltung des Logfiles.                                            ###
        // #######################################################################################################################
        /*
         * Die folgenden Funktionen dienen dazu die Lage und den Namen des Logfiles zu setzen oder zu ändern.
        */
        public int nGetErrorCount()
        {
            // Liefert Anzahl der gefundenen Strings CERROR, also die Anzahl der Fehlerhinweise im Log
            return nErrorCount;
        }   
        //
        public void RenameLogfile(string sAsRenameType)
        {
            // Nennt das Logfile um. 'sAsRenameType' kann sein: CASOLD oder CASDATETIMEOLD
            string sOrg = sPathOfLogfile + "\\" + sFileNameOfLogfile;
            sOrg = Environment.ExpandEnvironmentVariables(sOrg);
            string sCopy = "";
            //
            int n = sOrg.LastIndexOf(".");
            if (n > 0)
            {
                switch (sAsRenameType)
                {
                    case CASOLD:
                        // Kopie von '%temp%\LogFile.Log' nach '%temp%\LogFile.Old'  
                        sCopy = sOrg.Substring(0, n) + ".Old";
                        break;
                    default:
                        // Kopie von '%temp%\LogFile.Log' nach '%temp%\LogFile_20190631_183558.Old'  
                        DateTime DateTime = DateTime.Today;
                        string sDateTime = DateTime.ToString("g");   // liefert z.B. 11/25/2019 12:00 AM
                        // Konvertierung: '11/25/2019 12:00 AM' nach '20191125_120000'





                        break;
                }
                File.Copy(sOrg, sCopy);
            }
        }
        public void SetIdentLetterType(char c)
        {
            sIndentLetter = c.ToString();
        }
        public void Indent()
        {
            nIdentLetterCount++;
        }
        public void DeIndent()
        {
            if (nIdentLetterCount > 0)
            {
                nIdentLetterCount--;
            }
        }
        public void l(string sLine)
        {
            // Überarbeitet die Logzeile 'sLine' und schreibt die Zeile ins Log
            // a)   Original: text                                  // Kein Semikolon an Position 9
            //      Wird zu:  <auffüllzeichen>text
            // b)   Original: MAIN0100;text                         // Das Semikolon muss zwingend an der Position 9 stehen 
            //      Wird zu:  <auffüllzeichen>(#MAIN0100)text
            // 
            // * Die Funktion zält mit, wenn das Wort 'ERROR:' in der Zeile enthalten ist. Damit kann die Anzahl von Fehlern im Log
            // ermittelt werden.
            // * Wenn 'bbDoNotWriteToLog' auf TRUE, wird das Logging temporär angehalten
            // * Wenn 'bAddTimeToLine' auf TRUE, wird die aktuelle Zeit in jede Zeile des Logs geschrieben um Laufzeiten kontrollieren zu konnen
            string s = "";                  // Ergebnisstring für Logfile

            // Gibt es am Zeilenanfang einen Identifier (Länge exakt 8 Zeichen, getrennt vom Text durch ';')
            if (sLine.IndexOf(";") == 9)
            {
                // Text mit Identifier 'MAIN0100' also z.B. '(#MAIN0100) Dienst wurde erfolgreich gestartet'
                s = "(#" + sLine.Substring(0,8) + ") " + sLine.Substring(10);
            }
            else
            {
                // Reiner Text ohne Identifier 'MAIN0100' also z.B. 'Dienst wurde erfolgreich gestartet'
                s = sLine;
            }

            // Gibt es einen Fehlerhinweis in der Zeile? Suchen nach 'ERROR:'
            if (sLine.IndexOf(CERROR) > 0)
            {
                nErrorCount++;
            }

            bWriteLogLineToFile(s);
        }
        public void DoNotWriteToLog()
        {
            // Ein grade laufender Loggingprozess wird temporär angehalten
            bDoNotWriteToLog = false;
        }
        public void ResumeWriteToLog()
        {
            // Ein temporär angehaltener Loggingprozess wird wieder aufgenommen
            bDoNotWriteToLog = true;
        }
        public void AddTimeToLogLine()
        {
            // Ergänzt jede Logzeile um die aktuelle Systemzeit. Dient der Ermittlung von Laufzeiten
            bAddTimeToLine = true;
        }
        public void StopAddingTimmeToLogLine()
        {
            // Beendet das Logging von Systemzeiten in der Logzeile
            bAddTimeToLine = false;
        }
        /* Namenänderung, Ortsänderung, löschen, umbenennen   
        // #######################################################################################################################
        // ###      Funktionen zur Änderung des Namens und des Ortes des Logfiles. Löschen und umbenennen des Logfiles         ###
        // #######################################################################################################################
        /*
         * Die folgenden Funktionen dienen dazu die Lage und den Namen des Logfiles zu setzen oder zu ändern.
        */
        public void SetNewPathNameForLogFile(string sPath)
        {
            // Ändert die Pfadvariable
            sPathOfLogfile = sPath;
        }
        public void SetNewFileNameForLogFile(string sFileName)
        {
            // Dem Logfile einen anderen Namen geben. Es wird das Logging unter diesem Naamen fortgesetzt
            sFileNameOfLogfile = sFileName;
        }
        public bool bDeleteLogFile()
        {
            // Löscht ein existierenden Logfile
            string s = sPathOfLogfile + "\\" + sFileNameOfLogfile;
            s = Environment.ExpandEnvironmentVariables(s);

            try
            {
                if (File.Exists(s))
                {
                    File.Delete(s);
                }
                return true;
            }
            catch (Exception ex)
            {
                // https://docs.microsoft.com/de-de/dotnet/api/system.windows.messagebox.show?view=netframework-4.8#System_Windows_MessageBox_Show_System_Windows_Window_System_String_
                MessageBox.Show(ex.Message, sCaptionFile);
                return false;
            }
        }
        public void RenameLogFile(string sFileName)
        {
            sFileNameOfLogfile = sFileName;
        }
        public void ReInitLogFile()
        {
            // Setzt die Defaultwerte für Pfad und Filename. Löscht ein evtl. unter diesem Namen existierendes File.
            sFileNameOfLogfile = "LogFile.Log";                  // Default-Name des Logfiles: ClientUpdate.Log
            sPathOfLogfile = "%TEMP%";
            nErrorCount = 0;                                     // Fehlerzähler zurücksetzen

            // bestehendes Logfile löschen
            bDeleteLogFile();
        }
        /* Lowlevel Filesystem
        // #######################################################################################################################
        // ###              Funktionen an der Schnittstelle zum Filesystem, ausschlielich private Funktionen                   ###
        // #######################################################################################################################
        //
        //    * Die folgenden drei Funktionen sind Hilfsfunktionen um letztendlich die Log-Zeile sicher ins Log zu Bekommen.
        //    * Es wird geprüft, ob das weiter oben gewählte Verzeichnis existiert und Zuganglich ist. Weiterhin wird 
        //    * ein eventuell nicht existentes Logfile angelegt. 
        //    * Die Logzeile wird der Funktion 'bWriteLogLineToFile' übergeben, die obige Funktionen bereit stellt.
        */
        private bool bWriteLogLineToFile(string sLine)      
        { 
            // Schreibt eine Textzeile in das Logfile
            // Ist das Logfile nicht vorhanden, so wird es angelegt.
            // Der Name und Ort des Logfiles wird aus der Path-Variable und der Dateivariable abgeleitet.
            
            if (bTestAndOrCreateFolderForLogfileWriting())
            {
                string s = sPathOfLogfile + "\\" + sFileNameOfLogfile;
                s = Environment.ExpandEnvironmentVariables(s);
                try
                {
                    if (File.Exists(s))
                    {
                        using (StreamWriter sw = File.AppendText(s))                        // Text zum anhängen öffnen
                        {
                            sw.WriteLine(sLine);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(s))                        // Datei anlegen, dann schreiben
                        {
                            sw.WriteLine(sLine);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // https://docs.microsoft.com/de-de/dotnet/api/system.windows.messagebox.show?view=netframework-4.8#System_Windows_MessageBox_Show_System_Windows_Window_System_String_
                    MessageBox.Show(ex.Message, sCaptionFile);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }           
        private bool bTestAndOrCreateFolderForLogfileWriting()
        {
            // Stellt sicher, dass der geünschte Pfad angelegt und beschreibbar ist

            string s = Environment.ExpandEnvironmentVariables(sPathOfLogfile);          // s emthält keine Environmentvariablen mehr

            try
            {
                // Gibt es das Verzeichnis schon
                if (Directory.Exists(s))
                {
                    // Teste einen schreibenden Zugriff
                    return bWriteTextFileInExistingFolder();
                }
                else
                {
                    // Das Verzeichnis anlegen und Zugriff testen

                    try
                    {
                        // Directory anlegen
                        DirectoryInfo di = Directory.CreateDirectory(s);
                        // Teste einen schreibenden Zugriff
                        return bWriteTextFileInExistingFolder();
                    }
                    catch (Exception e)
                    {
                        // https://docs.microsoft.com/de-de/dotnet/api/system.windows.messagebox.show?view=netframework-4.8#System_Windows_MessageBox_Show_System_Windows_Window_System_String_
                        MessageBox.Show(e.Message, sCaptionPath);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // https://docs.microsoft.com/de-de/dotnet/api/system.windows.messagebox.show?view=netframework-4.8#System_Windows_MessageBox_Show_System_Windows_Window_System_String_
                MessageBox.Show(ex.Message, sCaptionPath);
                return false;
            }
        }
        private bool bWriteTextFileInExistingFolder()
        {
            // Das Verzeichnis muss existrieren. Die Funktion testet, ob ein schreibender Zugriff dort hin möglich ist

            string s = sPathOfLogfile + "\\TestFileUmDenSchreibendenZugriffInsVerzeichnisZuTesten.Txt";
            s = Environment.ExpandEnvironmentVariables(s);

            try
            {
                using (StreamWriter sw = File.CreateText(s))                        // Datei anlegen, dann schreiben
                sw.WriteLine("TestZeile");

                using (StreamReader sr = new StreamReader(s))                        // Datei lesen
                {
                    string line = sr.ReadLine();
                    sr.Close();
                    sr.Dispose();
                    if (line == "TestZeile")
                    {
                        // Testfile wieder löschen
                        File.Delete(s);
                        return true;
                    }
                    else
                    {
                        File.Delete(s);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // https://docs.microsoft.com/de-de/dotnet/api/system.windows.messagebox.show?view=netframework-4.8#System_Windows_MessageBox_Show_System_Windows_Window_System_String_
                MessageBox.Show(ex.Message, sCaptionFile);
                return false;
            }
        }
    }
}
