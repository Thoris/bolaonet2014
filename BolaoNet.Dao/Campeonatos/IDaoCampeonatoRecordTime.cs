using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Dao.Campeonatos
{

    public enum RecordTipoPesquisa
    {
        QtdJogosSemGanhar = 1,
        QtdJogosSemPerder = 2,
        SequenciaDerrotas = 3,
        SequenciaEmpates =4,
        SequenciaVitorias=5,
        RecordQtdJogosSemGanhar=6,
        RecordQtdJogosSemPerder=7,
        RecordSeqDerrotas=8,
        RecordSeqEmpates=9,
        RecordSeqVitorias=10,
    }


    public interface IDaoCampeonatoRecordTime
    {
        bool LoadRecordPlacar(string currentUser, Model.Campeonatos.Campeonato entry, RecordTipoPesquisa tipo,out IList<Model.Campeonatos.CampeonatoRecord> general,out IList<Model.Campeonatos.CampeonatoRecord> dentro,out IList<Model.Campeonatos.CampeonatoRecord> fora, out int errorNumber, out string errorDescription);


        //bool LoadRecordByTime(string currentUser, Model.Campeonatos.Campeonato entry, Model.DadosBasicos.Time time, RecordTipoPesquisa tipo, out Model.Campeonatos.CampeonatoRecord general, out Model.Campeonatos.CampeonatoRecord dentro, out Model.Campeonatos.CampeonatoRecord fora, out int errorNumber, out string errorDescription);

        bool LoadRecordJogosGols(string currentUser, Model.Campeonatos.Campeonato entry, Model.DadosBasicos.Time time, bool getRecord, out Model.Campeonatos.CampeonatoRecord general, out Model.Campeonatos.CampeonatoRecord dentro, out Model.Campeonatos.CampeonatoRecord fora, out int errorNumber, out string errorDescription);
        


    }
}
