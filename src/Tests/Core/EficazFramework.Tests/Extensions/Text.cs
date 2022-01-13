using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace EficazFramework.Extensions;

public class Text
{
    [Test]
    public void Substring()
    {
        // Left
        "Eficaz".Left(0).Should().Be("");
        "Eficaz".Left(1).Should().Be("E");
        "Eficaz".Left(2).Should().Be("Ef");

        // Mid
        "Eficaz".Mid(0).Should().Be("Eficaz");
        "Eficaz".Mid(1).Should().Be("ficaz");
        "Eficaz".Mid(2).Should().Be("icaz");
        "Eficaz".Mid(0, 1).Should().Be("E");
        "Eficaz".Mid(1, 1).Should().Be("f");
        "Eficaz".Mid(2, 1).Should().Be("i");
        "Eficaz".Mid(0, 3).Should().Be("Efi");
        "Eficaz".Mid(1, 3).Should().Be("fic");
        "Eficaz".Mid(2, 3).Should().Be("ica");

        // Right
        "Eficaz".Right(0).Should().Be("");
        "Eficaz".Right(1).Should().Be("z");
        "Eficaz".Right(2).Should().Be("az");
        "Eficaz".Right(3).Should().Be("caz");
    }

    [Test]
    public void FormataCEP()
    {
        "799".FormatCEP().Should().Be("799");
        "3799".FormatCEP().Should().Be("3-799");
        "37990".FormatCEP().Should().Be("37-990");
        "379900".FormatCEP().Should().Be("379-900");
        "7990000".FormatCEP().Should().Be("7.990-000");
        "37990000".FormatCEP().Should().Be("37.990-000");
        "14407760".FormatCEP().Should().Be("14.407-760");
        "037990000".FormatCEP().Should().Be("037.990-000");
        "0037990000".FormatCEP().Should().Be("0.037.990-000");
        "00037990000".FormatCEP().Should().Be("00.037.990-000");
        "00037990000".FormatCEP().Should().Be("00.037.990-000");
        "000037990000".FormatCEP().Should().Be("000.037.990-000");
        "0000037990000".FormatCEP().Should().Be("0000037990000");
    }

    [Test]
    public void FormataFone()
    {
        "abc".FormatFone().Should().Be("abc");

        "5441245".FormatFone().Should().Be("544-1245");
        "35441245".FormatFone().Should().Be("3544-1245");
        "3535441245".FormatFone().Should().Be("(35) 3544-1245");
        "553535441245".FormatFone().Should().Be("+55 (35) 3544-1245");

        "99712741".FormatFone().Should().Be("9971-2741");
        "999712741".FormatFone().Should().Be("99971-2741");
        "1699712741".FormatFone().Should().Be("(16) 9971-2741");
        "16999712741".FormatFone().Should().Be("(16) 99971-2741");
        "551699712741".FormatFone().Should().Be("+55 (16) 9971-2741");
        "5516999712741".FormatFone().Should().Be("+55 (16) 99971-2741");
        "55516999712741".FormatFone().Should().Be("55516999712741");

        "08001234567".FormatFone().Should().Be("0800 123 4567");
        "03001234567".FormatFone().Should().Be("0300 123 4567");
    }

    [Test]
    public void FormataInscricaoEstadual()
    {
        "0192123239204".FormatIE("AC").Should().Be("01.921.232/392-04");
        "197961878".FormatIE("AM").Should().Be("19.796.187-8");
        "21663949".FormatIE("BA").Should().Be("216639-49");
        "412818043".FormatIE("CE").Should().Be("41281804-3");
        "0741801100161".FormatIE("DF").Should().Be("07418011001-61");
        "357949382".FormatIE("ES").Should().Be("35794938-2");
        "100310060".FormatIE("GO").Should().Be("10.031.006-0");
        "120160960".FormatIE("MA").Should().Be("12016096-0");
        "65791337833".FormatIE("MT").Should().Be("6579133783-3");
        "280574517".FormatIE("MS").Should().Be("28057451-7");
        "5128464487031".FormatIE("MG").Should().Be("512.846448.70-31");
        "154712086".FormatIE("PA").Should().Be("01.547120.8-6");
        "464804507".FormatIE("PB").Should().Be("46480450-7");
        "9179443853".FormatIE("PR").Should().Be("917.94438-53");
        //"473164116".FormatIE("PE").Should().Be("4731641-16");
        "915826380".FormatIE("PI").Should().Be("91582638-0");
        "75133553".FormatIE("RJ").Should().Be("75.133.55-3");
        "203479602".FormatIE("RN").Should().Be("20.347.960-2");
        "3045088416".FormatIE("RS").Should().Be("304/5088416");
        //"95715028357508".FormatIE("RO").Should().Be("9571502835750-8");
        "240001738".FormatIE("RR").Should().Be("24000173-8");
        "550884360766".FormatIE("SP").Should().Be("550.884.360.766");
        "827969970".FormatIE("SC").Should().Be("827.969.970");
        "028325281".FormatIE("SE").Should().Be("02832528-1");
        //"92036578081".FormatIE("TO").Should().Be("9203657808-1");
        "ISENTO".FormatIE("BA").Should().Be("ISENTO");
        "ISENTA".FormatIE("BA").Should().Be("ISENTA");
        "Isento".FormatIE("BA").Should().Be("Isento");
        "".FormatIE("BA").Should().Be("");
        "abc".FormatIE("BA").Should().Be("abc");
    }

