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
            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show(filePath + "が見つかりません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XLWorkbook wb = null;
            //データ変換ツールを開いてまずはすべてのパスを確認し、xls形式が存在しないか確認する。
            try
            {
                wb = new XLWorkbook(filePath);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("ﾃﾞｰﾀ変換ツールを一旦閉じてください", "Error", MessageBoxButtons.OK);
                return;

            }


            IXLWorksheet sh;
            if (wb.TryGetWorksheet("変換設定", out sh) )
            {
                MessageBox.Show("変換設定のシートが見つかりませんでした", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

            }


            //ファイルパスを抜く ｾﾙの検索が無いのでC1からC下限まで逐次検索
            range = wb.Worksheet("変換設定").Range("C1");

            for (int i = 1; i < sh.RangeUsed. )


            //    For colNo = 1 To wb.RangeUsed.RangeAddress.LastAddress.ColumnNumber
            //       Dim cell = ws.Cell(rowNo, colNo)
            //            sb.Add(cell.Value.ToString)
            //        Next



                //    string address = wb.Worksheet("変換設定").Range("C65536").RowsUsed()
                //    while()


                //    Set objRange = vrWkBook.Sheets("変換設定").Cells.Find("◎",,, 1,,, 0)  '//シート名固定
                //    if ( range )

                //    If Not objRange Is Nothing Then

                //    strStart = objRange.ADDRESS

                //    i = 1

                //    Do
                //        Do While objRange.Offset(i, 1).Value = "変換ファイル名（フルパス）"   '//このキーで探す

                //            If objRange.Offset(i, 2).value <> "" Then
                //                 ReDim Preserve strFileName(Ubound(strFileName)+1)
                // ReDim Preserve strFileAdd(Ubound(strFileAdd) + 1)

                //                strFileName(Ubound(strFileName) - 1) = objRange.Offset(i, 2).value

                //            '//	デバッグ

                //                strFileAdd(Ubound(strFileAdd) - 1) = objRange.Offset(i, 2).address

                //            End If

                //            i = i + 1

                //        Loop
                //        Set objRange = vrWkBook.Sheets("変換設定").Cells.FindNext(objRange)

                //        i = 1

                //    Loop While Not objRange Is Nothing And objRange.ADDRESS<> strStart

                //End If

                //vrWkBook.Saved = True

                //vrWkBook.Close



                //}

        }

    }
}


