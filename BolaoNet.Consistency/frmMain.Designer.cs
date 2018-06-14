namespace BolaoNet.Consistency
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stbStatus = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboBoloes = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pgbPartial = new System.Windows.Forms.ProgressBar();
            this.livLog = new System.Windows.Forms.ListView();
            this.clmLogId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLogJogo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.livJogos = new System.Windows.Forms.ListView();
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTime1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGols1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGols2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTime2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPartidaValida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.livJogosUsuarios = new System.Windows.Forms.ListView();
            this.clmUserId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserTime1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserGols1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserGols2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserTime2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserPontos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblJogo = new System.Windows.Forms.Label();
            this.livClassificacao = new System.Windows.Forms.ListView();
            this.clmClassificacaoPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmClassificacaoUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmClassificacaoPontos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmClassificacaoDiff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmExpected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbStatus
            // 
            this.stbStatus.Location = new System.Drawing.Point(0, 414);
            this.stbStatus.Name = "stbStatus";
            this.stbStatus.Size = new System.Drawing.Size(1030, 22);
            this.stbStatus.TabIndex = 0;
            this.stbStatus.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboBoloes);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 38);
            this.panel1.TabIndex = 2;
            // 
            // cboBoloes
            // 
            this.cboBoloes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBoloes.FormattingEnabled = true;
            this.cboBoloes.Location = new System.Drawing.Point(765, 9);
            this.cboBoloes.Name = "cboBoloes";
            this.cboBoloes.Size = new System.Drawing.Size(176, 21);
            this.cboBoloes.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(947, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pgbPartial
            // 
            this.pgbPartial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbPartial.Location = new System.Drawing.Point(0, 404);
            this.pgbPartial.Name = "pgbPartial";
            this.pgbPartial.Size = new System.Drawing.Size(1030, 10);
            this.pgbPartial.TabIndex = 4;
            // 
            // livLog
            // 
            this.livLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmLogId,
            this.clmLogJogo,
            this.clmUsuario,
            this.clmAtual,
            this.clmExpected});
            this.livLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.livLog.FullRowSelect = true;
            this.livLog.Location = new System.Drawing.Point(0, 255);
            this.livLog.Name = "livLog";
            this.livLog.Size = new System.Drawing.Size(1030, 149);
            this.livLog.TabIndex = 5;
            this.livLog.UseCompatibleStateImageBehavior = false;
            this.livLog.View = System.Windows.Forms.View.Details;
            // 
            // clmLogId
            // 
            this.clmLogId.Text = "Id";
            // 
            // clmLogJogo
            // 
            this.clmLogJogo.Text = "Jogo";
            this.clmLogJogo.Width = 208;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.livClassificacao);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 214);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.livJogos);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.livJogosUsuarios);
            this.splitContainer2.Panel2.Controls.Add(this.lblJogo);
            this.splitContainer2.Size = new System.Drawing.Size(757, 214);
            this.splitContainer2.SplitterDistance = 383;
            this.splitContainer2.TabIndex = 0;
            // 
            // livJogos
            // 
            this.livJogos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmData,
            this.clmTime1,
            this.clmGols1,
            this.clmGols2,
            this.clmTime2,
            this.clmPartidaValida});
            this.livJogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livJogos.FullRowSelect = true;
            this.livJogos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.livJogos.Location = new System.Drawing.Point(0, 0);
            this.livJogos.Name = "livJogos";
            this.livJogos.Size = new System.Drawing.Size(383, 214);
            this.livJogos.TabIndex = 0;
            this.livJogos.UseCompatibleStateImageBehavior = false;
            this.livJogos.View = System.Windows.Forms.View.Details;
            this.livJogos.SelectedIndexChanged += new System.EventHandler(this.livJogos_SelectedIndexChanged);
            // 
            // clmId
            // 
            this.clmId.Text = "ID";
            // 
            // clmData
            // 
            this.clmData.Text = "Data";
            // 
            // clmTime1
            // 
            this.clmTime1.Text = "Time1";
            // 
            // clmGols1
            // 
            this.clmGols1.Text = "Gols1";
            // 
            // clmGols2
            // 
            this.clmGols2.Text = "Gols2";
            // 
            // clmTime2
            // 
            this.clmTime2.Text = "Time2";
            // 
            // clmPartidaValida
            // 
            this.clmPartidaValida.Text = "Válido";
            // 
            // livJogosUsuarios
            // 
            this.livJogosUsuarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmUserId,
            this.clmUserName,
            this.clmUserTime1,
            this.clmUserGols1,
            this.clmUserGols2,
            this.clmUserTime2,
            this.clmUserPontos});
            this.livJogosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livJogosUsuarios.FullRowSelect = true;
            this.livJogosUsuarios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.livJogosUsuarios.Location = new System.Drawing.Point(0, 19);
            this.livJogosUsuarios.Name = "livJogosUsuarios";
            this.livJogosUsuarios.Size = new System.Drawing.Size(370, 195);
            this.livJogosUsuarios.TabIndex = 1;
            this.livJogosUsuarios.UseCompatibleStateImageBehavior = false;
            this.livJogosUsuarios.View = System.Windows.Forms.View.Details;
            // 
            // clmUserId
            // 
            this.clmUserId.Text = "ID";
            // 
            // clmUserName
            // 
            this.clmUserName.Text = "Usuário";
            // 
            // clmUserTime1
            // 
            this.clmUserTime1.Text = "Time1";
            // 
            // clmUserGols1
            // 
            this.clmUserGols1.Text = "Gols1";
            // 
            // clmUserGols2
            // 
            this.clmUserGols2.Text = "Gols2";
            // 
            // clmUserTime2
            // 
            this.clmUserTime2.Text = "Time2";
            // 
            // clmUserPontos
            // 
            this.clmUserPontos.Text = "Pontos";
            // 
            // lblJogo
            // 
            this.lblJogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJogo.Location = new System.Drawing.Point(0, 0);
            this.lblJogo.Name = "lblJogo";
            this.lblJogo.Size = new System.Drawing.Size(370, 19);
            this.lblJogo.TabIndex = 2;
            this.lblJogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // livClassificacao
            // 
            this.livClassificacao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmClassificacaoPos,
            this.clmClassificacaoUser,
            this.clmClassificacaoPontos,
            this.clmClassificacaoDiff});
            this.livClassificacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livClassificacao.FullRowSelect = true;
            this.livClassificacao.Location = new System.Drawing.Point(0, 0);
            this.livClassificacao.Name = "livClassificacao";
            this.livClassificacao.Size = new System.Drawing.Size(269, 214);
            this.livClassificacao.TabIndex = 0;
            this.livClassificacao.UseCompatibleStateImageBehavior = false;
            this.livClassificacao.View = System.Windows.Forms.View.Details;
            // 
            // clmClassificacaoPos
            // 
            this.clmClassificacaoPos.Text = "Posição";
            // 
            // clmClassificacaoUser
            // 
            this.clmClassificacaoUser.Text = "Usuário";
            // 
            // clmClassificacaoPontos
            // 
            this.clmClassificacaoPontos.Text = "Pontos";
            // 
            // clmClassificacaoDiff
            // 
            this.clmClassificacaoDiff.Text = "Diferença";
            // 
            // clmUsuario
            // 
            this.clmUsuario.Text = "Usuário";
            // 
            // clmAtual
            // 
            this.clmAtual.Text = "Atual";
            // 
            // clmExpected
            // 
            this.clmExpected.Text = "Esperado";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 252);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1030, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 436);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.livLog);
            this.Controls.Add(this.pgbPartial);
            this.Controls.Add(this.stbStatus);
            this.Name = "frmMain";
            this.Text = "Bolão";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stbStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pgbPartial;
        private System.Windows.Forms.ListView livLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView livJogos;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmTime1;
        private System.Windows.Forms.ColumnHeader clmGols1;
        private System.Windows.Forms.ColumnHeader clmGols2;
        private System.Windows.Forms.ColumnHeader clmTime2;
        private System.Windows.Forms.ColumnHeader clmPartidaValida;
        private System.Windows.Forms.ComboBox cboBoloes;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView livJogosUsuarios;
        private System.Windows.Forms.ColumnHeader clmUserId;
        private System.Windows.Forms.ColumnHeader clmUserTime1;
        private System.Windows.Forms.ColumnHeader clmUserGols1;
        private System.Windows.Forms.ColumnHeader clmUserGols2;
        private System.Windows.Forms.ColumnHeader clmUserTime2;
        private System.Windows.Forms.ColumnHeader clmUserPontos;
        private System.Windows.Forms.Label lblJogo;
        private System.Windows.Forms.ColumnHeader clmUserName;
        private System.Windows.Forms.ColumnHeader clmData;
        private System.Windows.Forms.ColumnHeader clmLogId;
        private System.Windows.Forms.ColumnHeader clmLogJogo;
        private System.Windows.Forms.ListView livClassificacao;
        private System.Windows.Forms.ColumnHeader clmClassificacaoPos;
        private System.Windows.Forms.ColumnHeader clmClassificacaoUser;
        private System.Windows.Forms.ColumnHeader clmClassificacaoPontos;
        private System.Windows.Forms.ColumnHeader clmClassificacaoDiff;
        private System.Windows.Forms.ColumnHeader clmUsuario;
        private System.Windows.Forms.ColumnHeader clmAtual;
        private System.Windows.Forms.ColumnHeader clmExpected;
        private System.Windows.Forms.Splitter splitter1;

    }
}