    [Test]
    public void FormataLogradouro()
    {
        var result = "Rua Tiradentes".FormatLogradouro();
        result.Should().HaveCount(2);
        result[0].Should().Be("Rua");
        result[1].Should().Be("Tiradentes");

        result = "rua tiradentes".FormatLogradouro();
        result.Should().HaveCount(2);
        result[0].Should().Be("Rua");
        result[1].Should().Be("Tiradentes");

        result = "rua tiradentes".FormatLogradouro(false);
        result.Should().HaveCount(2);
        result[0].Should().Be("Rua");
        result[1].Should().Be("tiradentes");

        result = " tiradentes".FormatLogradouro();
        result.Should().HaveCount(2);
        result[0].Should().Be("Rua");
        result[1].Should().Be("Tiradentes");

        result = "rua tiradentes de todo mundo que se atrever a vir aqui".FormatLogradouro();
        result.Should().HaveCount(2);
        result[0].Should().Be("Rua");
        result[1].Should().Be("Tiradentes De Todo Mundo Que Se Atrever A");
        result[1].Length.Should().BeLessThanOrEqualTo(45);

        result = " tiradentes de todo mundo que se atrever a vir aqui".FormatLogradouro();
        result.Should().HaveCount(2);
        result[0].Should().Be("Rua");
        result[1].Should().Be("Tiradentes De Todo Mundo Que Se Atrever A Vi");
        result[1].Length.Should().BeLessThanOrEqualTo(45);
    }

    [Test]
    public void FormataDocumentoRFB()
    {
        "07731253619".FormatRFBDocument().Should().Be("077.312.536-19");
        "10608025000126".FormatRFBDocument().Should().Be("10.608.025/0001-26");
        "10.608.025/0001-26".FormatRFBDocument().Should().Be("10.608.025/0001-26");
        "10.608025000126".FormatRFBDocument().Should().Be("10.608025000126");
        "110608025000126".FormatRFBDocument().Should().Be("110608025000126");
        string nullString = null;
        nullString.FormatRFBDocument().Should().BeNull();
    }

    [Test]
    public void FormataPisPasep()
    {
        "20476695850".FormatPIS().Should().Be("204.76695.85-0");
        "20685458924".FormatPIS().Should().Be("206.85458.92-4");
    }

    [Test]
    public void RemoveAcentos()
    {
        "áàäâã".GetClearText().Should().Be("aaaaa");
        "éèëê".GetClearText().Should().Be("eeee");
        "íìïî".GetClearText().Should().Be("iiii");
        "óòöôõ".GetClearText().Should().Be("ooooo");
        "úùüû".GetClearText().Should().Be("uuuu");
        "ÁÀÄÂÃ".GetClearText().Should().Be("AAAAA");
        "ÉÈËÊ".GetClearText().Should().Be("EEEE");
        "ÍÌÏÎ".GetClearText().Should().Be("IIII");
        "ÓÒÖÔÕ".GetClearText().Should().Be("OOOOO");
        "ÚÙÜÛ".GetClearText().Should().Be("UUUU");
        "ç".GetClearText().Should().Be("c");
        "C".GetClearText().Should().Be("C");
    }

