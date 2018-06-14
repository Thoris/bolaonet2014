<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="BolaoNet.WebSite.Ajuda.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenuLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceMainMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <p>
        <br />
        1) Acesse o site do bolão: 
        <br />
        <asp:Label ID="lblSite" runat="server" Text="bolaonet.somee.com"></asp:Label>
    </p>
    <p>
        2) Clique no link para registrar-se:
        <br />
        <asp:Image ID="imgTelaInicial" runat="server" ImageUrl="cadastro_telainicial.png" style="margin-left: 0px" Width="350px" />
    </p>
    <p>
        3) Preencha as informações requisitadas na página e clique em &quot;Salvar&quot;:
        <br />
        <asp:Image ID="imgRegistro" runat="server" ImageUrl="cadastro_registro.png" style="margin-left: 0px" Width="350px" />
        

        </p>
    <p>
        Se todas as informações estiverem corretas, você receberá um email com suas 
        informações de ativação, conforme abaixo:</p>
    <table style="width: 80%; font-family: 'Courier New', Courier, monospace; font-size: 12px; background-color: #EAEAEA;" 
        position="center" align="center">
        <tr>
            <td>
                <p>
                    Olá [%NOME%],</p>
                <p>
                    Obrigado por se cadastrar no Bolão Net.
                <br />
                <br />
                    Para ativar seu usuário, pode fazê-lo clicando no link abaixo:<br />
                    &nbsp;[%URLACTIVATION%]?Login=[%USER%]&Key=[%ACTIVATIONKEY%]
                <br />
                <br />
                    Ou, acesse o site [%URLACTIVATION%], e entre com : 
                <br />
                    Chave:
                    [%ACTIVATIONKEY%]
                <br />
                    Usuário: [%USER%]
                
                <br />
                <br />
                    Qualquer problema, entre em contato conosco.
                <br />
                <br />
                    Administrador do Bolão Net.</td>
        </tr>
    </table>
    <p>
        Agora, é necessário a realização da ativação do seu login. Você tem duas opções 
        para o fazer:</p>
    <p>
        a) Clique no link de ativação obtido no email recebido.</p>
    <p>
        b) Acesse a página de ativação, e entre com a chave de ativação e o login do 
        usuário, e clique em &quot;Confirmar&quot;<br>
        <asp:Label ID="lblPageConfirm" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="lblConfirm" runat="server" Text="Label"></asp:Label>
    <br>
        <asp:Image ID="Image1" runat="server" ImageUrl="cadastro_confirmacao.png" style="margin-left: 0px" Width="350px" />
    </p>
    <p>
        Caso as informações estejam corretas, você receberá um email de boas vindas 
        conforme a imagem abaixo:</p>

        <table style="width: 80%; font-family: 'Courier New', Courier, monospace; font-size: 12px; background-color: #EAEAEA;" 
        position="center" align="center">
        <tr>
            <td>
               

                <p>
                    Boas vindas ao BolãoNET

                <br />
                <br />
                    Por favor, guarde este email para posteriores consultas. A informação da sua 
                    conta é a seguinte:
                <br />
                    -------------------------------------
                <br />
                    Usuário: [%USER%]
                <br />
                    Senha: [%PASSWORD%]
                <br />
                    URL: [%URL%]
                <br />
                    -------------------------------------
                <br />
                    &nbsp;
                <br />
                    Por favor, não se esqueça que seua senha foi codificada em nosso banco de dados 
                    e não podemos recuperá-la para lhe fornecer caso à peça. No entanto, caso você 
                    esqueça-a, você poderá solicitar uma nova, sendo ativada da mesma forma desta 
                    conta.
                <br />
                    &nbsp;
                <br />
                    Obrigado por registrar-se.
                <br />
                    [%SIGNATURE%]
                <br />

            </td>
        </tr>
    </table>
    <p>
        Pronto, agora o seu login está habilitado para acessar o sistema e realizar as 
        apostas.</p>
    <p>
    </p>
</asp:Content>
