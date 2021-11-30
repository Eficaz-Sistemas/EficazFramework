using FluentAssertions;
using NUnit.Framework;

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
        "37990000".FormatCEP().Should().Be("37.990-000");
        "037990000".FormatCEP().Should().Be("037.990-000");
        "7990000".FormatCEP().Should().Be("7.990-000");
        "14407760".FormatCEP().Should().Be("14.407-760");
    }

    [Test]
    public void FormataFone()
    {
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
    }

    [Test]
    public void FormataDocumentoRFB()
    {
        "07731253619".FormatRFBDocument().Should().Be("077.312.536-19");
        "10608025000126".FormatRFBDocument().Should().Be("10.608.025/0001-26");
    }

    [Test]
    public void FormataPIS()
    {
        "20476695850".FormatPIS().Should().Be("204.76695.85-0");
        "20685458924".FormatPIS().Should().Be("206.85458.92-4");
    }






    [Test]
    public void ValidaInscricoesEstaduais()
    {
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
    }

}