    [Test]
    public void RemoveMascara()
    {
        "077.312.536-19".RemoveTextMask().Should().Be("07731253619");
        "10.608.025/0001-26".RemoveTextMask().Should().Be("10608025000126");
        "?/.-]=';[".RemoveTextMask().Should().Be("");
    }

    [Test]
    public void SplitByLength()
    {
        var result = "henrique".SplitByLength(1);
        result.Should().HaveCount(8);
        result.Where(r => r.Length > 1).Count().Should().BeLessThanOrEqualTo(0);
        
        result = "henrique".SplitByLength(2);
        result.Should().HaveCount(4);
        result.Where(r => r.Length > 2).Count().Should().BeLessThanOrEqualTo(0);
        
        result = "henrique".SplitByLength(3);
        result.Should().HaveCount(3);
        result.Where(r => r.Length > 3).Count().Should().BeLessThanOrEqualTo(0);

        result = "henrique".SplitByLength(4);
        result.Should().HaveCount(2);
        result.Where(r => r.Length > 4).Count().Should().BeLessThanOrEqualTo(0);

        result = "henrique".SplitByLength(5);
        result.Should().HaveCount(2);
        result.Where(r => r.Length > 5).Count().Should().BeLessThanOrEqualTo(0);

        result = "henrique".SplitByLength(7);
        result.Should().HaveCount(2);
        result.Where(r => r.Length > 7).Count().Should().BeLessThanOrEqualTo(0);
        result.ElementAt(1).Length.Should().Be(1);

        result = "henrique".SplitByLength(8);
        result.Should().HaveCount(1);
        result.Where(r => r.Length > 8).Count().Should().BeLessThanOrEqualTo(0);
    }

    [Test]
    public void ToTitleCase()
    {
        TextExtensions.ToTitleCase(null).Should().Be(null);
        "henrique clausing".ToTitleCase().Should().Be("Henrique Clausing");
        "HENRIQUE CLAUSING".ToTitleCase().Should().Be("Henrique Clausing");
        "h".ToTitleCase().Should().Be("H");
    }

    [Test]
    public void ToUrlSlugTest()
    {
        "HENRIQUE CLAUSING".ToUrlSlug().Should().Be("henrique-clausing");
        "Como sobreviver em um mundo de LOUCOS".ToUrlSlug().Should().Be("como-sobreviver-em-um-mundo-de-loucos");
    }


    // Validações:

    [Test]
    public void ValidaEMail()
    {
        "hcl@gmail.com".IsValidEmailAddress().Should().Be(true);
        "h.cl@gmail.com".IsValidEmailAddress().Should().Be(true);
        "h_cl@gmail.com".IsValidEmailAddress().Should().Be(true);
        "h-cl@gmail.com".IsValidEmailAddress().Should().Be(true);
        "h cl@gmail.com".IsValidEmailAddress().Should().Be(false);
        "hcl@gmail.".IsValidEmailAddress().Should().Be(false);
        "hcl@".IsValidEmailAddress().Should().Be(false);
        "hclgmail.com".IsValidEmailAddress().Should().Be(false);
    }

    [Test]
    public void ValidaDocumentoRFB()
    {
        "07731253619".IsValidCPF().Should().Be(true);
        "077.312.536-19".IsValidCPF().Should().Be(false);
        "07731253620".IsValidCPF().Should().Be(false);
        "077.312.536-20".IsValidCPF().Should().Be(false);
        "07831253620".IsValidCPF().Should().Be(false);
        "078.312.536-20".IsValidCPF().Should().Be(false);

        "10608025000126".IsValidCNPJ().Should().Be(true);
        "10.608.025/0001-26".IsValidCNPJ().Should().Be(false);
        "10608025000127".IsValidCNPJ().Should().Be(false);
        "10.608.025/0001-27".IsValidCNPJ().Should().Be(false);
        "11608025000126".IsValidCNPJ().Should().Be(false);
        "11.608.025/0001-26".IsValidCNPJ().Should().Be(false);
    }

