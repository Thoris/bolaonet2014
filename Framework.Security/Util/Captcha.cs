using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Framework.Security.Util
{
    public class Captcha : Object, IDisposable
    {
        #region Constantes

        private readonly string[] CaracteresPermitidos = new string[] 
            {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Z", "W", "Y", 
             //"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "z", "w", "y", 
             "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        #endregion

        #region Variáveis
        private Bitmap _image;
        private string _text;
        private int _width;
        private int _height;
        private Random _random = new Random();
        private string _familyName;
        #endregion

        #region Propriedades
        public Bitmap Image
        {
            get { return _image; }
        }
        public string Text
        {
            get { return _text; }
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }
        #endregion

        #region Construtores/Destrutores
        public Captcha(string text, int width, int height)
        {
            this._text = text;
            this.SetDimensions(width, height);
            this.GeraImagem();
        }
        public Captcha(string text, int width, int height, string familyName)
        {
            this._text = text;
            this.SetDimensions(width, height);
            this.SetFamilyName(familyName);
            this.GeraImagem();
        }
        #endregion

        #region Métodos
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._image.Dispose();
            }
        }
        private void SetDimensions(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", width,
                    "Argument out of range, must be greater than zero.");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", height,
                    "Argument out of range, must be greater than zero.");
            }

            this._height = height;
            this._width = width;
        }
        private void SetFamilyName(string familyName)
        {
            try
            {
                Font font = new Font(familyName, 12.0F);
                this._familyName = familyName;
                font.Dispose();
            }
            catch
            {
                this._familyName = System.Drawing.FontFamily.GenericSerif.Name;
            }
        }
        private void GeraImagem()
        {
            Bitmap bitmap = new Bitmap(this._width, this._height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmap);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this._width, this._height);

            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);

            g.FillRectangle(hatchBrush, rect);

            SizeF size;
            Single fontSize = rect.Height + 1;
            Font font;
            do
            {
                fontSize -= 1;

                font = new Font(this._familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(this._text, font);
            }
            while (size.Width > rect.Width);


            // Set up the text format. 
            StringFormat format = new StringFormat();

            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            // Create a path using the text and warp it randomly. 

            GraphicsPath path = new GraphicsPath();
            path.AddString(this._text, font.FontFamily, (int)font.Style, font.Size, rect, format);

            Single v = 4.0F;



            PointF[] points = {new PointF (this._random.Next (rect.Width)/v, this._random.Next(rect.Height) / v),
                             new PointF (rect.Width - this._random.Next(rect.Width) / v, this._random.Next(rect.Height) / v), 
                             new PointF (this._random.Next (rect.Width) / v, rect.Height - this._random.Next (rect.Height) / v),
                             new PointF(rect.Width - this._random.Next (rect.Width) / v, rect.Height - this._random.Next ((int)(rect.Height / v)))};

            Matrix matrix = new Matrix();
            matrix.Translate(0.0F, 0.0F);

            path.Warp(points, rect, matrix, WarpMode.Perspective, 0.0F);



            // Draw the text. 
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
            g.FillPath(hatchBrush, path);



            // Add some random noise. 

            int m = Math.Max(rect.Width, rect.Height);

            for (int i = 0; i < (int)(rect.Width * rect.Height / 30.0F) - 1; i++)
            {
                int x = this._random.Next(rect.Width);
                int y = this._random.Next(rect.Height);
                int w = this._random.Next(m / 50);
                int h = this._random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }





            // Clean up. 

            font.Dispose();

            hatchBrush.Dispose();

            g.Dispose();

            // Set the image. 

            this._image = bitmap;


        }

        public static string GeraCodigoAleatorio()
        {
            Random random = new Random();

            //Retorna uma string de sete digitos aleatorios
            string s = "";

            for (int c = 0; c < 6; c++)
            {
                s = string.Concat(s, random.Next(10).ToString());
            }

            return s;

        }

        public string GerarStringRandomica(int qtdCaracteres)
        {
            // Cria Objetos
            Random oRandomEngine;
            string randomicString = string.Empty;

            // Inicializa a Engine
            oRandomEngine = new Random((((DateTime.Now.Second + CaracteresPermitidos.Length) * DateTime.Now.Hour * DateTime.Now.Millisecond) -
            DateTime.Now.DayOfYear) + DateTime.Now.Millisecond + DateTime.Now.Second);

            // Gera a String Randomica
            for (int countTMP = 0; countTMP < qtdCaracteres; countTMP++)
            {
                randomicString += CaracteresPermitidos[oRandomEngine.Next(0, CaracteresPermitidos.Length)];
            }

            // Retorna
            return randomicString;
        }

        #endregion
    }
}
