using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PathLink
{
    /// <summary>
    /// xlsからPathLink.txtを作成する。ClosedXmlを使用
    /// </summary>
    public class XlsPath
    {

        public string FilePath { get; set; }    //データ変換ツール
       


        public XlsPath()
        {
            


        }


        /// <summary>
        /// データ変換ツールからPathLink.txtを作成する。とりあえずそのまま移植してその後リファクタリング
        /// </summary>
        public void DataConvert(string filePath)
        {
            IXLWorksheet sh = null;
            List<string> filePathList = new List<string>();


            try
            {
                //ﾃﾞｰﾀ変換ツールを開いてリストを作成します。
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XLWorkbook wb = new XLWorkbook(fs, XLEventTracking.Disabled);
                if (!wb.TryGetWorksheet("変換設定", out sh))
                {
                    MessageBox.Show("変換設定のシートが見つかりませんでした", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //ファイルパスを抜く ｾﾙの検索が無いのでC1からC下限まで逐次検索
                
                for (int i = 1; i < sh.LastRowUsed().RowNumber(); i++)
                {
                    if (wb.Worksheet("変換設定").Cell($"C{i}").Value.ToString() == "変換ファイル名（フルパス）")
                    {
                        if (wb.Worksheet("変換設定").Cell($"D{i}").Value.ToString() != "")
                        {
                            filePathList.Add(wb.Worksheet("変換設定").Cell($"D{i}").Value.ToString());
                        }
                    }
                }


            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(filePath + "が見つかりません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }catch (System.IO.IOException)
            {
                MessageBox.Show("ﾃﾞｰﾀ変換ツールを一旦閉じてください", "Error", MessageBoxButtons.OK);
                return;
            }
      
           

            //ファイルパルの取得完了したので生死判定と拡張子判定
            string dedString = "";
            string dedExtension = "";
            foreach (string list in filePathList)
            {
                FileInfo info = new FileInfo(list);
                if (!File.Exists(list))
                {
                    dedString += list.ToString() + "\n";
                }

                if (!(info.Extension == ".xlsx" || info.Extension == ".xlsm"))
                {
                    dedExtension += list.ToString() + "\n";
                }
            }
            if (dedString != "")
            {
                MessageBox.Show("以下のリンクが見つかりません\n" + dedString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dedExtension != "")
            {
                MessageBox.Show("拡張子は.xlsxか.xlsmのみしか取得できません\n" + dedExtension, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //ﾃﾞｰﾀ取得処理を行う。
            foreach(string list in filePathList)
            {
                FileStream fs = new FileStream(list, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XLWorkbook wb = new XLWorkbook(fs, XLEventTracking.Disabled);


                foreach ( IXLWorksheet sheet in wb.Worksheets)
                {
                    switch (sheet.Name)
                    {
                        case "ランプ部品":
                            break;

                        case "サウンド部品":
                            break;

                        case "モータ部品":
                            break;

                        case "選択テーブル部品":
                            break;

                        case "ＳＥＬ":
                            break;

                        case "パターン":
                            break;

                        case "ＰＡＴ":
                            break;

                        case "ＴＢ":
                            break;

                        case "関数部品":
                            break;

                        case "サウンドフレーズ部品":
                            break;

                    }
                }
            }
        }

    }
}