    [Test]
    public void ValidaInscricoesEstaduais()
    {
        "100270100128".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0100270100128".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0100100500168".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0100336500102".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0103204000158".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0103237700183".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0103446100103".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0103279300108".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0100085700327".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0100020400159".IsValidInscricaoEstadual("AC").Should().Be(true);
        "0101444400561".IsValidInscricaoEstadual("AC").Should().Be(true);
        "1101444400561".IsValidInscricaoEstadual("AC").Should().Be(false);
        "1101444400560".IsValidInscricaoEstadual("AC").Should().Be(false);
        "241056870".IsValidInscricaoEstadual("AL").Should().Be(true);
        "246010100".IsValidInscricaoEstadual("AL").Should().Be(true);
        "242238831".IsValidInscricaoEstadual("AL").Should().Be(true);
        "242849270".IsValidInscricaoEstadual("AL").Should().Be(true);
        "244087334".IsValidInscricaoEstadual("AL").Should().Be(true);
        "241068070".IsValidInscricaoEstadual("AL").Should().Be(true);
        "246018836".IsValidInscricaoEstadual("AL").Should().Be(true);
        "240978129".IsValidInscricaoEstadual("AL").Should().Be(true);
        "240801547".IsValidInscricaoEstadual("AL").Should().Be(true);
        "241016967".IsValidInscricaoEstadual("AL").Should().Be(true);
        "042113148".IsValidInscricaoEstadual("AM").Should().Be(true);
        "041380193".IsValidInscricaoEstadual("AM").Should().Be(true);
        "041486137".IsValidInscricaoEstadual("AM").Should().Be(true);
        "042363780".IsValidInscricaoEstadual("AM").Should().Be(true);
        "053605179".IsValidInscricaoEstadual("AM").Should().Be(true);
        "042107687".IsValidInscricaoEstadual("AM").Should().Be(true);
        "042184428".IsValidInscricaoEstadual("AM").Should().Be(true);
        "053719778".IsValidInscricaoEstadual("AM").Should().Be(true);
        "053991532".IsValidInscricaoEstadual("AM").Should().Be(true);
        "042355087".IsValidInscricaoEstadual("AM").Should().Be(true);
        "142355087".IsValidInscricaoEstadual("AM").Should().Be(false);
        "042355086".IsValidInscricaoEstadual("AM").Should().Be(false);
        "030285038".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030292522".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030482488".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030480329".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030503701".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030214122".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030427665".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030483905".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030247616".IsValidInscricaoEstadual("AP").Should().Be(true);
        "030090658".IsValidInscricaoEstadual("AP").Should().Be(true);
        "130247616".IsValidInscricaoEstadual("AP").Should().Be(false);
        "030090657".IsValidInscricaoEstadual("AP").Should().Be(false);
        "3309877".IsValidInscricaoEstadual("BA").Should().Be(false);
        "73309877".IsValidInscricaoEstadual("BA").Should().Be(true);
        "73322466".IsValidInscricaoEstadual("BA").Should().Be(true);
        "75823430".IsValidInscricaoEstadual("BA").Should().Be(true);
        "63831831".IsValidInscricaoEstadual("BA").Should().Be(true);
        "063831831".IsValidInscricaoEstadual("BA").Should().Be(true);
        "101902359".IsValidInscricaoEstadual("BA").Should().Be(true);
        "102154377".IsValidInscricaoEstadual("BA").Should().Be(true);
        "16895056".IsValidInscricaoEstadual("BA").Should().Be(true);
        "78575129".IsValidInscricaoEstadual("BA").Should().Be(true);
        "06895056".IsValidInscricaoEstadual("BA").Should().Be(false);
        "78575128".IsValidInscricaoEstadual("BA").Should().Be(false);
        "015356000".IsValidInscricaoEstadual("BA").Should().Be(true);
        "066843260".IsValidInscricaoEstadual("CE").Should().Be(true);
        "066150639".IsValidInscricaoEstadual("CE").Should().Be(true);
        "066163757".IsValidInscricaoEstadual("CE").Should().Be(true);
        "065167899".IsValidInscricaoEstadual("CE").Should().Be(true);
        "063600544".IsValidInscricaoEstadual("CE").Should().Be(true);
        "063761793".IsValidInscricaoEstadual("CE").Should().Be(true);
        "063384310".IsValidInscricaoEstadual("CE").Should().Be(true);
        "065960670".IsValidInscricaoEstadual("CE").Should().Be(true);
        "062858742".IsValidInscricaoEstadual("CE").Should().Be(true);
        "069951888".IsValidInscricaoEstadual("CE").Should().Be(true);
        "162858742".IsValidInscricaoEstadual("CE").Should().Be(false);
        "069951887".IsValidInscricaoEstadual("CE").Should().Be(false);
        "0748900000111".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0750889600156".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0752439100124".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0756703800183".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0762642100181".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0764541800125".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0758221800162".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0737785100133".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0733095700138".IsValidInscricaoEstadual("DF").Should().Be(true);
        "0765533900157".IsValidInscricaoEstadual("DF").Should().Be(true);
        "1733095700138".IsValidInscricaoEstadual("DF").Should().Be(false);
        "0765533900158".IsValidInscricaoEstadual("DF").Should().Be(false);
        "081905866".IsValidInscricaoEstadual("ES").Should().Be(true);
        "082262284".IsValidInscricaoEstadual("ES").Should().Be(true);
        "081310412".IsValidInscricaoEstadual("ES").Should().Be(true);
        "082554200".IsValidInscricaoEstadual("ES").Should().Be(true);
        "081457332".IsValidInscricaoEstadual("ES").Should().Be(true);
        "082982686".IsValidInscricaoEstadual("ES").Should().Be(true);
        "081760248".IsValidInscricaoEstadual("ES").Should().Be(true);
        "082753210".IsValidInscricaoEstadual("ES").Should().Be(true);
        "081911378".IsValidInscricaoEstadual("ES").Should().Be(true);
        "082644063".IsValidInscricaoEstadual("ES").Should().Be(true);
        "310239081110".IsValidInscricaoEstadual("EX").Should().Be(true);
        "105905496".IsValidInscricaoEstadual("GO").Should().Be(true);
        "101902603".IsValidInscricaoEstadual("GO").Should().Be(true);
        "106961810".IsValidInscricaoEstadual("GO").Should().Be(true);
        "107303477".IsValidInscricaoEstadual("GO").Should().Be(true);
        "105407267".IsValidInscricaoEstadual("GO").Should().Be(true);
        "102479763".IsValidInscricaoEstadual("GO").Should().Be(true);
        "103132155".IsValidInscricaoEstadual("GO").Should().Be(true);
        "103447695".IsValidInscricaoEstadual("GO").Should().Be(true);
        "104786833".IsValidInscricaoEstadual("GO").Should().Be(true);
        "103990607".IsValidInscricaoEstadual("GO").Should().Be(true);
        "124202543".IsValidInscricaoEstadual("MA").Should().Be(true);
        "121203522".IsValidInscricaoEstadual("MA").Should().Be(true);
        "124570496".IsValidInscricaoEstadual("MA").Should().Be(true);
        "122167309".IsValidInscricaoEstadual("MA").Should().Be(true);
        "122356365".IsValidInscricaoEstadual("MA").Should().Be(true);
        "125067437".IsValidInscricaoEstadual("MA").Should().Be(true);
        "126163375".IsValidInscricaoEstadual("MA").Should().Be(true);
        "121460878".IsValidInscricaoEstadual("MA").Should().Be(true);
        "121550907".IsValidInscricaoEstadual("MA").Should().Be(true);
        "121560090".IsValidInscricaoEstadual("MA").Should().Be(true);
        "0629273440079".IsValidInscricaoEstadual("MG").Should().Be(true);
        "0010196530040".IsValidInscricaoEstadual("MG").Should().Be(true);
        "5250346050025".IsValidInscricaoEstadual("MG").Should().Be(true);
        "2830656980010".IsValidInscricaoEstadual("MG").Should().Be(true);
        "5675650391179".IsValidInscricaoEstadual("MG").Should().Be(true);
        "0022417780089".IsValidInscricaoEstadual("MG").Should().Be(true);
        "0024745680015".IsValidInscricaoEstadual("MG").Should().Be(true);
        "7079031700054".IsValidInscricaoEstadual("MG").Should().Be(true);
        "0624667540043".IsValidInscricaoEstadual("MG").Should().Be(true);
        "0010961460393".IsValidInscricaoEstadual("MG").Should().Be(true);
        "280035870".IsValidInscricaoEstadual("MS").Should().Be(true);
        "283317655".IsValidInscricaoEstadual("MS").Should().Be(true);
        "283131004".IsValidInscricaoEstadual("MS").Should().Be(true);
        "287021742".IsValidInscricaoEstadual("MS").Should().Be(true);
        "283377682".IsValidInscricaoEstadual("MS").Should().Be(true);
        "285099906".IsValidInscricaoEstadual("MS").Should().Be(true);
        "286817403".IsValidInscricaoEstadual("MS").Should().Be(true);
        "283529024".IsValidInscricaoEstadual("MS").Should().Be(true);
        "283344024".IsValidInscricaoEstadual("MS").Should().Be(true);
        "282816771".IsValidInscricaoEstadual("MS").Should().Be(true);
        "133134610".IsValidInscricaoEstadual("MT").Should().Be(true);
        "00133616223".IsValidInscricaoEstadual("MT").Should().Be(true);
        "134652142".IsValidInscricaoEstadual("MT").Should().Be(true);
        "132107430".IsValidInscricaoEstadual("MT").Should().Be(true);
        "131975420".IsValidInscricaoEstadual("MT").Should().Be(true);
        "135235413".IsValidInscricaoEstadual("MT").Should().Be(true);
        "131915754".IsValidInscricaoEstadual("MT").Should().Be(true);
        "130044350".IsValidInscricaoEstadual("MT").Should().Be(true);
        "132863766".IsValidInscricaoEstadual("MT").Should().Be(true);
        "131157043".IsValidInscricaoEstadual("MT").Should().Be(true);
        "155359860".IsValidInscricaoEstadual("PA").Should().Be(true);
        "156747251".IsValidInscricaoEstadual("PA").Should().Be(true);
        "156796350".IsValidInscricaoEstadual("PA").Should().Be(true);
        "155981935".IsValidInscricaoEstadual("PA").Should().Be(true);
        "156796368".IsValidInscricaoEstadual("PA").Should().Be(true);
        "152778314".IsValidInscricaoEstadual("PA").Should().Be(true);
        "153595396".IsValidInscricaoEstadual("PA").Should().Be(true);
        "156420872".IsValidInscricaoEstadual("PA").Should().Be(true);
        "156613654".IsValidInscricaoEstadual("PA").Should().Be(true);
        "152279393".IsValidInscricaoEstadual("PA").Should().Be(true);
        "161540155".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161424287".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161537944".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161465498".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161387179".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161553168".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161116370".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161230377".IsValidInscricaoEstadual("PB").Should().Be(true);
        "161327796".IsValidInscricaoEstadual("PB").Should().Be(true);
        "160178541".IsValidInscricaoEstadual("PB").Should().Be(true);
        "049454927".IsValidInscricaoEstadual("PE").Should().Be(true);
        "031010962".IsValidInscricaoEstadual("PE").Should().Be(true);
        "032269560".IsValidInscricaoEstadual("PE").Should().Be(true);
        "030400112".IsValidInscricaoEstadual("PE").Should().Be(true);
        "029808197".IsValidInscricaoEstadual("PE").Should().Be(true);
        "28611519".IsValidInscricaoEstadual("PE").Should().Be(true);
        "056100019".IsValidInscricaoEstadual("PE").Should().Be(true);
        "027587762".IsValidInscricaoEstadual("PE").Should().Be(true);
        "036232467".IsValidInscricaoEstadual("PE").Should().Be(true);
        "029270391".IsValidInscricaoEstadual("PE").Should().Be(true);
        "195914015".IsValidInscricaoEstadual("PI").Should().Be(true);
        "194381315".IsValidInscricaoEstadual("PI").Should().Be(true);
        "196510678".IsValidInscricaoEstadual("PI").Should().Be(true);
        "194670066".IsValidInscricaoEstadual("PI").Should().Be(true);
        "195977076".IsValidInscricaoEstadual("PI").Should().Be(true);
        "194614271".IsValidInscricaoEstadual("PI").Should().Be(true);
        "194635350".IsValidInscricaoEstadual("PI").Should().Be(true);
        "196005086".IsValidInscricaoEstadual("PI").Should().Be(true);
        "194010139".IsValidInscricaoEstadual("PI").Should().Be(true);
        "196140951".IsValidInscricaoEstadual("PI").Should().Be(true);
        "9023740866".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9032212678".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9041914774".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9044055314".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9045467551".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9069899991".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9064314677".IsValidInscricaoEstadual("PR").Should().Be(true);
        "9072362850".IsValidInscricaoEstadual("PR").Should().Be(true);
        "6280217164".IsValidInscricaoEstadual("PR").Should().Be(true);
        "7100030335".IsValidInscricaoEstadual("PR").Should().Be(true);
        "83122684".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "81526990".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "79912018".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "87044904".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "79259934".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "79805556".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "11012566".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "81410143".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "87433595".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "77470573".IsValidInscricaoEstadual("RJ").Should().Be(true);
        "202981967".IsValidInscricaoEstadual("RN").Should().Be(true);
        "202167704".IsValidInscricaoEstadual("RN").Should().Be(true);
        "202251063".IsValidInscricaoEstadual("RN").Should().Be(true);
        "200408674".IsValidInscricaoEstadual("RN").Should().Be(true);
        "200761269".IsValidInscricaoEstadual("RN").Should().Be(true);
        "204952280".IsValidInscricaoEstadual("RN").Should().Be(true);
        "0204952280".IsValidInscricaoEstadual("RN").Should().Be(false);
        "205062105".IsValidInscricaoEstadual("RN").Should().Be(true);
        "204076269".IsValidInscricaoEstadual("RN").Should().Be(true);
        "202202747".IsValidInscricaoEstadual("RN").Should().Be(true);
        "200975544".IsValidInscricaoEstadual("RN").Should().Be(true);
        "00000001624067".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000900702".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000911976".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000917036".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000917044".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000001716336".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000001716344".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000939269".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000955485".IsValidInscricaoEstadual("RO").Should().Be(true);
        "00000000542199".IsValidInscricaoEstadual("RO").Should().Be(true);
        "240378238".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240263342".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240379600".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240312378".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240241356".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240002183".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240335575".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240376654".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240364334".IsValidInscricaoEstadual("RR").Should().Be(true);
        "240228904".IsValidInscricaoEstadual("RR").Should().Be(true);
        "1320165424".IsValidInscricaoEstadual("RS").Should().Be(true);
        "0963662023".IsValidInscricaoEstadual("RS").Should().Be(true);
        "0290561299".IsValidInscricaoEstadual("RS").Should().Be(true);
        "1160019271".IsValidInscricaoEstadual("RS").Should().Be(true);
        "0860387836".IsValidInscricaoEstadual("RS").Should().Be(true);
        "2070010460".IsValidInscricaoEstadual("RS").Should().Be(true);
        "1770103004".IsValidInscricaoEstadual("RS").Should().Be(true);
        "2240025799".IsValidInscricaoEstadual("RS").Should().Be(true);
        "0240025210".IsValidInscricaoEstadual("RS").Should().Be(true);
        "1890004526".IsValidInscricaoEstadual("RS").Should().Be(true);
        "250990741".IsValidInscricaoEstadual("SC").Should().Be(true);
        "256753601".IsValidInscricaoEstadual("SC").Should().Be(true);
        "252186346".IsValidInscricaoEstadual("SC").Should().Be(true);
        "252428200".IsValidInscricaoEstadual("SC").Should().Be(true);
        "251804666".IsValidInscricaoEstadual("SC").Should().Be(true);
        "254474799".IsValidInscricaoEstadual("SC").Should().Be(true);
        "254306403".IsValidInscricaoEstadual("SC").Should().Be(true);
        "251175120".IsValidInscricaoEstadual("SC").Should().Be(true);
        "255316666".IsValidInscricaoEstadual("SC").Should().Be(true);
        "255065361".IsValidInscricaoEstadual("SC").Should().Be(true);
        "271093463".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271078952".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271131420".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271007087".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271541105".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271451246".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271120320".IsValidInscricaoEstadual("SE").Should().Be(true);
        "270759107".IsValidInscricaoEstadual("SE").Should().Be(true);
        "270684719".IsValidInscricaoEstadual("SE").Should().Be(true);
        "271274956".IsValidInscricaoEstadual("SE").Should().Be(true);
        "411121143119".IsValidInscricaoEstadual("SP").Should().Be(false);
        "401121143119".IsValidInscricaoEstadual("SP").Should().Be(true);
        "310653082113".IsValidInscricaoEstadual("SP").Should().Be(true);
        "310437609110".IsValidInscricaoEstadual("SP").Should().Be(true);
        "310422211114".IsValidInscricaoEstadual("SP").Should().Be(true);
        "149360242111".IsValidInscricaoEstadual("SP").Should().Be(true);
        "582720336115".IsValidInscricaoEstadual("SP").Should().Be(true);
        "310385929110".IsValidInscricaoEstadual("SP").Should().Be(true);
        "310157067117".IsValidInscricaoEstadual("SP").Should().Be(true);
        "310512850112".IsValidInscricaoEstadual("SP").Should().Be(true);
        "401033839116".IsValidInscricaoEstadual("SP").Should().Be(true);
        "P31043760911".IsValidInscricaoEstadual("SP").Should().Be(true);
        "293895741".IsValidInscricaoEstadual("TO").Should().Be(false);
        "293895740".IsValidInscricaoEstadual("TO").Should().Be(true);
        "290659000".IsValidInscricaoEstadual("TO").Should().Be(true);
        "290030757".IsValidInscricaoEstadual("TO").Should().Be(true);
        "290450098".IsValidInscricaoEstadual("TO").Should().Be(true);
        "294749373".IsValidInscricaoEstadual("TO").Should().Be(true);
        "293848254".IsValidInscricaoEstadual("TO").Should().Be(true);
        "294049746".IsValidInscricaoEstadual("TO").Should().Be(true);
        "290675286".IsValidInscricaoEstadual("TO").Should().Be(true);
        "294507965".IsValidInscricaoEstadual("TO").Should().Be(true);
        "294840303".IsValidInscricaoEstadual("TO").Should().Be(true);
        "294840303".IsValidInscricaoEstadual("EX").Should().Be(true);
        "294840303".IsValidInscricaoEstadual(null).Should().Be(false);
        "".IsValidInscricaoEstadual("EX").Should().Be(true);
        "".IsValidInscricaoEstadual(null).Should().Be(true);
        "0000".IsValidInscricaoEstadual("??").Should().Be(false);

    }

