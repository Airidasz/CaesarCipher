using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaesarCipher.Tests
{
    [TestClass()]
    public class CaesarCipherTests
    {
        [TestMethod()]
        public void Encrypt_EncryptionWorks_EncryptedText()
        {
            int offset = 20;
            string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            string expectedOutput = "Filyg Cjmog cm mcgjfs xoggs nyrn iz nby jlchncha uhx nsjymynncha chxomnls. Filyg Cjmog bum vyyh nby chxomnls'm mnuhxulx xoggs nyrn ypyl mchwy nby, qbyh uh ohehiqh jlchnyl niie u auffys iz nsjy uhx mwlugvfyx cn ni guey u nsjy mjywcgyh viie. Cn bum molpcpyx hin ihfs zcpy wyhnolcym, von ufmi nby fyuj chni yfywnlihcw nsjymynncha, lyguchcha ymmyhncuffs ohwbuhayx. Cn qum jijofulcmyx ch nby qcnb nby lyfyumy iz Fynlumyn mbyynm wihnuchcha Filyg Cjmog jummuaym, uhx gily lywyhnfs qcnb xymenij jovfcmbcha miznquly fcey Ufxom JuayGueyl chwfoxcha pylmcihm iz Filyg Cjmog.";

            Assert.AreEqual(expectedOutput, CaesarCipher.Encrypt(text, offset));
        }

        [TestMethod()]
        public void Encrypt_EncryptionWorksWithLargeOffset_EncryptedText()
        {
            int offset = 465;
            string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            string expectedOutput = "Ilobj Fmprj fp pfjmiv arjjv qbuq lc qeb mofkqfkd xka qvmbpbqqfkd fkarpqov. Ilobj Fmprj exp ybbk qeb fkarpqov'p pqxkaxoa arjjv qbuq bsbo pfkzb qeb, tebk xk rkhkltk mofkqbo qllh x dxiibv lc qvmb xka pzoxjyiba fq ql jxhb x qvmb pmbzfjbk yllh. Fq exp prosfsba klq lkiv cfsb zbkqrofbp, yrq xipl qeb ibxm fkql bibzqolkfz qvmbpbqqfkd, objxfkfkd bppbkqfxiiv rkzexkdba. Fq txp mlmrixofpba fk qeb tfqe qeb obibxpb lc Ibqoxpbq pebbqp zlkqxfkfkd Ilobj Fmprj mxppxdbp, xka jlob obzbkqiv tfqe abphqlm mryifpefkd plcqtxob ifhb Xiarp MxdbJxhbo fkzirafkd sbopflkp lc Ilobj Fmprj.";

            Assert.AreEqual(expectedOutput, CaesarCipher.Encrypt(text, offset));
        }

        [TestMethod()]
        public void Encrypt_NonLatinCharactersIgnored_SameText()
        {
            int offset = 120;
            string text = "/.?$#!@#!@#^&*((*&^%$+_)(*&^";
            string expectedOutput = "/.?$#!@#!@#^&*((*&^%$+_)(*&^";

            Assert.AreEqual(expectedOutput, CaesarCipher.Encrypt(text, offset));
        }

        [TestMethod()]
        public void Decrypt_DecryptionWorks_DecryptedText()
        {
            int offset = 20;
            string text = "Filyg Cjmog cm mcgjfs xoggs nyrn iz nby jlchncha uhx nsjymynncha chxomnls. Filyg Cjmog bum vyyh nby chxomnls'm mnuhxulx xoggs nyrn ypyl mchwy nby, qbyh uh ohehiqh jlchnyl niie u auffys iz nsjy uhx mwlugvfyx cn ni guey u nsjy mjywcgyh viie. Cn bum molpcpyx hin ihfs zcpy wyhnolcym, von ufmi nby fyuj chni yfywnlihcw nsjymynncha, lyguchcha ymmyhncuffs ohwbuhayx. Cn qum jijofulcmyx ch nby qcnb nby lyfyumy iz Fynlumyn mbyynm wihnuchcha Filyg Cjmog jummuaym, uhx gily lywyhnfs qcnb xymenij jovfcmbcha miznquly fcey Ufxom JuayGueyl chwfoxcha pylmcihm iz Filyg Cjmog.";
            string expectedOutput = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            Assert.AreEqual(expectedOutput, CaesarCipher.Decrypt(text, offset));
        }
    }
}
