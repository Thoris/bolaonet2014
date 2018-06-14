using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Model.Users
{
    [Serializable]
    public class UserBoloes : Framework.DataServices.Model.EntityBaseData
    {
        #region Variables
        private int _position;
        private Boloes.Bolao _bolao = new BolaoNet.Model.Boloes.Bolao();
        private int _membros;
        private int _apostasRestantes;
        #endregion

        #region Properties
        public Campeonatos.Campeonato Campeonato
        {
            get { return _bolao.Campeonato; }
        }
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Boloes.Bolao Bolao
        {
            get { return _bolao; }
            set { _bolao = value; }
        }
        public int Membros
        {
            get { return _membros; }
            set { _membros = value; }
        }
        public string Cobertura
        {
            get { return _bolao.Campeonato.Nome; }
        }
        public int ApostasRestantes
        {
            get { return _apostasRestantes; }
            set { _apostasRestantes = value; }
        }
        #endregion

        #region Constructors/Destructors
        public UserBoloes()
        {
        }
        public UserBoloes(int position, Boloes.Bolao bolao, int membros)
        {
            _position = position;
            _bolao = bolao;
            _membros = membros;
        }
        #endregion


    }
}
