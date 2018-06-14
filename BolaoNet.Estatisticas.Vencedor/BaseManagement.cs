using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Estatisticas.Vencedor
{
    /// <summary>
    /// Class which contains data base of files management
    /// </summary>
    public class BaseManagement
    {
        #region Variables
        /// <summary>
        /// Path which the file is stored
        /// </summary>
        private string _path;
        /// <summary>
        /// File Name
        /// </summary>
        private string _fileName;
        #endregion

        #region Propriedades
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        /// <summary>
        /// Gets the full name of the file.
        /// </summary>
        /// <value>The full name of the file.</value>
        public string FullFileName
        {
            get { return System.IO.Path.Combine(_path, _fileName); }
        }
        #endregion

        #region Constructors/Destructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManagement"/> class.
        /// </summary>
        public BaseManagement()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManagement"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="file">The file.</param>
        public BaseManagement(string path, string file)
        {
            _path = path;
            _fileName = file;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the file is valid.
        /// </summary>
        protected void IsFileValid()
        {
            if (!System.IO.File.Exists(FullFileName))
                throw new Exception("The file " + FullFileName + " doesn't exists. Please check it out!");
                //throw new Exception(string.Format(Resources.Export.FileDoesntExists, FullFileName));
        }
        #endregion
    }
}
