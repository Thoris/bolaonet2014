using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Boloes
{
    [Serializable]
    public class BolaoCriterioPontos : Framework.DataServices.Model.EntityBaseData
    {
        #region Enumerations
        public enum CriteriosID
        {
            Undefined = 0,
            Empate = 1,
            Vitoria = 2,
            Derrota = 3,
            Ganhador = 4, 
            Perdedor =5,
            Time1 = 6,
            Time2 = 7,
            VitoriaDerrotaEmpate = 8,
            Erro = 9,
            GanhadorFora = 10,
            GanhadorDentro = 11,
            PerdedorFora = 12,
            PerdedorDentro = 13,
            EmpateGols = 14,
            GolsTime1 = 15,
            GolsTime2 = 16,
            Cheio = 17,
        }
        #endregion

        #region Variables   
        private Bolao _bolao = new Bolao();
        private CriteriosID _criterioID = CriteriosID.Undefined;
        private int _pontos;
        private string _descricao;
        private Model.DadosBasicos.Time _time = new Model.DadosBasicos.Time();
        private int _multiploTime = 1;
        #endregion

        #region Properties
        public Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public CriteriosID CriterioID
        {
            get { return _criterioID; }
            set { _criterioID= value; }
        }
        public int Pontos
        {
            get { return _pontos; }
            set { _pontos = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao= value; }
        }
        public Model.DadosBasicos.Time Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public int MultiploTime
        {
            get { return _multiploTime; }
            set { _multiploTime = value; }
        }
        #endregion

        #region Constructors/Destructors
        public BolaoCriterioPontos()
        {

        }
        public BolaoCriterioPontos(string nomeBolao, CriteriosID criterioID)
        {
            _bolao = new Bolao(nomeBolao);
            _criterioID = criterioID;
        }
        #endregion

        #region Methods
        public void Copy(BolaoCriterioPontos entry)
        {
            _bolao = entry._bolao;
            _criterioID = entry._criterioID;
            _descricao = entry._descricao;
            _pontos = entry._pontos;
            _multiploTime = entry._multiploTime;
            _time = entry._time;


            base.Copy(entry);
        }
        #endregion
    }
}
