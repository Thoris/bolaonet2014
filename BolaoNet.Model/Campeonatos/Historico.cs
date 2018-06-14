using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Campeonatos
{
    [Serializable]
    public class Historico : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private string _nome;
        private int _ano;
        private DadosBasicos.Time _campeao;
        private DadosBasicos.Time _viceCampeao;
        private DadosBasicos.Time _terceiro;
        private int _finalTime1;
        private int _finalTime2;
        private int _penaltis1;
        private int _penaltis2;
        private string _sede;

        #endregion

        #region Properties
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }
        public DadosBasicos.Time NomeTimeCampeao
        {
            get { return _campeao; }
            set { _campeao = value; }
        }
        public DadosBasicos.Time NomeTimeVice
        {
            get { return _viceCampeao; }
            set { _viceCampeao = value; }
        }
        public DadosBasicos.Time NomeTimeTerceiro
        {
            get { return _terceiro; }
            set { _terceiro = value; }
        }
        public int FinalTime1
        {
            get { return _finalTime1; }
            set { _finalTime1 = value; }
        }
        public int FinalTime2
        {
            get { return _finalTime2; }
            set { _finalTime2 = value; }
        }
        public int FinalPenaltis1
        {
            get { return _penaltis1; }
            set { _penaltis1 = value; }
        }
        public int FinalPenaltis2
        {
            get { return _penaltis2; }
            set { _penaltis2 = value; }
        }
        public string Sede
        {
            get { return _sede; }
            set { _sede= value; }
        }

        #endregion

        #region Constructors/Destructors
        public Historico()
        {
        }
        public Historico(int ano, string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("nome");

            if (ano == 0)
                throw new ArgumentException("ano");

            _ano = ano;
            _nome = nome;

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_nome))
                return "";
            else
                return _nome;
        }

        public void Copy(Model.Campeonatos.Historico entry)
        {
            _campeao = entry._campeao;
            _finalTime1 = entry._finalTime1;
            _finalTime2 = entry._finalTime2;
            _nome = entry._nome;
            _penaltis1 = entry._penaltis1;
            _penaltis2 = entry._penaltis2;
            _sede = entry._sede;
            _terceiro = entry._terceiro;
            _viceCampeao = entry._viceCampeao;

        }
        #endregion
    }
}
