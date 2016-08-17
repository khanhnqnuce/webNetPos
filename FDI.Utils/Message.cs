using System;

namespace FDI.Utils
{
    [Serializable]
    public class JsonMessage
    {
        #region các biến
        private bool _erros;
        private string _message;
        private string _id;
        private int _type;
        #endregion

        #region Thuộc tính
        public bool Erros
        {
            get { return _erros; }
            set { _erros = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion

        #region Constructer
        public JsonMessage()
        {
            _erros = false;
            _message = string.Empty;
            _id = string.Empty;
            _type = 0;
        }

        public JsonMessage(bool erros, string message)
        {
            _erros = erros;
            _message = message;
        }
        #endregion

    }
}
