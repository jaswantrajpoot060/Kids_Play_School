using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace BuisnessManager
{
    public class TemplateEngine
    {
        #region Variables
        private string filename;
        private string template_dir;
        private char left_delimiter;
        private char right_delimiter;
        private Hashtable variables;
        #endregion

        #region Properties
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }

        }
        public char LDelimiter
        {
            get { return left_delimiter; }
            set { left_delimiter = value; }
        }
        public char RDelimiter
        {
            get { return right_delimiter; }
            set { right_delimiter = value; }
        }
        public string TemplatesDir
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory + template_dir;
            }
            set
            {
                template_dir = value;
            }
        }
        public Hashtable Variables
        {
            set { variables = value; }
            get { return variables; }
        }
        #endregion

        #region Functions
        //    /// <summary>
        //    /// paramater constructor
        //    /// </summary>
        //    /// <param name="file"></param>
        public TemplateEngine()
        {
            //
            // TODO: Add constructor logic here
            //
            SetDefaultValues();
        }
        public TemplateEngine(string file)
        {
            SetDefaultValues();
            FileName = file;
        }
        /// <summary>
        /// set values to mail
        /// </summary>
        private void SetDefaultValues()
        {
            TemplatesDir = "Template\\";
            LDelimiter = '~';
            RDelimiter = '`';
            Variables = new Hashtable();
        }
        /// <summary>
        /// get Content
        /// </summary>
        /// <returns>return string value</returns>
        public string GetFileContent()
        {
            string temp_content = "";
            StreamReader sr = new StreamReader(TemplatesDir + FileName);
            try
            {
                temp_content = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sr.Close();
            }
            //temp_content = temp_content.Replace("~name`", "tushar");
            IDictionaryEnumerator e = Variables.GetEnumerator();
            while (e.MoveNext())
            {
                temp_content = temp_content.Replace(LDelimiter + e.Key.ToString() + RDelimiter, e.Value.ToString());
            }
            return temp_content;

            //return "tushar";
        }
        #endregion
    }
}