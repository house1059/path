using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace PathLink
{
    /// <summary>
    /// xlsからPathLink.txtを作成する。ClosedXmlを使用
    /// </summary>
    public class XlsPath
    {

        public string FilePath { get; set; }    //データ変換ツール
        XLWorkbook wb = null;



        public XlsPath()
        {
            


        }


        /// <summary>
        /// データ変換ツールからPathLink.txtを作成する。とりあえずそのまま移植してその後リファクタリング
        /// </summary>
        public void DataConvert(string filePath)
        {
            //メンバ
            IXLRange range = null;



            //ファイルが存在するかの確認を行う
            if( !System.IO.File.Exists(filePath) ){
                MessageBox.Show(filePath + "が見つかりません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //データ変換ツールを開いてまずはすべてのパスを確認し、xls形式が存在しないか確認する。
            wb = new XLWorkbook(filePath);
            bool bl = false;
            foreach(IXLWorksheet sh in wb.Worksheets)
            {
                if (sh.Name == "変換設定")
                    bl = true;
            }
            
            //変換設定がなかった場合
            if (!bl)
            {
                MessageBox.Show("変換設定のシートが見つかりませんでした", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //ファイルパスを抜く
            //range = wb.



        }



    }
}