    [Test]
    public void ValidaPisPasep()
    {
        "20476695850".IsValidPISePASEP().Should().Be(true);
        "204.76695.85-0".IsValidPISePASEP().Should().Be(false);
        "20476695851".IsValidPISePASEP().Should().Be(false);
        "204.76695.85-1".IsValidPISePASEP().Should().Be(false);
        "21476695850".IsValidPISePASEP().Should().Be(false);
        "214.76695.85-0".IsValidPISePASEP().Should().Be(false);
    }

    // Localization:
    [Test]
    public void Localize()
    {
        "eDocumento_PIS_NIT".Localize(typeof(EficazFramework.Resources.Strings.TestStrings), "Documento selecionado: {0}").Should().Be($"Documento selecionado: {EficazFramework.Resources.Strings.TestStrings.eDocumento_PIS_NIT}");
        "eDocumento_PIS_NIT".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), "Documento selecionado: {0}").Should().Be($"Documento selecionado: {EficazFramework.Resources.Strings.DataDescriptions.eDocumento_PIS_NIT}");
        
        // fails:
        "eDocumento_PIS_NIT".Localize(typeof(EficazFramework.Resources.Strings.Application), null).Should().Be("eDocumento_PIS_NIT");
        "eDocumento_PIS_NIT".Localize(typeof(EficazFramework.Resources.Strings.Application), "Documento selecionado: {0}").Should().Be("Documento selecionado: eDocumento_PIS_NIT");

        "eDocumento_PIS_NIT".Localize(typeof(object), null).Should().Be("eDocumento_PIS_NIT");
        "eDocumento_PIS_NIT".Localize(typeof(object), "Documento selecionado: {0}").Should().Be("Documento selecionado: eDocumento_PIS_NIT");

        // enums
        "eComparer_Bigger".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_Bigger);
        "eComparer_Contains".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_Contains);
        "eComparer_Is".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_Is);
        "eComparer_IsNot".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_IsNot);
        "eComparer_Length".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_Length);
        "eComparer_LowerOrEqualThan".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_LowerOrEqualThan);
        "eComparer_StartsWith".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_StartsWith);

        "eUpdateValueMode_Expression".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eUpdateValueMode_Expression);
        "eUpdateValueMode_Fixed".Localize(typeof(EficazFramework.Resources.Strings.DataDescriptions), null).Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eUpdateValueMode_Fixed);

        // bools
        EficazFramework.Resources.Strings.Descriptions.Culture = EficazFramework.Resources.Strings.Descriptions.Culture;
        true.GetBoolValue(BoolDescriptionType.YesNo).Should().Be(EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_True);
        false.GetBoolValue(BoolDescriptionType.YesNo).Should().Be(EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_False);
        true.GetBoolValue(BoolDescriptionType.TrueFalse).Should().Be(EficazFramework.Resources.Strings.Descriptions.BoolToTrueFalse_True);
        false.GetBoolValue(BoolDescriptionType.TrueFalse).Should().Be(EficazFramework.Resources.Strings.Descriptions.BoolToTrueFalse_False);
    }
}
